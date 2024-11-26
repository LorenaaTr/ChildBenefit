using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tema.Models
{
    public class Child
    {
        [Key]
        public int IdChild { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        [MaxLength(50)]
        public string Surname { get; set; }

        [Required]
        public DateTime DateOfBirth { get; set; }  

        [Required]
        [MaxLength(10)]
        public string PersonalNo { get; set; }

  
        public DateTime ApplicationDate { get; set; }

        public int StatusId { get; set; }
        [ForeignKey("StatusId")]
        [ValidateNever]
        public Status Status { get; set; }

        public int RelationId { get; set; }
        [ForeignKey("RelationId")]
        [ValidateNever]
        public Relation Relation { get; set; }

    }
}
