using Microsoft.EntityFrameworkCore;
using MindCare.BLL.Abstraction;
using MindCare.DAL.Abstraction;
using MindCare.DAL.Entities;

namespace MindCare.BLL.Services;
public class AvailabilityService : IAvailabilityService
{
    private readonly IUnitOfWork _unitOfWork;

    public AvailabilityService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Availability>> GetAllAvailabilitiesAsync()
    {
        return await _unitOfWork.Availabilities.GetAll()
            .ToListAsync();
    }

    public async Task<Availability> GetAvailabilityByIdAsync(Guid id)
    {
        return await _unitOfWork.Availabilities.GetByIdAsync(id);
    }

    public async Task<IEnumerable<Availability>> GetAvailabilitiesBySpecialistAsync(Guid specialistId, DateTime date)
    {
        return await _unitOfWork.Availabilities
            .GetAll()
            .Where(a => a.SpecialistId == specialistId && a.Date == DateOnly.FromDateTime(date) && !a.IsBooked)
            .ToListAsync();
    }

    public async Task<Guid> CreateAvailabilityAsync(Availability availability)
    {
        await _unitOfWork.Availabilities.AddAsync(availability);
        await _unitOfWork.CommitAsync();
        return availability.Id;
    }

    public async Task UpdateAvailabilityAsync(Availability availability)
    {
        _unitOfWork.Availabilities.Update(availability);
        await _unitOfWork.CommitAsync();
    }

    public async Task DeleteAvailabilityAsync(Guid id)
    {
        var slot = await _unitOfWork.Availabilities.GetByIdAsync(id);
        _unitOfWork.Availabilities.Remove(slot);
        await _unitOfWork.CommitAsync();
    }
}
