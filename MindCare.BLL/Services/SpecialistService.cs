using AutoMapper;
using MindCare.BLL.DTOs;
using MindCare.BLL.Interfaces;
using MindCare.DAL.Entities;
using MindCare.DAL.Interfaces;

namespace MindCare.BLL.Services
{
    public class SpecialistService : ISpecialistService
    {
        private readonly ISpecialistRepository _specialistRepository;
        private readonly IMapper _mapper;

        public SpecialistService(ISpecialistRepository specialistRepository, IMapper mapper)
        {
            _specialistRepository = specialistRepository;
            _mapper = mapper;
        }

        public async Task<SpecialistDto> GetByIdAsync(Guid id)
        {
            var specialist = await _specialistRepository.GetByIdAsync(id);
            return _mapper.Map<SpecialistDto>(specialist);
        }

        public async Task<IEnumerable<SpecialistDto>> GetAllAsync()
        {
            var specialists = await _specialistRepository.GetAllAsync();
            return specialists.Select(s => _mapper.Map<SpecialistDto>(s));
        }

        public async Task CreateAsync(SpecialistDto specialistDto)
        {
            var specialist = _mapper.Map<Specialist>(specialistDto);
            await _specialistRepository.AddAsync(specialist);
            await _specialistRepository.SaveChangesAsync();
        }

        public async Task UpdateAsync(SpecialistDto specialistDto)
        {
            var existingSpecialist = await _specialistRepository.GetByIdAsync(specialistDto.Id);
            if (existingSpecialist == null)
                throw new Exception("Specialist not found.");

            _mapper.Map(specialistDto, existingSpecialist);
            _specialistRepository.Update(existingSpecialist);
            await _specialistRepository.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            await _specialistRepository.DeleteAsync(id);
            await _specialistRepository.SaveChangesAsync();
        }
    }
}
