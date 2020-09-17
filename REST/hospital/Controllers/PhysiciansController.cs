using System.Collections.Generic;
using AutoMapper;
using hospital.Data;
using hospital.Dtos;
using hospital.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace hospital.Controllers
{
    [Route("api/physicians")]
    [ApiController]
    public class PhysiciansController : ControllerBase
    {
        private readonly IHospitalRepo _repository;
        private readonly IMapper _mapper;

        public PhysiciansController(IHospitalRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        //GET api/physicians
        [HttpGet]
        public ActionResult<IEnumerable<Physician>> GetAllPhysicians(string searchString)
        {
            var physicianItems = _repository.GetAllPhyisicans(searchString);

            return Ok(_mapper.Map<IEnumerable<PhysicianReadDto>>(physicianItems));
        }

        //GET api/physicians/{id}
        [HttpGet("{id}", Name = "GetPhysicianById")]
        public ActionResult<Physician> GetPhysicianById(int id)
        {
            var physicianItem = _repository.GetPhysicianById(id);

            if (physicianItem != null)
            {
                return Ok(_mapper.Map<PhysicianReadDto>(physicianItem));
            }

            return NotFound();
        }

        //POST api/physicians
        [HttpPost]
        public ActionResult<PhysicianCreateDto> CreatePhysician(PhysicianCreateDto physicianCreateDto)
        {
            var physicianModel = _mapper.Map<Physician>(physicianCreateDto);
            _repository.CreatePhysician(physicianModel);
            _repository.SaveChanges();

            var physicianReadDto = _mapper.Map<PhysicianReadDto>(physicianModel);

            return CreatedAtRoute(nameof(GetPhysicianById), new { Id = physicianReadDto.EmployeeId }, physicianReadDto);
        }

        //PUT api/physicians
        [HttpPut("{id}")]
        public ActionResult UpdatePhysician(int id, PhysicianUpdateDto physicianUpdateDto)
        {
            var physicianModelFromRepo = _repository.GetPhysicianById(id);
            if (physicianModelFromRepo == null)
            {
                return NotFound();
            }

            _mapper.Map(physicianUpdateDto, physicianModelFromRepo);

            _repository.UpdatePhysician(physicianModelFromRepo);

            _repository.SaveChanges();

            return NoContent();
        }

        //PATCH api/physicians/{id}
        [HttpPatch("{id}")]
        public ActionResult PartialCommandUpdate(int id, JsonPatchDocument<PhysicianUpdateDto> patchDoc)
        {
            var physicianModelFromRepo = _repository.GetPhysicianById(id);
            if (physicianModelFromRepo == null)
            {
                return NotFound();
            }

            var physicianToPatch = _mapper.Map<PhysicianUpdateDto>(physicianModelFromRepo);
            patchDoc.ApplyTo(physicianToPatch, ModelState);

            if (!TryValidateModel(physicianToPatch))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(physicianToPatch, physicianModelFromRepo);

            _repository.UpdatePhysician(physicianModelFromRepo);

            _repository.SaveChanges();

            return NoContent();
        }

        //DELETE api/physicians/{id}
        [HttpDelete("{id}")]
        public ActionResult DeletePhysician(int id)
        {
            var physicianModelFromRepo = _repository.GetPhysicianById(id);
            if (physicianModelFromRepo == null)
            {
                return NotFound();
            }

            _repository.DeletePhysician(physicianModelFromRepo);

            _repository.SaveChanges();

            return NoContent();
        }
    }
}