using AutoMapper;
using MindCare.BLL.DTOs;
using MindCare.DAL.Entities;

namespace MindCare.BLL.Mapping;
public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<User, UserDto>().ReverseMap();
        CreateMap<Appointment, AppointmentDto>().ReverseMap();
        CreateMap<Specialist, SpecialistDto>().ReverseMap();
        CreateMap<Review, ReviewDto>().ReverseMap();
    }
}
