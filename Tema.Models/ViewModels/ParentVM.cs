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
    public class ParentVM
    {
        public int IdParent { get; set; }
        public Parent Parent { get; set; }
        [ValidateNever]
        public IEnumerable<SelectListItem> GenderList { get; set; }
        [ValidateNever]
        public IEnumerable<SelectListItem> CountryList { get; set; }
        [ValidateNever]
        public IEnumerable<SelectListItem> LanguageList { get; set; }
        [ValidateNever]
        public IEnumerable<SelectListItem> BankList { get; set; }
        [ValidateNever]
   
        public IEnumerable<SelectListItem> MaritalStatusList { get; set; }
        [ValidateNever]
        public IEnumerable<SelectListItem> NationalityList { get; set; }
        [ValidateNever]
        public IEnumerable<SelectListItem> RegionList { get; set; }
        [ValidateNever]
        public IEnumerable<SelectListItem> RelationList { get; set; }
        [ValidateNever]
        public IEnumerable<SelectListItem> StatusList { get; set; }
        [ValidateNever]
        public IEnumerable<SelectListItem> CriteriaList { get; set; }
        public ICollection<Child> Children { get; set; } = new List<Child>();

    }
}
