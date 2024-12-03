using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using Tema.Models;
using Tema.Models.ViewModels;

public class FamilyVM
{
    public Parent Parent { get; set; }
    [Required(ErrorMessage = "At least one child must be added.")]
    public List<Child> Children { get; set; } = new List<Child>();
    [ValidateNever]
    public IEnumerable<SelectListItem> BankList { get; set; }
    [ValidateNever]
    public IEnumerable<SelectListItem> RelationList { get; set; }
    [ValidateNever]
    public IEnumerable<SelectListItem> StatusList { get; set; }
    [ValidateNever]
    public IEnumerable<SelectListItem> CountryList { get; set; }
    [ValidateNever]
    public IEnumerable<SelectListItem> GenderList { get; set; }
    [ValidateNever]
    public IEnumerable<SelectListItem> MaritalStatusList { get; set; }
    [ValidateNever]
    public IEnumerable<SelectListItem> NationalityList { get; set; }
    [ValidateNever]
    public IEnumerable<SelectListItem> RegionList { get; set; }
    [ValidateNever]
    public IEnumerable<SelectListItem> LanguageList { get; set; }

}
