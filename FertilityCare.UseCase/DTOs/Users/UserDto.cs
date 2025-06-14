﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FertilityCare.UseCase.DTOs.Users
{
    public class UserDto
    {
        public Guid Id { get; set; }
        
        public string Email { get; set; } = string.Empty;

        public string FirstName { get; set; } = string.Empty;

        public string MiddleName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;

        public string AvatarUrl { get; set; }=  string.Empty;
    }
}
