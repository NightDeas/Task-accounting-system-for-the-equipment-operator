using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace Api.Models.Requests
{
    public class TaskRequest
    {
        [Required]
        public string Description { get; set; }
        [Required]
        public Guid EmployeeId { get; set; }
        [Required]
        public DateTime DeadLine { get; set; }
        [Required]
        public bool IsCompleted { get; set; }
    }
}
