using AutoMapper;
using MindCare.BLL.DTOs;
using MindCare.BLL.Interfaces;
using MindCare.DAL.Entities;
using MindCare.DAL.Interfaces;

namespace MindCare.BLL.Services
{
    public class AppointmentService : IAppointmentService
    {
        private readonly IAppointmentRepository _appointmentRepository;
        private readonly IMapper _mapper;

        public AppointmentService(IAppointmentRepository appointmentRepository, IMapper mapper)
        {
            _appointmentRepository = appointmentRepository;
            _mapper = mapper;
        }

        public async Task<AppointmentDto> GetByIdAsync(Guid id)
        {
            var appointment = await _appointmentRepository.GetByIdAsync(id);
            return _mapper.Map<AppointmentDto>(appointment);
        }

        public async Task<IEnumerable<AppointmentDto>> GetAllAsync()
        {
            var appointments = await _appointmentRepository.GetAllAsync();
            return appointments.Select(a => _mapper.Map<AppointmentDto>(a));
        }

        public async Task CreateAsync(AppointmentDto appointmentDto)
        {
            var appointment = _mapper.Map<Appointment>(appointmentDto);

            await _appointmentRepository.AddAsync(appointment);
            await _appointmentRepository.SaveChangesAsync();
        }

        public async Task UpdateAsync(AppointmentDto appointmentDto)
        {
            var existing = await _appointmentRepository.GetByIdAsync(appointmentDto.Id);
            if (existing == null)
                throw new Exception("Appointment not found.");

            _mapper.Map(appointmentDto, existing);
            _appointmentRepository.Update(existing);
            await _appointmentRepository.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            await _appointmentRepository.DeleteAsync(id);
            await _appointmentRepository.SaveChangesAsync();
        }
    }
}
