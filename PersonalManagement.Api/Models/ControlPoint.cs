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
        public DateTime HourInputOne { get; set; }
        public DateTime HourExitOne { get; set; }
        public DateTime HourInputTwo { get; set; }
        public DateTime HourExitTwo { get; set; }
        public int TotalHours { get; set; }
        public DateTime Date { get; set; }
        public decimal HourValue { get; set; }
        public virtual UserAccount ApplicationUser { get; set; }
    }
}
