using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlueCatBackEnd.Dtos.User
{
    public class GetUserDto
    {
        public string UserId { get; set; } = "Guest";
        public string Password { get; set; } = "Password";
        public AccountCategory ActType { get; set; } = 1;
    }
}