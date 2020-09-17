using AutoMapper;
using hospital.Dtos;
using hospital.Models;

namespace hospital.Profiles
{
    public class PhysiciansProfile : Profile
    {
        public PhysiciansProfile()
        {
            CreateMap<Physician, PhysicianReadDto>();
            CreateMap<PhysicianCreateDto, Physician>();
            CreateMap<PhysicianUpdateDto, Physician>();
            CreateMap<Physician, PhysicianUpdateDto>();
        }
    }
}