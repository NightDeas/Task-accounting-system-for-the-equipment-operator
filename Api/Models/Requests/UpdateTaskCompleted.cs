using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace Api.Models.Requests
{
    public class UpdateTaskCompleted
    {
        [Required]
        public Guid TaskId { get; set; }
        [Required]
        public bool IsCompleted { get; set; }
    }
}
