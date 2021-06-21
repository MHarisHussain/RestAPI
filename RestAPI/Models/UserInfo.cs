using System;
using System.Collections.Generic;

namespace RestAPI.Models
{
    public partial class UserInfo
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
    }
}
