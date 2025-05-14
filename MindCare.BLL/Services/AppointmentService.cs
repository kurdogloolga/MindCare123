using Microsoft.EntityFrameworkCore;
using MindCare.BLL.Abstraction;
using MindCare.DAL.Abstraction;
using AutoMapper;
using MindCare.BLL.DTOs;
using MindCare.DAL.Entities;

namespace MindCare.BLL.Services;
public class AppointmentService : IAppointmentService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public AppointmentService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<IEnumerable<AppointmentDto>> GetAllAppointmentsAsync()
    {
        var appointments = await _unitOfWork.Appointments.GetAll()
            .ToListAsync();
        return _mapper.Map<IEnumerable<AppointmentDto>>(appointments);
    }

    public async Task<AppointmentDto> GetAppointmentByIdAsync(Guid id)
    {
        var appointment = await _unitOfWork.Appointments.GetByIdAsync(id);
        return _mapper.Map<AppointmentDto>(appointment);
    }

    public async Task<IEnumerable<AppointmentDto>> GetAppointmentsByUserAsync(Guid userId)
    {
        var appointments = await _unitOfWork.Appointments.GetAll()
            .Where(a => a.UserId == userId)
            .ToListAsync();
        return _mapper.Map<IEnumerable<AppointmentDto>>(appointments);
    }

    public async Task<IEnumerable<AppointmentDto>> GetAppointmentsBySpecialistAsync(Guid specialistId)
    {
        var appointments = await _unitOfWork.Appointments.GetAll()
            .Where(a => a.SpecialistId == specialistId)
            .ToListAsync();
        return _mapper.Map<IEnumerable<AppointmentDto>>(appointments);
    }

    public async Task<Guid> BookAppointmentAsync(AppointmentDto appointmentDto)
    {
        var appointment = _mapper.Map<Appointment>(appointmentDto);
        await _unitOfWork.Appointments.AddAsync(appointment);
        await _unitOfWork.CommitAsync();
        return appointment.Id;
    }

    public async Task UpdateAppointmentAsync(AppointmentDto appointmentDto)
    {
        var appointment = _mapper.Map<Appointment>(appointmentDto);
        _unitOfWork.Appointments.Update(appointment);
        await _unitOfWork.CommitAsync();
    }

    public async Task CancelAppointmentAsync(Guid id)
    {
        var appt = await _unitOfWork.Appointments.GetByIdAsync(id);
        _unitOfWork.Appointments.Remove(appt);
        await _unitOfWork.CommitAsync();
    }
}