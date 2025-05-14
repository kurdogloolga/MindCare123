using MindCare.DAL.Entities;

namespace MindCare.BLL.Abstraction;
public interface IAvailabilityService
{
    Task<IEnumerable<Availability>> GetAllAvailabilitiesAsync();
    Task<Availability> GetAvailabilityByIdAsync(Guid id);
    Task<IEnumerable<Availability>> GetAvailabilitiesBySpecialistAsync(Guid specialistId, DateTime date);
    Task<Guid> CreateAvailabilityAsync(Availability availability);
    Task UpdateAvailabilityAsync(Availability availability);
    Task DeleteAvailabilityAsync(Guid id);
}
