using System.Collections.Generic;
using hospital.Models;

namespace hospital.Data
{
    public interface IHospitalRepo
    {
        bool SaveChanges();
        IEnumerable<Physician> GetAllPhyisicans(string searchString);
        Physician GetPhysicianById(int id);
        void CreatePhysician(Physician pyh);
        void UpdatePhysician(Physician phy);
        void DeletePhysician(Physician phy);
        Appointment GetAppointmentByPhysicianId(int phycianId);
        IEnumerable<Patient> GetAllPatients();
        Patient GetPatientBySsn(int ssn);
        void CreatePatient(Patient pyh);
    }
}