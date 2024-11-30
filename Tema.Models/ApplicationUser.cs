﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
        [NotMapped]
        public string Role { get; set; }
    }
}
