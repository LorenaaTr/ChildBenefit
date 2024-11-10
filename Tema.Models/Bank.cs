using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Tema.Models
{
    public class Bank
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Emri i bankes eshte i detyrueshem.")]
        [DisplayName("Emri i Bankes")]
        public string BankName { get; set; }
        [Required(ErrorMessage = "Akronimi i bankes eshte i detyrueshem.")]
        [DisplayName("Akronimi i Bankes")]
        public string AkronimiBankes { get; set; }
    }
}
