using Microsoft.EntityFrameworkCore;
using MindCare.DAL.Context;
using MindCare.DAL.Entities;
using MindCare.DAL.Interfaces;

namespace MindCare.DAL.Repositories
{
    public class AppointmentRepository : IAppointmentRepository
    {
        private readonly MindCareDbContext _context;

        public AppointmentRepository(MindCareDbContext context)
        {
            _context = context;
        }

        public async Task<Appointment> GetByIdAsync(Guid id)
        {
            return await _context.Appointments
                .Include(a => a.User)
                .Include(a => a.Specialist)
                .FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task<IEnumerable<Appointment>> GetAllAsync()
        {
            return await _context.Appointments
                .Include(a => a.User)
                .Include(a => a.Specialist)
                .ToListAsync();
        }

        public async Task AddAsync(Appointment appointment)
        {
            await _context.Appointments.AddAsync(appointment);
        }

        public void Update(Appointment appointment)
        {
            _context.Appointments.Update(appointment);
        }

        public async Task DeleteAsync(Guid id)
        {
            var appointment = await GetByIdAsync(id);
            if (appointment != null)
            {
                _context.Appointments.Remove(appointment);
            }
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
