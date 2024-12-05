using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace Tema.Models
{
    public class Payment
    {
        [Key]
        public int IdPayment { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal Amount { get; set; }

        [Required]
        public DateOnly PaymentDate { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public int IdParent { get; set; }

        [ForeignKey("IdParent")]
        [ValidateNever]
        public Parent Parent { get; set; }


    }
}
