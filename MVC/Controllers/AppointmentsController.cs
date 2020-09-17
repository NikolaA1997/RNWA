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
    public class AppointmentsController : Controller
    {
        private readonly hospital_rnwaContext _context;

        public AppointmentsController(hospital_rnwaContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<Appointment> GetAllAppointments()
        {
            return _context.Appointment.Include(a => a.PatientNavigation).Include(a => a.PhysicianNavigation).ToList();
        }

        [HttpGet]
        public IEnumerable<Appointment> GetAppointmentsByPhysicianId([FromQuery(Name = "physicianId")] int physicianId)
        {
            return _context.Appointment.Where(a => a.Physician == physicianId).Include(a => a.PatientNavigation).Include(a => a.PhysicianNavigation).ToList();
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
        public ActionResult CreateAppointment(Appointment appointment)
        {
            Random random = new Random();
            int appointmentId = random.Next(210, 1000);
            try
            {
                appointment.AppointmentId = appointmentId;
                _context.Appointment.Add(appointment);
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
            var appointment = _context.Appointment.Where(x => x.AppointmentId == id).FirstOrDefault();

            return View(appointment);
        }

        [HttpPut]
        public ActionResult UpdateAppointment(Appointment appointment)
        {
            try
            {
                _context.Appointment.Update(appointment);
                _context.SaveChanges();
                return StatusCode(200, new { message = "Appointment successfully updated." });
            }
            catch (Exception e)
            {

                return StatusCode(400, new { message = e.Message });
            }
        }

       
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            var appointment = _context.Appointment.Where(x => x.AppointmentId == id).FirstOrDefault();
            try
            {
                _context.Appointment.Remove(appointment);
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
