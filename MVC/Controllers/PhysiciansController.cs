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
    public class PhysiciansController : Controller
    {
        private readonly hospital_rnwaContext _context;

        public PhysiciansController(hospital_rnwaContext context)
        {
            _context = context;
        }

        public IEnumerable<Physician> GetAllPhysicians(string searchString)
        {
            if (!String.IsNullOrEmpty(searchString))
            {
                return _context.Physician.Where(p => p.Name.Contains(searchString)).ToList();
            }

            return _context.Physician.ToList();
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
        public ActionResult CreatePhysician(Physician physician)
        {
            try
            {
                _context.Physician.Add(physician);
                _context.SaveChanges();
                return StatusCode(204);
            }
            catch (Exception e)
            {
                return StatusCode(400, new { message = e.Message });
            }
        }
        public IActionResult Update(int id)
        {
            var physician = _context.Physician.Where(x => x.EmployeeId == id).FirstOrDefault();

            return View(physician);
        }

        [HttpPut]
        public ActionResult UpdatePhysician(Physician physician)
        {
            try
            {
                _context.Physician.Update(physician);
                _context.SaveChanges();
                return StatusCode(200, new { message = "Physician successfully updated." });
            }
            catch (Exception e)
            {
                return StatusCode(400, new { message = e.Message });
            }
        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            var physician = _context.Physician.Where(x => x.EmployeeId == id).FirstOrDefault();
            try
            {
                _context.Physician.Remove(physician);
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
