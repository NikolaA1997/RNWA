using System.Collections.Generic;
using AutoMapper;
using hospital.Data;
using hospital.Dtos;
using hospital.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace hospital.Controllers
{
    [Route("api/patients")]
    [ApiController]
    public class PatientsController : ControllerBase
    {
        private readonly IHospitalRepo _repository;
        private readonly IMapper _mapper;

        public PatientsController(IHospitalRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

         //GET api/patients
        [HttpGet]
        public ActionResult<IEnumerable<Patient>> GetAllPatients()
        {
            var patientItems = _repository.GetAllPatients();

            return Ok(_mapper.Map<IEnumerable<PatientReadDto>>(patientItems));
        }

        //GET api/patients/{id}
        [HttpGet("{id}", Name = "GetPatientById")]
        public ActionResult<Patient> GetPatientById(int ssn)
        {
            var patientItem = _repository.GetPatientBySsn(ssn);

            if (patientItem != null)
            {
                return Ok(_mapper.Map<PatientReadDto>(patientItem));
            }

            return NotFound();
        }

        //POST api/patients
        [HttpPost]
        public ActionResult<PatientCreateDto> CreatePatient(PatientCreateDto patientCreateDto)
        {
            var patientModel = _mapper.Map<Patient>(patientCreateDto);
            _repository.CreatePatient(patientModel);
            _repository.SaveChanges();

            var patientReadDto = _mapper.Map<PatientReadDto>(patientModel);

            return CreatedAtRoute(nameof(GetPatientById), new { Id = patientReadDto.Ssn }, patientReadDto);
        }
    }
}