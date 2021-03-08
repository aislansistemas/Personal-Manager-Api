using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalManagement.Api.Models
{
    public class PersonalFinance
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("ApplicationUserId")]
        public string ApplicationUserId { get; set; }
        public string Titulo { get; set; }
        public DateTime DataUso { get; set; }
        public decimal Valor { get; set; }
        public virtual UserAccount ApplicationUser { get; set; }
    }
}
