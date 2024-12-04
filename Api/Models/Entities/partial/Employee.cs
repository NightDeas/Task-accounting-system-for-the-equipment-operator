namespace Api.Models.Entities
{
    public partial class Employee
    {
        public string FullName => string.IsNullOrEmpty(Patronymic) ? $"{LastName} {FirstName}" : $"{LastName} {FirstName} {Patronymic}";

    }
}
