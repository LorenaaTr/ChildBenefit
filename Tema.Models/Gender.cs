using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Tema.Models
{
    public class Gender
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Pershkrimi gjinis ne gjuhen shqipe eshte i detyrueshem.")]
        [DisplayName("Pershkrimi gjinis")]
        public string AlDescription { get; set; }
        public string EnDescription { get; set; }
        public string SrDescription { get; set; }
    }
}
