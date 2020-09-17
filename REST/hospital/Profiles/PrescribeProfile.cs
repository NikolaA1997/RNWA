using AutoMapper;
using hospital.Dtos;
using hospital.Models;

namespace hospital.Profiles
{
    public class PrescribeProfile : Profile
    {
        public PrescribeProfile()
        {
            CreateMap<Prescribes, PrescribeReadDto>();
        }
    }
}