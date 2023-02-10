﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using UzTexGroupV2.Infrastructure.DbContexts;

#nullable disable

namespace UzTexGroupV2.Infrastructure.Migrations
{
    [DbContext(typeof(UzTexGroupDbContext))]
    [Migration("20230210052816_SeedDataForLanguage")]
    partial class SeedDataForLanguage
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("UzTexGroupV2.Domain.Entities.Address", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("District")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<short>("PostalCode")
                        .HasColumnType("smallint");

                    b.Property<string>("Region")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Address", (string)null);
                });

            modelBuilder.Entity("UzTexGroupV2.Domain.Entities.Applications", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AddressId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ApplicationMessage")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<Guid>("JobId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("LanguageCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LastName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.HasKey("Id");

                    b.HasIndex("AddressId");

                    b.HasIndex("JobId", "LanguageCode");

                    b.ToTable("Applications", (string)null);
                });

            modelBuilder.Entity("UzTexGroupV2.Domain.Entities.Company", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("LanguageCode")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id", "LanguageCode");

                    b.ToTable("Company", (string)null);
                });

            modelBuilder.Entity("UzTexGroupV2.Domain.Entities.Factory", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("LanguageCode")
                        .HasColumnType("nvarchar(450)");

                    b.Property<Guid>("AddressId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CompanyId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id", "LanguageCode");

                    b.HasIndex("AddressId")
                        .IsUnique();

                    b.HasIndex("CompanyId", "LanguageCode");

                    b.ToTable("Factory", (string)null);
                });

            modelBuilder.Entity("UzTexGroupV2.Domain.Entities.Job", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("LanguageCode")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Desription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("FactoryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Salary")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("WorkTime")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id", "LanguageCode");

                    b.HasIndex("FactoryId", "LanguageCode");

                    b.ToTable("Job", (string)null);
                });

            modelBuilder.Entity("UzTexGroupV2.Domain.Entities.Language", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Languages", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("b6bbca81-6fb6-4485-9214-f650526d0d5b"),
                            Code = "uz",
                            Name = "Uzbek"
                        },
                        new
                        {
                            Id = new Guid("3ce4f472-177c-4921-a605-185643577e34"),
                            Code = "en",
                            Name = "English"
                        },
                        new
                        {
                            Id = new Guid("945986b4-cece-4bfa-b221-ca01e5c9118d"),
                            Code = "ru",
                            Name = "Russian"
                        });
                });

            modelBuilder.Entity("UzTexGroupV2.Domain.Entities.News", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("LanguageCode")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id", "LanguageCode");

                    b.ToTable("News", (string)null);
                });

            modelBuilder.Entity("UzTexGroupV2.Domain.Entities.NewsImages", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("NewId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("NewsId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("NewsLanguageCode")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("NewsId", "NewsLanguageCode");

                    b.ToTable("NewsImages");
                });

            modelBuilder.Entity("UzTexGroupV2.Domain.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("LastName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserRole")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("User", (string)null);
                });

            modelBuilder.Entity("UzTexGroupV2.Domain.Entities.Applications", b =>
                {
                    b.HasOne("UzTexGroupV2.Domain.Entities.Address", "Address")
                        .WithMany()
                        .HasForeignKey("AddressId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("UzTexGroupV2.Domain.Entities.Job", "Job")
                        .WithMany("Applications")
                        .HasForeignKey("JobId", "LanguageCode")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();

                    b.Navigation("Address");

                    b.Navigation("Job");
                });

            modelBuilder.Entity("UzTexGroupV2.Domain.Entities.Factory", b =>
                {
                    b.HasOne("UzTexGroupV2.Domain.Entities.Address", "Address")
                        .WithOne()
                        .HasForeignKey("UzTexGroupV2.Domain.Entities.Factory", "AddressId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("UzTexGroupV2.Domain.Entities.Company", "Company")
                        .WithMany("Factories")
                        .HasForeignKey("CompanyId", "LanguageCode")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Address");

                    b.Navigation("Company");
                });

            modelBuilder.Entity("UzTexGroupV2.Domain.Entities.Job", b =>
                {
                    b.HasOne("UzTexGroupV2.Domain.Entities.Factory", "Factory")
                        .WithMany("Jobs")
                        .HasForeignKey("FactoryId", "LanguageCode")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Factory");
                });

            modelBuilder.Entity("UzTexGroupV2.Domain.Entities.NewsImages", b =>
                {
                    b.HasOne("UzTexGroupV2.Domain.Entities.News", "News")
                        .WithMany("Images")
                        .HasForeignKey("NewsId", "NewsLanguageCode");

                    b.Navigation("News");
                });

            modelBuilder.Entity("UzTexGroupV2.Domain.Entities.Company", b =>
                {
                    b.Navigation("Factories");
                });

            modelBuilder.Entity("UzTexGroupV2.Domain.Entities.Factory", b =>
                {
                    b.Navigation("Jobs");
                });

            modelBuilder.Entity("UzTexGroupV2.Domain.Entities.Job", b =>
                {
                    b.Navigation("Applications");
                });

            modelBuilder.Entity("UzTexGroupV2.Domain.Entities.News", b =>
                {
                    b.Navigation("Images");
                });
#pragma warning restore 612, 618
        }
    }
}
