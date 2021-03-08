using Microsoft.AspNetCore.Identity;
using PersonalManagement.Api.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalManagement.Api.Models
{
    public class UserAccount : IdentityUser
    {
        public string Name { get; set; }
        public string Role { get; set; }
        public IList<ControlPoint> ControlPoints { get; set; }
        public IList<PersonalFinance> PersonalFinances { get; set; }
    }
}
