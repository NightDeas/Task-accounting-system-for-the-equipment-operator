using System.ComponentModel.DataAnnotations;
using Api.Models.Entities;

namespace Api.Models.Requests
{
    public class EmployeeRequest
    {
        [Required]
        public Guid UserId { get; set; }
        [Required]
        [MinLength(5)]
        [MaxLength(255)]
        public string LastName { get; set; }
        [Required]
        [MinLength(5)]
        [MaxLength(255)]
        public string FirstName { get; set; }
        [MaxLength(255)]
        public string? Patronymic { get; set; }
    }
}
