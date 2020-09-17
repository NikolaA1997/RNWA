using System.Collections.Generic;
using SOAP.Models;

namespace SOAP.Dtos
{
    public class PhysicianReadDto
    {
        public int EmployeeId { get; set; }
        public string Name { get; set; }
        public string Position { get; set; }
        public int Ssn { get; set; }
    }
}
