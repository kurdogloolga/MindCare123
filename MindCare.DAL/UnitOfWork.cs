using Microsoft.EntityFrameworkCore;
using MindCare.DAL.Abstraction;
using MindCare.DAL.Context;
using MindCare.DAL.Entities;
using MindCare.DAL.Repositories;

namespace MindCare.DAL;
public class UnitOfWork : IUnitOfWork
{
    private readonly MindCareDbContext _context;
    private SpecialistRepository _specialists;
    private AppointmentRepository _appointments;
    private AvailabilityRepository _availabilities;
    private ReviewRepository _reviews;

    public UnitOfWork(MindCareDbContext context)
    {
        _context = context;
    }

    public IRepository<Specialist> Specialists => _specialists ??= new SpecialistRepository(_context);
    public IRepository<Appointment> Appointments => _appointments ??= new AppointmentRepository(_context);
    public IRepository<Availability> Availabilities => _availabilities ??= new AvailabilityRepository(_context);
    public IRepository<Review> Reviews => _reviews ??= new ReviewRepository(_context);

    public async Task<int> CommitAsync()
    {
        using var transaction = await _context.Database.BeginTransactionAsync();
        var result = await _context.SaveChangesAsync();
        await transaction.CommitAsync();
        return result;
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}
