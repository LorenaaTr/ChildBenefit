using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tema.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Required]
        public int Name { get; set; }
        [Required]
        public string Surname { get; set; }
    }
}
