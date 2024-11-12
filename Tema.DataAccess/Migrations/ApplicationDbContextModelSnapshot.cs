﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using tema.Data;

#nullable disable

namespace tema.DataAccess.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Tema.Models.Bank", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("AkronimiBankes")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BankName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Banks");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AkronimiBankes = "RBKO",
                            BankName = "Raiffeisen Bank"
                        },
                        new
                        {
                            Id = 2,
                            AkronimiBankes = "PCBK",
                            BankName = "ProCredit Bank"
                        },
                        new
                        {
                            Id = 3,
                            AkronimiBankes = "NLB",
                            BankName = "NLB Bank"
                        },
                        new
                        {
                            Id = 4,
                            AkronimiBankes = "TEBK",
                            BankName = "TEB Bank"
                        },
                        new
                        {
                            Id = 5,
                            AkronimiBankes = "BPB",
                            BankName = "BPB Bank"
                        },
                        new
                        {
                            Id = 6,
                            AkronimiBankes = "BEK",
                            BankName = "Banka Ekonomike"
                        },
                        new
                        {
                            Id = 7,
                            AkronimiBankes = "ZIRAAT",
                            BankName = "Ziraat Bank"
                        },
                        new
                        {
                            Id = 8,
                            AkronimiBankes = "KB",
                            BankName = "Komercijalna Banka"
                        });
                });

            modelBuilder.Entity("Tema.Models.Case", b =>
                {
                    b.Property<int>("IdCase")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdCase"));

                    b.Property<DateTime>("ApplicationDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("StatusId")
                        .HasColumnType("int");

                    b.HasKey("IdCase");

                    b.HasIndex("StatusId");

                    b.ToTable("Case");
                });

            modelBuilder.Entity("Tema.Models.Child", b =>
                {
                    b.Property<int>("IdChild")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdChild"));

                    b.Property<DateTime>("ApplicationDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("PersonalNo")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<int>("RelationId")
                        .HasColumnType("int");

                    b.Property<int>("StatusId")
                        .HasColumnType("int");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("IdChild");

                    b.HasIndex("RelationId");

                    b.HasIndex("StatusId");

                    b.ToTable("Children");
                });

            modelBuilder.Entity("Tema.Models.Country", b =>
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

            modelBuilder.Entity("Tema.Models.Criteria", b =>
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

            modelBuilder.Entity("Tema.Models.Gender", b =>
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

            modelBuilder.Entity("Tema.Models.Language", b =>
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

            modelBuilder.Entity("Tema.Models.MaritalStatus", b =>
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

            modelBuilder.Entity("Tema.Models.Nationality", b =>
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

            modelBuilder.Entity("Tema.Models.Parent", b =>
                {
                    b.Property<int>("IdParent")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdParent"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("BankAccountNumber")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<int>("BankId")
                        .HasColumnType("int");

                    b.Property<string>("ContactNumber")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<int>("CountryId")
                        .HasColumnType("int");

                    b.Property<int>("CriteriaId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("GenderId")
                        .HasColumnType("int");

                    b.Property<int>("LanguageId")
                        .HasColumnType("int");

                    b.Property<string>("MaidenName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("MaritalStatusId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("NationalityId")
                        .HasColumnType("int");

                    b.Property<string>("PersonalNo")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<int>("RegionId")
                        .HasColumnType("int");

                    b.Property<int>("RelationId")
                        .HasColumnType("int");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("IdParent");

                    b.HasIndex("BankId");

                    b.HasIndex("CountryId");

                    b.HasIndex("CriteriaId");

                    b.HasIndex("GenderId");

                    b.HasIndex("LanguageId");

                    b.HasIndex("MaritalStatusId");

                    b.HasIndex("NationalityId");

                    b.HasIndex("RegionId");

                    b.HasIndex("RelationId");

                    b.ToTable("Parents");
                });

            modelBuilder.Entity("Tema.Models.Region", b =>
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

            modelBuilder.Entity("Tema.Models.Relation", b =>
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

            modelBuilder.Entity("Tema.Models.Status", b =>
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

                    b.ToTable("Statuses");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AlDescription = "Aktiv",
                            EnDescription = "Active",
                            SrDescription = "Aktivan"
                        },
                        new
                        {
                            Id = 2,
                            AlDescription = "Pasiv",
                            EnDescription = "Passive",
                            SrDescription = "Pasivni"
                        },
                        new
                        {
                            Id = 3,
                            AlDescription = "Nderprere",
                            EnDescription = "Suspended",
                            SrDescription = "Suspendovan"
                        });
                });

            modelBuilder.Entity("Tema.Models.Case", b =>
                {
                    b.HasOne("Tema.Models.Status", "Status")
                        .WithMany()
                        .HasForeignKey("StatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Status");
                });

            modelBuilder.Entity("Tema.Models.Child", b =>
                {
                    b.HasOne("Tema.Models.Relation", "Relation")
                        .WithMany()
                        .HasForeignKey("RelationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Tema.Models.Status", "Status")
                        .WithMany()
                        .HasForeignKey("StatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Relation");

                    b.Navigation("Status");
                });

            modelBuilder.Entity("Tema.Models.Parent", b =>
                {
                    b.HasOne("Tema.Models.Bank", "Bank")
                        .WithMany()
                        .HasForeignKey("BankId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Tema.Models.Country", "Country")
                        .WithMany()
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Tema.Models.Criteria", "Criteria")
                        .WithMany()
                        .HasForeignKey("CriteriaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Tema.Models.Gender", "Gender")
                        .WithMany()
                        .HasForeignKey("GenderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Tema.Models.Language", "Language")
                        .WithMany()
                        .HasForeignKey("LanguageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Tema.Models.MaritalStatus", "MaritalStatus")
                        .WithMany()
                        .HasForeignKey("MaritalStatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Tema.Models.Nationality", "Nationality")
                        .WithMany()
                        .HasForeignKey("NationalityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Tema.Models.Region", "Region")
                        .WithMany()
                        .HasForeignKey("RegionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Tema.Models.Relation", "Relation")
                        .WithMany()
                        .HasForeignKey("RelationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Bank");

                    b.Navigation("Country");

                    b.Navigation("Criteria");

                    b.Navigation("Gender");

                    b.Navigation("Language");

                    b.Navigation("MaritalStatus");

                    b.Navigation("Nationality");

                    b.Navigation("Region");

                    b.Navigation("Relation");
                });
#pragma warning restore 612, 618
        }
    }
}
