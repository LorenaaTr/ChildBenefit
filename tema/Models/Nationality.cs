using System.ComponentModel.DataAnnotations;

namespace tema.Models
{
    public class Nationality
    {
        public int Id { get; set; }
        [Required]
        public string AlDescription { get; set; }
        public string EnDescription { get; set; }
        public string SrDescription { get; set; }
    }
}
