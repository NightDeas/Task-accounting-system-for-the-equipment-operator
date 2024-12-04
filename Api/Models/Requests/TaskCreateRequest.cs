using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace Api.Models.Requests
{
    public class TaskCreateRequest
    {
        [Required]
        public string Description { get; set; }
        [Required]
        public Guid EmployeeId { get; set; }
        [Required]
        public DateTime DeadLine { get; set; }
    }
}
