using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tema.Models
{
    public class Parent
    {
        [Key]
        public int IdParent { get; set; }

        [Required(ErrorMessage = "Emri është i kërkuar.")]
        [MaxLength(50, ErrorMessage = "Emri nuk mund të kalojë 50 karaktere.")]
        [Display(Name = "Emri i Prindit")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Mbiemri është i kërkuar.")]
        [MaxLength(50, ErrorMessage = "Mbiemri nuk mund të kalojë 50 karaktere.")]
        [Display(Name = "Mbiemri i Prindit")]
        public string Surname { get; set; }

        // Nullable MaidenName
        [MaxLength(50, ErrorMessage = "Emri i vajzërisë nuk mund të kalojë 50 karaktere.")]
        [Display(Name = "Emri i Vajzërisë")]
        public string? MaidenName { get; set; }

        [Required(ErrorMessage = "Numri Personal është i kërkuar.")]
        [StringLength(10, MinimumLength = 10, ErrorMessage = "Numri Personal duhet të ketë 10 karaktere.")]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "Numri Personal duhet të përmbajë vetëm numra.")]
        [Display(Name = "Numri Personal")]
        public string PersonalNo { get; set; }


        [Range(typeof(DateTime), "1/1/2009", "12/31/2024", ErrorMessage = "Data e lindjes duhet të jetë midis 1 Janar 2009 dhe 31 Dhjetor 2024.")]
        [Display(Name = "Data e Lindjes")]
        public DateTime? DateOfBirth { get; set; }


        [Required(ErrorMessage = "Adresa është e kërkuar.")]
        [MaxLength(100, ErrorMessage = "Adresa nuk mund të kalojë 100 karaktere.")]
        [Display(Name = "Adresa")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Numri i Kontaktit është i kërkuar.")]
        [MaxLength(15, ErrorMessage = "Numri i Kontaktit nuk mund të kalojë 15 karaktere.")]
        [Display(Name = "Numri i Kontaktit")]
        public string ContactNumber { get; set; }

        // Nullable Email
        [MaxLength(50, ErrorMessage = "Emaili nuk mund të kalojë 50 karaktere.")]
        [EmailAddress(ErrorMessage = "Adresa e Emailit nuk është e saktë.")]
        [Display(Name = "Emaili")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Numri i Llogarisë Bankare është i kërkuar.")]
        [StringLength(16, MinimumLength = 16, ErrorMessage = "Numri Personal duhet të ketë 16 karaktere.")]
        [Display(Name = "Numri i Llogarisë Bankare")]
        public string BankAccountNumber { get; set; }

        // Nullable BankId
        public int? BankId { get; set; }
        [ForeignKey("BankId")]
        [ValidateNever]
        public Bank Bank { get; set; }

        // Nullable CountryId
        public int? CountryId { get; set; }
        [ForeignKey("CountryId")]
        [ValidateNever]
        public Country Country { get; set; }

        // Nullable CriteriaId
        public int? CriteriaId { get; set; }
        [ForeignKey("CriteriaId")]
        [ValidateNever]
        public Criteria Criteria { get; set; }

        // Nullable GenderId
        public int? GenderId { get; set; }
        [ForeignKey("GenderId")]
        [ValidateNever]
        public Gender Gender { get; set; }

        // Nullable LanguageId
        public int? LanguageId { get; set; }
        [ForeignKey("LanguageId")]
        [ValidateNever]
        public Language Language { get; set; }

        // Nullable MaritalStatusId
        public int? MaritalStatusId { get; set; }
        [ForeignKey("MaritalStatusId")]
        [ValidateNever]
        public MaritalStatus MaritalStatus { get; set; }

        // Nullable NationalityId
        public int? NationalityId { get; set; }
        [ForeignKey("NationalityId")]
        [ValidateNever]
        public Nationality Nationality { get; set; }

        // Nullable RegionId
        public int? RegionId { get; set; }
        [ForeignKey("RegionId")]
        [ValidateNever]
        public Region Region { get; set; }

        // Nullable RelationId
        public int? RelationId { get; set; }
        [ForeignKey("RelationId")]
        [ValidateNever]
        public Relation Relation { get; set; }

        // Nullable ApplicationDate
        public DateTime? ApplicationDate { get; set; }

        // Nullable StatusId
        public int? StatusId { get; set; }
        [ForeignKey("StatusId")]
        [ValidateNever]
        public Status Status { get; set; }

    }
}
