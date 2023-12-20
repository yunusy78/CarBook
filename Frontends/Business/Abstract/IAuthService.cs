

using CarBook.Dto.Dtos.Auth;

namespace Business.Abstract
{
    public interface IAuthService
    {
        Task<T> LoginAsync<T>(LoginDto objToCreate);
        Task<T> RegisterAsync<T>(RegisterDto objToCreate);
    }
}
