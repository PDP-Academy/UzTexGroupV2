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
    [Migration("20230204104941_Initial")]
    partial class Initial
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

            modelBuilder.Entity("UzTexGroupV2.Domain.Entities.Application", b =>
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

                    b.Property<string>("LastName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.HasKey("Id");

                    b.HasIndex("AddressId");

                    b.HasIndex("JobId");

                    b.ToTable("Application", (string)null);
                });

            modelBuilder.Entity("UzTexGroupV2.Domain.Entities.Company", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Company", (string)null);
                });

            modelBuilder.Entity("UzTexGroupV2.Domain.Entities.Factory", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AddressId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CompanyId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("NameTextId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("AddressId")
                        .IsUnique();

                    b.HasIndex("CompanyId");

                    b.ToTable("Factory", (string)null);
                });

            modelBuilder.Entity("UzTexGroupV2.Domain.Entities.Job", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("DescriptionId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("FactoryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("JobNameId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("Salary")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("WorkTime")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("FactoryId");

                    b.ToTable("Job", (string)null);
                });

            modelBuilder.Entity("UzTexGroupV2.Domain.Entities.LanguageDictionary", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("JobId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("LanguageCode")
                        .IsRequired()
                        .HasMaxLength(5)
                        .HasColumnType("nvarchar(5)");

                    b.Property<Guid?>("NewsId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("NewsId1")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("JobId");

                    b.HasIndex("NewsId");

                    b.HasIndex("NewsId1");

                    b.ToTable("LanguageDictionary", (string)null);
                });

            modelBuilder.Entity("UzTexGroupV2.Domain.Entities.News", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("DescriptionId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("TitleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.ToTable("News");
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

                    b.HasKey("Id");

                    b.HasIndex("NewsId");

                    b.ToTable("NewsImages");
                });

            modelBuilder.Entity("UzTexGroupV2.Domain.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

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

            modelBuilder.Entity("UzTexGroupV2.Domain.Entities.Application", b =>
                {
                    b.HasOne("UzTexGroupV2.Domain.Entities.Address", "Address")
                        .WithMany()
                        .HasForeignKey("AddressId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("UzTexGroupV2.Domain.Entities.Job", "Job")
                        .WithMany("Applications")
                        .HasForeignKey("JobId")
                        .OnDelete(DeleteBehavior.Cascade)
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
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Address");

                    b.Navigation("Company");
                });

            modelBuilder.Entity("UzTexGroupV2.Domain.Entities.Job", b =>
                {
                    b.HasOne("UzTexGroupV2.Domain.Entities.Factory", "Factory")
                        .WithMany("Jobs")
                        .HasForeignKey("FactoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Factory");
                });

            modelBuilder.Entity("UzTexGroupV2.Domain.Entities.LanguageDictionary", b =>
                {
                    b.HasOne("UzTexGroupV2.Domain.Entities.Job", null)
                        .WithMany("Descriptions")
                        .HasForeignKey("Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("UzTexGroupV2.Domain.Entities.Factory", null)
                        .WithMany("Names")
                        .HasForeignKey("Id")
                        .HasPrincipalKey("NameTextId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("UzTexGroupV2.Domain.Entities.Job", null)
                        .WithMany("JobNames")
                        .HasForeignKey("JobId");

                    b.HasOne("UzTexGroupV2.Domain.Entities.News", null)
                        .WithMany("Descriptions")
                        .HasForeignKey("NewsId");

                    b.HasOne("UzTexGroupV2.Domain.Entities.News", null)
                        .WithMany("Titles")
                        .HasForeignKey("NewsId1");
                });

            modelBuilder.Entity("UzTexGroupV2.Domain.Entities.NewsImages", b =>
                {
                    b.HasOne("UzTexGroupV2.Domain.Entities.News", "News")
                        .WithMany("Images")
                        .HasForeignKey("NewsId");

                    b.Navigation("News");
                });

            modelBuilder.Entity("UzTexGroupV2.Domain.Entities.Company", b =>
                {
                    b.Navigation("Factories");
                });

            modelBuilder.Entity("UzTexGroupV2.Domain.Entities.Factory", b =>
                {
                    b.Navigation("Jobs");

                    b.Navigation("Names");
                });

            modelBuilder.Entity("UzTexGroupV2.Domain.Entities.Job", b =>
                {
                    b.Navigation("Applications");

                    b.Navigation("Descriptions");

                    b.Navigation("JobNames");
                });

            modelBuilder.Entity("UzTexGroupV2.Domain.Entities.News", b =>
                {
                    b.Navigation("Descriptions");

                    b.Navigation("Images");

                    b.Navigation("Titles");
                });
#pragma warning restore 612, 618
        }
    }
}
