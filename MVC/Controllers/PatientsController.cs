using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVC.Models;

namespace MVC.Controllers
{
    public class PatientsController : Controller
    {
        private readonly hospital_rnwaContext _context;

        public PatientsController(hospital_rnwaContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<Patient> GetAllPatients()
        {
            return _context.Patient.Include(p => p.PcpNavigation).ToList();
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreatePatient(Patient patient)
        {
            try
            {
                _context.Patient.Add(patient);
                _context.SaveChanges();
                return StatusCode(204);
            }
            catch (Exception e)
            {
                return StatusCode(400, new { message = e });
            }
        }

        public IActionResult Update(int id)
        {
            var patient = _context.Patient.Where(x => x.Ssn == id).FirstOrDefault();

            return View(patient);
        }


        [HttpPut]
        public ActionResult UpdatePatient(Patient patient)
        {
            try
            {
                _context.Patient.Update(patient);
                _context.SaveChanges();
                return StatusCode(200, new { message = "Patient successfully updated." });
            }
            catch (Exception e)
            {
                return StatusCode(400, new { message = e.Message });
            }
        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            var patient = _context.Patient.Where(x => x.Ssn == id).FirstOrDefault();
            try
            {
                _context.Patient.Remove(patient);
                _context.SaveChanges();
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
