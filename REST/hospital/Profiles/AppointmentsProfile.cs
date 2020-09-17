using AutoMapper;
using hospital.Dtos;
using hospital.Models;

namespace hospital.Profiles
{
    public class AppointmentsProfile : Profile
    {
        public AppointmentsProfile()
        {
            CreateMap<Appointment, AppointmentReadDto>();
        }
    }
}