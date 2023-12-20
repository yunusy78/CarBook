

using Business.Abstract;
using CarBook.Dto.Dtos.Auth;
using Castle.Core.Configuration;

namespace Business.Concrete
{
    public class AuthManager :  IAuthService
    {
        private readonly IHttpClientFactory _clientFactory;


        public Task<T> LoginAsync<T>(LoginDto objToCreate)
        {
            throw new NotImplementedException();
        }

        public Task<T> RegisterAsync<T>(RegisterDto objToCreate)
        {
            throw new NotImplementedException();
        }
    }
}
