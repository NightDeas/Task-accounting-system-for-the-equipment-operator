using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace Api.Models.Requests
{
    public class TaskRequest
    {
        //[Required(ErrorMessage = "field 'Description' requeired")]
        public string Description { get; set; }
        [Required(ErrorMessage = "field 'EmployeeId' requeired")]
        public Guid EmployeeId { get; set; }
        [Required(ErrorMessage = "field 'DeadLine' requeired")]
        public DateTime DeadLine { get; set; }
        [Required(ErrorMessage = "field 'IsCompleted' requeired")]
        public bool IsCompleted { get; set; }
    }
}
