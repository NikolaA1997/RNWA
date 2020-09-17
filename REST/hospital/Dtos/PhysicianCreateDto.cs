using System.ComponentModel.DataAnnotations;

namespace hospital.Dtos
{
    public class PhysicianCreateDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Position { get; set; }
        [Required]
        public int Ssn { get; set; }
    }
}
