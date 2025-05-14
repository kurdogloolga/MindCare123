using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MindCare.BLL.Abstraction;
using MindCare.BLL.DTOs;
using MindCare.DAL.Abstraction;
using MindCare.DAL.Entities;

namespace MindCare.BLL.Services;
public class SpecialistService : ISpecialistService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public SpecialistService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }


    public async Task<IEnumerable<SpecialistDto>> GetAllSpecialistsAsync()
    {
        var specialists = _unitOfWork.Specialists.GetAll();
        return _mapper.Map<IEnumerable<SpecialistDto>>(specialists);
    }

    public async Task<SpecialistDto> GetSpecialistByIdAsync(Guid id)
    {
        var specialist = await _unitOfWork.Specialists.GetByIdAsync(id);
        return _mapper.Map<SpecialistDto>(specialist);
    }

    public async Task<Guid> CreateSpecialistAsync(Specialist specialist)
    {
        await _unitOfWork.Specialists.AddAsync(specialist);
        await _unitOfWork.CommitAsync();
        return specialist.Id;
    }

    public async Task UpdateSpecialistAsync(Specialist specialist)
    {
        _unitOfWork.Specialists.Update(specialist);
        await _unitOfWork.CommitAsync();
    }

    public async Task DeleteSpecialistAsync(Guid id)
    {
        var specialist = await _unitOfWork.Specialists.GetByIdAsync(id);
        _unitOfWork.Specialists.Remove(specialist);
        await _unitOfWork.CommitAsync();
    }
}
