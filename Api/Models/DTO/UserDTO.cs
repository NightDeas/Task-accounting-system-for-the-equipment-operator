﻿namespace Api.Models.DTO
{
    public class UserDTO
    {
        public Guid Id { get; set;}
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string? Patronymic { get; set; }
        public string Login { get; set; }
    }
}
