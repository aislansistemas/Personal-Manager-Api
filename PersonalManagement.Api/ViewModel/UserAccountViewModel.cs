using PersonalManagement.Api.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalManagement.Api.ViewModel
{
    public class UserAccountViewModel : ViewModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public UserRoleEnum Role { get; set; }
    }
}
