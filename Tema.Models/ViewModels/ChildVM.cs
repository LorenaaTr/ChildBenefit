using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tema.Models.ViewModels
{
    public class ChildVM
    {
        public Child Child { get; set; }
        [ValidateNever]
        public IEnumerable<SelectListItem> RelationList { get; set; }
        [ValidateNever]
        public IEnumerable<SelectListItem> StatusList { get; set; }
        [ValidateNever]
        public IEnumerable<SelectListItem> ParentList { get; set; }
    }
}
