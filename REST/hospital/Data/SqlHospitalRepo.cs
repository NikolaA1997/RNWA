using System;
using System.Collections.Generic;
using System.Linq;
using hospital.Models;
using Microsoft.EntityFrameworkCore;

namespace hospital.Data
{
    public class SqlHospitalRepo : IHospitalRepo
    {
        private readonly HospitalContext _context;

        public SqlHospitalRepo(HospitalContext context)
        {
            _context = context;
        }

        public void CreatePhysician(Physician phy)
        {
            if (phy == null)
            {
                throw new ArgumentNullException(nameof(phy));
            }

            _context.Physician.Add(phy);
        }

        public void DeletePhysician(Physician phy)
        {
            if (phy == null)
            {
                throw new ArgumentNullException(nameof(phy));
            }

            _context.Physician.Remove(phy);
        }

        public IEnumerable<Physician> GetAllPhyisicans(string searchString)
        {
            if (!String.IsNullOrEmpty(searchString))
            {
                return _context.Physician.Where(p => p.Name.Contains(searchString)).ToList();
            }

            return _context.Physician.ToList();
        }

        public Physician GetPhysicianById(int id)
        {
            return _context.Physician.FirstOrDefault(p => p.EmployeeId == id);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void UpdatePhysician(Physician phy)
        {
            //Nothing
        }

        public Appointment GetAppointmentByPhysicianId(int physicianId)
        {
            return _context.Appointment.Where(a => a.Physician == physicianId)
                                       .Include(ap => ap.Patient)
                                       .Include(ap => ap.Prescribes)
                                       .FirstOrDefault();
        }

        public IEnumerable<Patient> GetAllPatients()
        {
             return _context.Patient.ToList();
        }

        public Patient GetPatientBySsn(int ssn)
        {
            return _context.Patient.FirstOrDefault(p => p.Ssn == ssn);
        }

        public void CreatePatient(Patient pat)
        {
            if (pat == null)
            {
                throw new ArgumentNullException(nameof(pat));
            }

            _context.Patient.Add(pat);
        }
    }
}