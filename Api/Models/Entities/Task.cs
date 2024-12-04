namespace Api.Models.Entities
{
    public class Task
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public Guid EmployeeId { get; set; }
        public Entities.Employee Employee { get; set; }
        public DateTime Created { get; set; } = DateTime.Now;
        public DateTime DeadLine { get; set; }
        public bool IsCompleted { get; set; } = false;

    }
}
