using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tema.Models.ViewModels
{
    public class PaymentVM
    {
        public Payment Payment { get; set; }
        [ValidateNever]
        public IEnumerable<SelectListItem> ParentList { get; set; }
        public List<Child> Children { get; set; } = new List<Child>();
        public int ChildCount { get; set; }
        public decimal CalculatedAmount { get; set; }
        public List<Payment> PaymentHistory { get; set; }
    }
}
