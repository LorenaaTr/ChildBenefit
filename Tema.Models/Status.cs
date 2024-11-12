using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tema.Models
{
    public class Status
    {
        [Key]
        public int Id { get; set; }
        public string AlDescription { get; set; }
        public string EnDescription { get; set; }
        public string SrDescription { get; set; }
    }
}
