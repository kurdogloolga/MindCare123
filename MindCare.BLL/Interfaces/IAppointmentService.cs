using MindCare.BLL.DTOs;

namespace MindCare.BLL.Interfaces
{
    public interface IAppointmentService
    {
        Task<AppointmentDto> GetByIdAsync(Guid id);
        Task<IEnumerable<AppointmentDto>> GetAllAsync();
        Task CreateAsync(AppointmentDto appointmentDto);
        Task UpdateAsync(AppointmentDto appointmentDto);
        Task DeleteAsync(Guid id);
    }
}
