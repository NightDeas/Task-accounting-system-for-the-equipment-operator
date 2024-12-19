using Api.Models.DTO;

namespace Api.Models.Responses
{
    public class TaskResponse
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public DateTime Created { get; set; }
        public DateTime DeadLine { get; set; }
        public bool IsCompleted { get; set; }
        public Guid EmployeeId { get; set; }
        public EmployeeDTO Employee { get; set; }
    }
}
