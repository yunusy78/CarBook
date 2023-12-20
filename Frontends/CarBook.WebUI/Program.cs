using Business.Abstract;
using Business.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using CarBook.WebUI.Data;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ??
                       throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();
builder.Services.AddHttpClient();
builder.Services.AddScoped<ICarService, CarManager>();
builder.Services.AddScoped<IFeatureService, FeatureManager>();
builder.Services.AddScoped<IBrandService, BrandManager>();
builder.Services.AddScoped<IBannerService, BannerManager>();
builder.Services.AddScoped<IBlogService, BlogManager>();
builder.Services.AddScoped<IBlogCategoryService, BlogCategoryManager>();
builder.Services.AddScoped<ICarCategoryService, CarCategoryManager>();
builder.Services.AddScoped<IContactService, ContactManager>();
builder.Services.AddScoped<ICommentService, CommentManager>();
builder.Services.AddScoped<IFooterService, FooterManager>();
builder.Services.AddScoped<ILocationService, LocationManager>();
builder.Services.AddScoped<IServiceService, ServiceManager>();
builder.Services.AddScoped<ITestimonialService, TestimonialManager>();
builder.Services.AddScoped<IAboutService, AboutManager>();
builder.Services.AddScoped<ITagCloudService, TagCloudManager>();
builder.Services.AddScoped<IBlogService , BlogManager>();
builder.Services.AddScoped<IAuthorService, AuthorManager>();
builder.Services.AddScoped<IPricingService, PricingManager>();
builder.Services.AddScoped<ICarPricingService, CarPricingManager>();
builder.Services.AddScoped<ISocialMediaService, SocialMediaManager>();
builder.Services.AddScoped<IReservationService, ReservationCarManager>();
builder.Services.AddScoped<ICarFeatureService, CarFeatureManager>();
builder.Services.AddScoped<IStatisticService, StatisticManager>();
builder.Services.AddScoped<IUserService, UserManager>();
builder.Services.AddScoped<ISharedIdentity, SharedIdentity>();

builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddHttpClient<IAuthService, AuthManager>();
builder.Services.AddScoped<IAuthService, AuthManager>();
builder.Services.AddDistributedMemoryCache();
builder.Services.AddAuthentication
    (options =>
    {
        options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = "oidc";
    })
    
           .AddCookie(options =>
              {
                  options.LogoutPath = "/" + builder.Configuration["ServiceApiSettings:LogoutPath"];
                  options.Cookie.HttpOnly = true;
                  options.ExpireTimeSpan = TimeSpan.FromMinutes(30);
                  options.LoginPath = "/Auth/Login";
                  options.AccessDeniedPath = "/Auth/AccessDenied";
                  options.SlidingExpiration = true;
              }).AddOpenIdConnect("oidc", options => {
                  options.Authority = builder.Configuration["ServiceApiSettings:IdentityServerAPI"];
                  options.GetClaimsFromUserInfoEndpoint = true;
                  options.ClientId = "magic";
                  options.ClientSecret = "secret";
                  options.ResponseType = "code";
                  options.TokenValidationParameters.NameClaimType = "name";
                  options.TokenValidationParameters.RoleClaimType = "role";
                  options.Scope.Add("magic");
                  options.SaveTokens = true;
                  options.ClaimActions.MapJsonKey("role", "role");
                  options.Events = new OpenIdConnectEvents
                  {
                      OnRemoteFailure = context =>
                      {
                          context.Response.Redirect("/");
                          context.HandleResponse();
                          return Task.FromResult(0);
                      }
                  };
              }); 
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(100);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.UseSession();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Default}/{action=Index}/{id?}");


app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name : "areas",
        pattern : "{area:exists}/{controller=Home}/{action=Index}/{id?}"
    );
});

app.Run();