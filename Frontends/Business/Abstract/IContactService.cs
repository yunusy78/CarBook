using CarBook.Dto.Dtos.ContactDto;
using CarBook.Dto.Dtos.CarCategory;

namespace Business.Abstract;

public interface IContactService : IGenericService<ContactDto>
{
    Task<bool> AddAsync(ContactDto contactDto);
    Task<bool> UpdateAsync(ContactDto contactDto);
    
}