namespace Api.Models.Entities
{
    public partial class Employee
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public virtual User User { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string? Patronymic { get; set; }

        public ICollection<Task> Tasks { get; set; }
    }
}
