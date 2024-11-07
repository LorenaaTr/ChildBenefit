﻿using Microsoft.EntityFrameworkCore;
using Tema.Models;

namespace tema.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
        {
            
        }

        public DbSet<Gender> Genders { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Criteria> Criteria { get; set;  }
        public DbSet<Language> Languages { get; set; }
        public DbSet<MaritalStatus> MaritalStatus { get; set; }
        public DbSet<Nationality> Nationalities { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<Relation> Relations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Gender>().HasData(
                new Gender { Id = 1, AlDescription = "Femer", EnDescription = "Female", SrDescription = "Zensko" },
                new Gender { Id = 2, AlDescription = "Mashkull", EnDescription = "Male", SrDescription = "Muski" },
                new Gender { Id = 3, AlDescription = "Te tjera", EnDescription = "Others", SrDescription = "Drugi" }
                );

            modelBuilder.Entity<Country>().HasData(
                new Country { Id = 1, AlDescription = "Kosova", EnDescription = "Kosovo", SrDescription = "Kosovo" }
                );

            modelBuilder.Entity<Criteria>().HasData(
                new Criteria { Id = 1, AlDescription = "Nene e nje ose dy femijeve", EnDescription = "Mother of one or two children", SrDescription = "Majka jednog ili dvoje dece" },
                new Criteria { Id = 2, AlDescription = "Nene e tre apo me shume femijeve", EnDescription = "Mother of three or more children", SrDescription = "Majka troje ili više dece" }
                );
            modelBuilder.Entity<Language>().HasData(
                new Language { Id = 1, AlDescription = "Gjuhe Shqipe", EnDescription = "Albanian", SrDescription = "Albanski"},
                new Language { Id = 2, AlDescription = "Gjuhe Angleze", EnDescription = "English", SrDescription = "Engleski"},
                new Language { Id = 3, AlDescription = "Gjuhe Serbe", EnDescription = "Serbian", SrDescription = "Srpski"},
                new Language { Id = 4, AlDescription = "Gjuhe Rome", EnDescription = "Rome", SrDescription = "Rome"},
                new Language { Id = 5, AlDescription = "Gjuhe Boshnjake", EnDescription = "Bosnian", SrDescription = "Bosanski"},
                new Language { Id = 6, AlDescription = "Gjuhe Turke", EnDescription = "Turkish", SrDescription = "Turski"},
                new Language { Id = 7, AlDescription = "Te tjera", EnDescription = "Others", SrDescription = "Drugi"}
                );
            modelBuilder.Entity<MaritalStatus>().HasData(
                new MaritalStatus { Id = 1, AlDescription = "I/E martuar", EnDescription = "Married", SrDescription = "Ozenjen"},
                new MaritalStatus { Id = 2, AlDescription = "I/E divorcuar", EnDescription = "Divorced", SrDescription = "Razveden"},
                new MaritalStatus { Id = 3, AlDescription = "I/E ve", EnDescription = "Widow", SrDescription = "Udovica"},
                new MaritalStatus { Id = 4, AlDescription = "Beqare", EnDescription = "Single", SrDescription = "Samac" }
                );
            modelBuilder.Entity<Nationality>().HasData(
                new Nationality { Id = 1, AlDescription = "Shqiptare", EnDescription = "Albanian", SrDescription = "Albanski"},
                new Nationality { Id = 2, AlDescription = "Turk", EnDescription = "Turkish", SrDescription = "Albanski"},
                new Nationality { Id = 3, AlDescription = "Ashkali", EnDescription = "Ashkali", SrDescription = "Ashkali" },
                new Nationality { Id = 4, AlDescription = "Rom", EnDescription = "Rom", SrDescription = "Rom" },
                new Nationality { Id = 5, AlDescription = "Egjiptian", EnDescription = "Egjiptian", SrDescription = "Egjiptian" },
                new Nationality { Id = 6, AlDescription = "Boshnjak", EnDescription = "Boshnjak", SrDescription = "Boshnjak" },
                new Nationality { Id = 7, AlDescription = "Goran", EnDescription = "Goran", SrDescription = "Goran" },
                new Nationality { Id = 8, AlDescription = "Serb", EnDescription = "Serb", SrDescription = "Serb" }
                );
            modelBuilder.Entity<Region>().HasData(
                new Region { Id = 01, AlDescription = "Prishtina", EnDescription = "Pristina", SrDescription = "Pristina"},
                new Region { Id = 02, AlDescription = "Mitrovica", EnDescription = "Mitrovica", SrDescription = "Mitrovica" },
                new Region { Id = 03, AlDescription = "Peja", EnDescription = "Peja", SrDescription = "Peja" },
                new Region { Id = 04, AlDescription = "Prizren", EnDescription = "Prizren", SrDescription = "Prizren" },
                new Region { Id = 05, AlDescription = "Ferizaj", EnDescription = "Ferizaj", SrDescription = "Ferizaj" },
                new Region { Id = 06, AlDescription = "Gjilan", EnDescription = "Gjilan", SrDescription = "Gjilan" },
                new Region { Id = 07, AlDescription = "Gjakova", EnDescription = "Gjakova", SrDescription = "Gjakova" }
                );
            modelBuilder.Entity<Relation>().HasData(
                new Relation { Id =  1, AlDescription = "Femije", EnDescription = "Child", SrDescription = "Deco" },
                new Relation { Id =  2, AlDescription = "Prind/Kujdestar", EnDescription = "Parent/ Custodian", SrDescription = "Roditejl" }
           );
        }
       
    }
}