using AutoMapper;
using hospital.Dtos;
using hospital.Models;

namespace hospital.Profiles
{
    public class PatientsProfile : Profile
    {
        public PatientsProfile()
        {
            CreateMap<Patient, PatientReadDto>();
        }
    }
}