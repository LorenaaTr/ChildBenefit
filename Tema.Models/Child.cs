    using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    namespace Tema.Models
    {
        public class Child
        {
            [Key]
            public int IdChild { get; set; }

            [Required(ErrorMessage = "Emri është i kërkuar.")]
            [MaxLength(50, ErrorMessage = "Emri nuk mund të kalojë 50 karaktere.")]
            [Display(Name = "Emri i Fëmijës")]
            public string Name { get; set; }

            [Required(ErrorMessage = "Mbiemri është i kërkuar.")]
            [MaxLength(50, ErrorMessage = "Mbiemri nuk mund të kalojë 50 karaktere.")]
            [Display(Name = "Mbiemri i Fëmijës")]
            public string Surname { get; set; }

            [Range(typeof(DateTime), "1/1/2009", "12/31/2024", ErrorMessage = "Data e lindjes eshte e detyrushme.Femijet mbi 16 vjeq nuk mund te aplikojn per shtesat te femijeve!")]
            [Display(Name = "Data e Lindjes")]
            public DateTime DateOfBirth { get; set; }

            [Required(ErrorMessage = "Numri Personal është i kërkuar.")]
            [StringLength(10, MinimumLength = 10, ErrorMessage = "Numri Personal duhet të ketë 10 karaktere.")]
            [Display(Name = "Numri Personal")]
            public string PersonalNo { get; set; }


            // Nullable ApplicationDate
            public DateTime? ApplicationDate { get; set; }

            // Nullable StatusId and RelationId
            public int? StatusId { get; set; }
            [ForeignKey("StatusId")]
            [ValidateNever]
            public Status Status { get; set; }

            public int? RelationId { get; set; }
            [ForeignKey("RelationId")]
            [ValidateNever]
            public Relation Relation { get; set; }

            // Nullable ParentId
            public int? ParentId { get; set; }
            [ForeignKey("ParentId")]
            [ValidateNever]
            public Parent Parent { get; set; }
        }
    }
