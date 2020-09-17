using System.Collections.Generic;
using hospital.Models;

namespace hospital.Dtos
{
    public class PhysicianReadDto
    {
        public int EmployeeId { get; set; }
        public string Name { get; set; }
        public string Position { get; set; }
        public int Ssn { get; set; }
    }
}
