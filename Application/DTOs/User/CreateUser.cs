﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.User
{
    public class CreateUser
    {
        public string NameSurname { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }

        public string Password { get; set; }
    }
}
