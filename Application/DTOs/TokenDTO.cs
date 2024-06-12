﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class TokenDTO
    {
        public string AccessToken { get; set; }
        public string Name { get; set; }
        public DateTime AccessTokenExpiration { get; set; }

        public string RefreshToken { get; set; }

    }
}
