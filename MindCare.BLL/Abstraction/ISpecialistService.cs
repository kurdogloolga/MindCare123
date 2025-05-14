using MindCare.BLL.DTOs;
using MindCare.DAL.Entities;

namespace MindCare.BLL.Abstraction;
public interface ISpecialistService
{
    Task<IEnumerable<SpecialistDto>> GetAllSpecialistsAsync();
    Task<SpecialistDto> GetSpecialistByIdAsync(Guid id);
    Task<Guid> CreateSpecialistAsync(Specialist specialist);
    Task UpdateSpecialistAsync(Specialist specialist);
    Task DeleteSpecialistAsync(Guid id);
}
