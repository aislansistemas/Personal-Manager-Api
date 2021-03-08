using PersonalManagement.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalManagement.Api.ViewModel
{
    public class ControlPointViewModel : ViewModel
    {
        public int Id { get; set; }
        public string ApplicationUserId { get; set; }
        public TimeSpan HourInputOne { get; set; }
        public TimeSpan HourExitOne { get; set; }
        public TimeSpan HourInputTwo { get; set; }
        public TimeSpan HourExitTwo { get; set; }
        public int TotalHours { get; set; }
        public DateTime Date { get; set; }
        public decimal HourValue { get; set; }
        public virtual UserAccount ApplicationUser { get; set; }
    }
}
