using System.ComponentModel.DataAnnotations;

namespace EmployeeAPI.DTO
{
    public class EmployeeCreateDTO
    {
        [Required]
        public int? Id { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        public string? Department { get; set; }
        [EmailAddress]
        public string? Email { get; set; }
        [Phone]
        public string? Phone { get; set; }
        [Required]
        public string? Designation { get; set; }
        [Required]
        public bool? IsActive { get; set; }
        [Required]
        public int? Exp { get; set; }
    }
}
