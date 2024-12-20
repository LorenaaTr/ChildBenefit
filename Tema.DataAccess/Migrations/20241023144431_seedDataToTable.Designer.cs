﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using tema.Data;

#nullable disable

namespace tema.DataAccess.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20241023144431_seedDataToTable")]
    partial class seedDataToTable
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("tema.Models.Country", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("AlDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EnDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SrDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Countries");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AlDescription = "Kosova",
                            EnDescription = "Kosovo",
                            SrDescription = "Kosovo"
                        });
                });

            modelBuilder.Entity("tema.Models.Criteria", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("AlDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EnDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SrDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Criteria");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AlDescription = "Nene e nje ose dy femijeve",
                            EnDescription = "Mother of one or two children",
                            SrDescription = "Majka jednog ili dvoje dece"
                        },
                        new
                        {
                            Id = 2,
                            AlDescription = "Nene e tre apo me shume femijeve",
                            EnDescription = "Mother of three or more children",
                            SrDescription = "Majka troje ili više dece"
                        });
                });

            modelBuilder.Entity("tema.Models.Gender", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("AlDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EnDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SrDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Genders");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AlDescription = "Femer",
                            EnDescription = "Female",
                            SrDescription = "Zensko"
                        },
                        new
                        {
                            Id = 2,
                            AlDescription = "Mashkull",
                            EnDescription = "Male",
                            SrDescription = "Muski"
                        },
                        new
                        {
                            Id = 3,
                            AlDescription = "Te tjera",
                            EnDescription = "Others",
                            SrDescription = "Drugi"
                        });
                });

            modelBuilder.Entity("tema.Models.Language", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("AlDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EnDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SrDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Languages");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AlDescription = "Gjuhe Shqipe",
                            EnDescription = "Albanian",
                            SrDescription = "Albanski"
                        },
                        new
                        {
                            Id = 2,
                            AlDescription = "Gjuhe Angleze",
                            EnDescription = "English",
                            SrDescription = "Engleski"
                        },
                        new
                        {
                            Id = 3,
                            AlDescription = "Gjuhe Serbe",
                            EnDescription = "Serbian",
                            SrDescription = "Srpski"
                        },
                        new
                        {
                            Id = 4,
                            AlDescription = "Gjuhe Rome",
                            EnDescription = "Rome",
                            SrDescription = "Rome"
                        },
                        new
                        {
                            Id = 5,
                            AlDescription = "Gjuhe Boshnjake",
                            EnDescription = "Bosnian",
                            SrDescription = "Bosanski"
                        },
                        new
                        {
                            Id = 6,
                            AlDescription = "Gjuhe Turke",
                            EnDescription = "Turkish",
                            SrDescription = "Turski"
                        },
                        new
                        {
                            Id = 7,
                            AlDescription = "Te tjera",
                            EnDescription = "Others",
                            SrDescription = "Drugi"
                        });
                });

            modelBuilder.Entity("tema.Models.MaritalStatus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("AlDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EnDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SrDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("MaritalStatus");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AlDescription = "I/E martuar",
                            EnDescription = "Married",
                            SrDescription = "Ozenjen"
                        },
                        new
                        {
                            Id = 2,
                            AlDescription = "I/E divorcuar",
                            EnDescription = "Divorced",
                            SrDescription = "Razveden"
                        },
                        new
                        {
                            Id = 3,
                            AlDescription = "I/E ve",
                            EnDescription = "Widow",
                            SrDescription = "Udovica"
                        },
                        new
                        {
                            Id = 4,
                            AlDescription = "Beqare",
                            EnDescription = "Single",
                            SrDescription = "Samac"
                        });
                });

            modelBuilder.Entity("tema.Models.Nationality", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("AlDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EnDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SrDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Nationalities");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AlDescription = "Shqiptare",
                            EnDescription = "Albanian",
                            SrDescription = "Albanski"
                        },
                        new
                        {
                            Id = 2,
                            AlDescription = "Turk",
                            EnDescription = "Turkish",
                            SrDescription = "Albanski"
                        },
                        new
                        {
                            Id = 3,
                            AlDescription = "Ashkali",
                            EnDescription = "Ashkali",
                            SrDescription = "Ashkali"
                        },
                        new
                        {
                            Id = 4,
                            AlDescription = "Rom",
                            EnDescription = "Rom",
                            SrDescription = "Rom"
                        },
                        new
                        {
                            Id = 5,
                            AlDescription = "Egjiptian",
                            EnDescription = "Egjiptian",
                            SrDescription = "Egjiptian"
                        },
                        new
                        {
                            Id = 6,
                            AlDescription = "Boshnjak",
                            EnDescription = "Boshnjak",
                            SrDescription = "Boshnjak"
                        },
                        new
                        {
                            Id = 7,
                            AlDescription = "Goran",
                            EnDescription = "Goran",
                            SrDescription = "Goran"
                        },
                        new
                        {
                            Id = 8,
                            AlDescription = "Serb",
                            EnDescription = "Serb",
                            SrDescription = "Serb"
                        });
                });

            modelBuilder.Entity("tema.Models.Region", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("AlDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EnDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SrDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Regions");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AlDescription = "Prishtina",
                            EnDescription = "Pristina",
                            SrDescription = "Pristina"
                        },
                        new
                        {
                            Id = 2,
                            AlDescription = "Mitrovica",
                            EnDescription = "Mitrovica",
                            SrDescription = "Mitrovica"
                        },
                        new
                        {
                            Id = 3,
                            AlDescription = "Peja",
                            EnDescription = "Peja",
                            SrDescription = "Peja"
                        },
                        new
                        {
                            Id = 4,
                            AlDescription = "Prizren",
                            EnDescription = "Prizren",
                            SrDescription = "Prizren"
                        },
                        new
                        {
                            Id = 5,
                            AlDescription = "Ferizaj",
                            EnDescription = "Ferizaj",
                            SrDescription = "Ferizaj"
                        },
                        new
                        {
                            Id = 6,
                            AlDescription = "Gjilan",
                            EnDescription = "Gjilan",
                            SrDescription = "Gjilan"
                        },
                        new
                        {
                            Id = 7,
                            AlDescription = "Gjakova",
                            EnDescription = "Gjakova",
                            SrDescription = "Gjakova"
                        });
                });

            modelBuilder.Entity("tema.Models.Relation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("AlDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EnDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SrDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Relations");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AlDescription = "Femije",
                            EnDescription = "Child",
                            SrDescription = "Deco"
                        },
                        new
                        {
                            Id = 2,
                            AlDescription = "Prind/Kujdestar",
                            EnDescription = "Parent/ Custodian",
                            SrDescription = "Roditejl"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
