using CarBook.Dto.Dtos.Auth;
using CarBook.Dto.Dtos.ResponseDto;

namespace Business.Abstract;

public interface IIdentityService
{
    Task<ResponseDto<bool>> SignIn(SignInDto signInInput);
    //Task<TokenResponse> GetAccessTokenByRefreshToken();
    Task RevokeRefreshToken();

    Task<ResponseDto<bool>> SignUp(RegisterDto signUpInput);
}