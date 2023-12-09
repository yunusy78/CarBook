using CarBook.Dto.Dtos.TestimonialDto;

namespace Business.Abstract;

public interface ITestimonialService : IGenericService<TestimonialDto>
{
    
    Task<bool> AddAsync(TestimonialDto testimonialDto);
    Task<bool> UpdateAsync(TestimonialDto testimonialDto);
    
}