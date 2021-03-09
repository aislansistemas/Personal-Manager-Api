using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalManagement.Api.Models
{
    public class ControlPoint
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("ApplicationUserId")]
        public string ApplicationUserId { get; set; }
        public TimeSpan HourInputOne { get; set; } = new TimeSpan();
        public TimeSpan HourExitOne { get; set; } = new TimeSpan();
        public TimeSpan HourInputTwo { get; set; } = new TimeSpan();
        public TimeSpan HourExitTwo { get; set; } = new TimeSpan();
        public int TotalHours { get; set; }
        public DateTime Date { get; set; }
        public decimal HourValue { get; set; }
        public virtual UserAccount ApplicationUser { get; set; }
    }
}
