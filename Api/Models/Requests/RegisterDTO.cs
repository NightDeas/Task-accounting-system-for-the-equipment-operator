using System.ComponentModel.DataAnnotations;

namespace Api.Models.Requests
{
    public class RegisterDTO
    {
        [Required]
        [MinLength(3)]
        public string LastName { get; set; }
        [Required]
        [MinLength(3)]
        public string FirstName { get; set; }
        public string? Patronymic { get; set; }
        [Required]
        [MinLength(6)]
        public string Login { get; set; } = "login1";
        [Required]
        [MinLength(6)]
        public string Password { get; set; } = "123456";
    }
}
