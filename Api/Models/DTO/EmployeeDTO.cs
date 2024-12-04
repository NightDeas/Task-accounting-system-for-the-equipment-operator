using Api.Models.Entities;

namespace Api.Models.DTO
{
    public class EmployeeDTO
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string? Patronymic { get; set; }
    }
}
