using MindCare.BLL.DTOs;
using MindCare.DAL.Entities;

namespace MindCare.BLL.Abstraction;
public interface IAppointmentService
{
    Task<IEnumerable<AppointmentDto>> GetAllAppointmentsAsync();
    Task<AppointmentDto> GetAppointmentByIdAsync(Guid id);
    Task<IEnumerable<AppointmentDto>> GetAppointmentsByUserAsync(Guid userId);
    Task<IEnumerable<AppointmentDto>> GetAppointmentsBySpecialistAsync(Guid specialistId);
    Task<Guid> BookAppointmentAsync(AppointmentDto appointment);
    Task UpdateAppointmentAsync(AppointmentDto appointment);
    Task CancelAppointmentAsync(Guid id);
}
