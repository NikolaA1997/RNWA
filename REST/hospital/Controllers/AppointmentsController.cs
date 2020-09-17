using System.Collections.Generic;
using AutoMapper;
using hospital.Data;
using hospital.Dtos;
using hospital.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace hospital.Controllers
{
    [Route("api/appointments")]
    [ApiController]
    public class AppointmentsController : ControllerBase
    {
        private readonly IHospitalRepo _repository;
        private readonly IMapper _mapper;

        public AppointmentsController(IHospitalRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        //GET api/appointments/{physicianId}
        [HttpGet("{physicianId}")]
        public ActionResult<Appointment> GetAppointmentByPhysicianId(int physicianId)
        {
            var appointmentItem = _repository.GetAppointmentByPhysicianId(physicianId);

            if (appointmentItem != null)
            {
                return Ok(_mapper.Map<AppointmentReadDto>(appointmentItem));
            }

            return NotFound();
        }
    }
}