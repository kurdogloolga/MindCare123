using MindCare.DAL.Entities;

namespace MindCare.DAL.Interfaces
{
    public interface IAppointmentRepository
    {
        Task<Appointment> GetByIdAsync(Guid id);
        Task<IEnumerable<Appointment>> GetAllAsync();
        Task AddAsync(Appointment appointment);
        void Update(Appointment appointment);
        Task DeleteAsync(Guid id);
        Task<int> SaveChangesAsync();
    }
}
