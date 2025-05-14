using Microsoft.EntityFrameworkCore;
using MindCare.DAL.Abstraction;
using MindCare.DAL.Context;
using MindCare.DAL.Entities;

namespace MindCare.DAL.Repositories;
public class AppointmentRepository : IRepository<Appointment>
{
    private readonly MindCareDbContext _dbContext;

    public AppointmentRepository(MindCareDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task AddAsync(Appointment entity)
    {
        await _dbContext.Appointments.AddAsync(entity);
    }

    public IQueryable<Appointment> GetAll()
    {
        return _dbContext.Appointments.AsNoTracking();
    }

    public async Task<Appointment?> GetByIdAsync(Guid id)
    {
        return await _dbContext.Appointments.FindAsync(id);
    }

    public void Remove(Appointment entity)
    {
        _dbContext.Appointments.Remove(entity);
    }

    public void Update(Appointment entity)
    {
        _dbContext.Appointments.Update(entity);
    }
}
