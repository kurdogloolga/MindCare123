﻿using MindCare.DAL.Entities.Enums;

namespace MindCare.BLL.DTOs
{
    public class UserDto
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public DateOnly Birthday { get; set; }
        public Gender Gender { get; set; }
    }
}
