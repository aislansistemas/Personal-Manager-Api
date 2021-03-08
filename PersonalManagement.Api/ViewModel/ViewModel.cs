using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalManagement.Api.ViewModel
{
    public abstract class ViewModel
    {
        public int Limit { get; set; }
        public int OffSet { get; set; }
        public int Total { get; set; }
    }
}
