using MindCare.BLL.DTOs;

namespace MindCare.BLL.Interfaces
{
    public interface ISpecialistService
    {
        Task<SpecialistDto> GetByIdAsync(Guid id);
        Task<IEnumerable<SpecialistDto>> GetAllAsync();
        Task CreateAsync(SpecialistDto specialistDto);
        Task UpdateAsync(SpecialistDto specialistDto);
        Task DeleteAsync(Guid id);
    }
}
