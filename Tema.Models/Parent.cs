using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tema.Models
{
    public class Parent
    {
        [Key]
        public int IdParent { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        [MaxLength(50)]
        public string Surname { get; set; }

        [MaxLength(50)]
        public string MaidenName { get; set; }

        [Required]
        [MaxLength(10)]
        public string PersonalNo { get; set; }

        [Required]
        public DateTime DateOfBirth { get; set; }

        [Required]
        [MaxLength(100)]
        public string Address { get; set; }

        [Required]
        [MaxLength(15)]
        public string ContactNumber { get; set; }

        [MaxLength(50)]
        public string Email { get; set; }
        [Required]
        [MaxLength(20)]
        public string BankAccountNumber { get; set; }

        public int BankId { get; set; }
        [ForeignKey("BankId")]
        public Bank Bank { get; set; }

        public int CountryId { get; set; }
        [ForeignKey("CountryId")]
        public Country Country { get; set; }

        public int CriteriaId { get; set; }
        [ForeignKey("CriteriaId")]
        public Criteria Criteria { get; set; }

        public int GenderId { get; set; }
        [ForeignKey("GenderId")]
        public Gender Gender { get; set; }

        public int LanguageId { get; set; }
        [ForeignKey("LanguageId")]
        public Language Language { get; set; }

        public int MaritalStatusId { get; set; }
        [ForeignKey("MaritalStatusId")]
        public MaritalStatus MaritalStatus { get; set; }

        public int NationalityId { get; set; }
        [ForeignKey("NationalityId")]
        public Nationality Nationality { get; set; }

        public int RegionId { get; set; }
        [ForeignKey("RegionId")]
        public Region Region { get; set; }

        public int RelationId { get; set; }
        [ForeignKey("RelationId")]
        public Relation Relation { get; set; }

  

    }
}
