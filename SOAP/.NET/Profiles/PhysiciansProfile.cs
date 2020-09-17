using AutoMapper;
using SOAP.Dtos;
using SOAP.Models;

namespace SOAP.Profiles
{
    public class PhysiciansProfile : Profile
    {
        public PhysiciansProfile()
        {
            CreateMap<Physician, PhysicianReadDto>();
        }
    }
}