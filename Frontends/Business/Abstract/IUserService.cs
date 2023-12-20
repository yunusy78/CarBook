using CarBook.Dto.Dtos.User;

namespace Business.Abstract;

public interface IUserService
{
    Task<UserViewModel> GetUser();
    
    Task<List<UserViewModel>> GetAllUser();
}