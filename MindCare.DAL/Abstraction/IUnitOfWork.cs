using MindCare.DAL.Entities;

namespace MindCare.DAL.Abstraction;
public interface IUnitOfWork : IDisposable
{
    IRepository<Specialist> Specialists { get; }
    IRepository<Appointment> Appointments { get; }
    IRepository<Availability> Availabilities { get; }
    IRepository<Review> Reviews { get; }
    Task<int> CommitAsync();
}
