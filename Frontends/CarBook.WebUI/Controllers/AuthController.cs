using MagicVilla_Web.Models.Dto;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Business.Abstract;
using CarBook.Dto.Dtos.Auth;

namespace CarBook.WebUI.Controllers
{
    public class AuthController : Controller
    {
        private readonly IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Login()
        {
            
            return RedirectToAction(nameof(Index), "Default");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginDto obj)
        {
            APIResponse response = await _authService.LoginAsync<APIResponse>(obj);
            if (response != null && response.IsSuccess)
            { 
                LoginResponseDTO model = JsonConvert.DeserializeObject<LoginResponseDTO>(Convert.ToString(response.Result));

                var handler = new JwtSecurityTokenHandler();
                var jwt = handler.ReadJwtToken(model.Token);

                var identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme);
                identity.AddClaim(new Claim(ClaimTypes.Name, jwt.Claims.FirstOrDefault(u => u.Type == "name").Value));
                identity.AddClaim(new Claim(ClaimTypes.Role, jwt.Claims.FirstOrDefault(u=>u.Type=="role").Value));
                var principal = new ClaimsPrincipal(identity);
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);


                HttpContext.Session.SetString(SD.SessionToken, model.Token);
                return RedirectToAction("Index","Home");
            }
            else
            {
                ModelState.AddModelError("CustomError", response.ErrorMessages.FirstOrDefault());
                return View(obj);
            }
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterDto obj)
        {
            APIResponse result =  await _authService.RegisterAsync<APIResponse>(obj);
            if (result != null && result.IsSuccess)
            {
                return RedirectToAction("Login");
            }
            return View();
        }


        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            SignOut("Cookies", "oidc");
            HttpContext.Session.SetString(SD.SessionToken, "");
            return Redirect("https://localhost:7156/Account/Logout");
        }

        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}
