﻿// <auto-generated />
using System;
using Helpdesk_SGVW.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

//namespace Helpdesk_SGVW.Migrations
//{
//    [DbContext(typeof(ApplicationDbContext))]
//    [Migration("20200906160625_AddOpvolgingTbl")]
//    partial class AddOpvolgingTbl
//    {
//        protected override void BuildTargetModel(ModelBuilder modelBuilder)
//        {
//#pragma warning disable 612, 618
//            modelBuilder
//                .HasAnnotation("ProductVersion", "3.1.7")
//                .HasAnnotation("Relational:MaxIdentifierLength", 128)
//                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

//            modelBuilder.Entity("Helpdesk_SGVW.Models.Categorie", b =>
//                {
//                    b.Property<int>("Id")
//                        .ValueGeneratedOnAdd()
//                        .HasColumnType("int")
//                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

//                    b.Property<string>("Naam")
//                        .IsRequired()
//                        .HasColumnType("nvarchar(max)");

//                    b.Property<string>("Verantwoordelijke")
//                        .HasColumnType("nvarchar(max)");

//                    b.Property<string>("Verantwoordelijke2")
//                        .HasColumnType("nvarchar(max)");

//                    b.HasKey("Id");

//                    b.ToTable("Categorie");
//                });

//            modelBuilder.Entity("Helpdesk_SGVW.Models.Infotheek", b =>
//                {
//                    b.Property<int>("Id")
//                        .ValueGeneratedOnAdd()
//                        .HasColumnType("int")
//                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

//                    b.Property<int>("CategorieId")
//                        .HasColumnType("int");

//                    b.Property<DateTime>("Datum")
//                        .HasColumnType("datetime2");

//                    b.Property<string>("Omschrijving")
//                        .HasColumnType("nvarchar(max)");

//                    b.Property<int>("SubCategorieId")
//                        .HasColumnType("int");

//                    b.Property<string>("Tag1")
//                        .HasColumnType("nvarchar(max)");

//                    b.Property<string>("Tag2")
//                        .HasColumnType("nvarchar(max)");

//                    b.Property<string>("Tag3")
//                        .HasColumnType("nvarchar(max)");

//                    b.Property<string>("Titel")
//                        .HasColumnType("nvarchar(max)");

//                    b.Property<string>("Type")
//                        .HasColumnType("nvarchar(max)");

//                    b.Property<string>("Url")
//                        .HasColumnType("nvarchar(max)");

//                    b.HasKey("Id");

//                    b.HasIndex("CategorieId");

//                    b.HasIndex("SubCategorieId");

//                    b.ToTable("Infotheek");
//                });

//            modelBuilder.Entity("Helpdesk_SGVW.Models.Opvolgers", b =>
//                {
//                    b.Property<int>("Id")
//                        .ValueGeneratedOnAdd()
//                        .HasColumnType("int")
//                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

//                    b.Property<string>("Displaynaam")
//                        .IsRequired()
//                        .HasColumnType("nvarchar(max)");

//                    b.Property<string>("Email")
//                        .IsRequired()
//                        .HasColumnType("nvarchar(max)");

//                    b.Property<string>("Familienaam")
//                        .IsRequired()
//                        .HasColumnType("nvarchar(max)");

//                    b.Property<string>("Voornaam")
//                        .IsRequired()
//                        .HasColumnType("nvarchar(max)");

//                    b.HasKey("Id");

//                    b.ToTable("Opvolgers");
//                });

//            modelBuilder.Entity("Helpdesk_SGVW.Models.Personeel", b =>
//                {
//                    b.Property<string>("Id")
//                        .HasColumnType("nvarchar(450)");

//                    b.Property<int>("AccessFailedCount")
//                        .HasColumnType("int");

//                    b.Property<string>("ConcurrencyStamp")
//                        .HasColumnType("nvarchar(max)");

//                    b.Property<string>("Email")
//                        .HasColumnType("nvarchar(max)");

//                    b.Property<bool>("EmailConfirmed")
//                        .HasColumnType("bit");

//                    b.Property<bool>("LockoutEnabled")
//                        .HasColumnType("bit");

//                    b.Property<DateTimeOffset?>("LockoutEnd")
//                        .HasColumnType("datetimeoffset");

//                    b.Property<string>("Naam")
//                        .HasColumnType("nvarchar(max)");

//                    b.Property<string>("NormalizedEmail")
//                        .HasColumnType("nvarchar(max)");

//                    b.Property<string>("NormalizedUserName")
//                        .HasColumnType("nvarchar(max)");

//                    b.Property<string>("PasswordHash")
//                        .HasColumnType("nvarchar(max)");

//                    b.Property<string>("PhoneNumber")
//                        .HasColumnType("nvarchar(max)");

//                    b.Property<bool>("PhoneNumberConfirmed")
//                        .HasColumnType("bit");

//                    b.Property<string>("SecurityStamp")
//                        .HasColumnType("nvarchar(max)");

//                    b.Property<bool>("TwoFactorEnabled")
//                        .HasColumnType("bit");

//                    b.Property<string>("UserName")
//                        .HasColumnType("nvarchar(max)");

//                    b.Property<string>("Voornaam")
//                        .HasColumnType("nvarchar(max)");

//                    b.HasKey("Id");

//                    b.ToTable("Personeel");
//                });

//            modelBuilder.Entity("Helpdesk_SGVW.Models.School", b =>
//                {
//                    b.Property<int>("Id")
//                        .ValueGeneratedOnAdd()
//                        .HasColumnType("int")
//                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

//                    b.Property<string>("Logo")
//                        .HasColumnType("nvarchar(max)");

//                    b.Property<string>("Naam")
//                        .IsRequired()
//                        .HasColumnType("nvarchar(max)");

//                    b.Property<string>("Verantwoordelijke")
//                        .HasColumnType("nvarchar(max)");

//                    b.Property<string>("Verantwoordelijke2")
//                        .HasColumnType("nvarchar(max)");

//                    b.HasKey("Id");

//                    b.ToTable("School");
//                });

//            modelBuilder.Entity("Helpdesk_SGVW.Models.SubCategorie", b =>
//                {
//                    b.Property<int>("Id")
//                        .ValueGeneratedOnAdd()
//                        .HasColumnType("int")
//                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

//                    b.Property<int>("CategorieId")
//                        .HasColumnType("int");

//                    b.Property<string>("Subcategorie")
//                        .IsRequired()
//                        .HasColumnType("nvarchar(max)");

//                    b.Property<string>("Verantwoordelijke")
//                        .HasColumnType("nvarchar(max)");

//                    b.Property<string>("Verantwoordelijke2")
//                        .HasColumnType("nvarchar(max)");

//                    b.HasKey("Id");

//                    b.HasIndex("CategorieId");

//                    b.ToTable("SubCategorie");
//                });

//            modelBuilder.Entity("Helpdesk_SGVW.Models.Ticket", b =>
//                {
//                    b.Property<int>("Id")
//                        .ValueGeneratedOnAdd()
//                        .HasColumnType("int")
//                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

//                    b.Property<string>("Aanvrager")
//                        .HasColumnType("nvarchar(max)");

//                    b.Property<int>("CategorieId")
//                        .HasColumnType("int");

//                    b.Property<DateTime>("Datum")
//                        .HasColumnType("datetime2");

//                    b.Property<string>("EmailAanvrager")
//                        .HasColumnType("nvarchar(max)");

//                    b.Property<string>("Lokaal")
//                        .HasColumnType("nvarchar(max)");

//                    b.Property<string>("Omschrijving")
//                        .HasColumnType("nvarchar(max)");

//                    b.Property<string>("Opvolger")
//                        .HasColumnType("nvarchar(max)");

//                    b.Property<int?>("OpvolgingId")
//                        .HasColumnType("int");

//                    b.Property<int>("OpvolingId")
//                        .HasColumnType("int");

//                    b.Property<int>("SchoolId")
//                        .HasColumnType("int");

//                    b.Property<string>("Screenshot")
//                        .HasColumnType("nvarchar(max)");

//                    b.Property<string>("Status")
//                        .HasColumnType("nvarchar(max)");

//                    b.Property<int>("SubCategorieId")
//                        .HasColumnType("int");

//                    b.Property<string>("Uitleg")
//                        .HasColumnType("nvarchar(max)");

//                    b.Property<string>("Urgentie")
//                        .HasColumnType("nvarchar(max)");

//                    b.HasKey("Id");

//                    b.HasIndex("CategorieId");

//                    b.HasIndex("OpvolgingId");

//                    b.HasIndex("SchoolId");

//                    b.HasIndex("SubCategorieId");

//                    b.ToTable("Ticket");
//                });

//            modelBuilder.Entity("Helpdesk_SGVW.Models.Infotheek", b =>
//                {
//                    b.HasOne("Helpdesk_SGVW.Models.Categorie", "Categorie")
//                        .WithMany()
//                        .HasForeignKey("CategorieId")
//                        .OnDelete(DeleteBehavior.Cascade)
//                        .IsRequired();

//                    b.HasOne("Helpdesk_SGVW.Models.SubCategorie", "SubCategorie")
//                        .WithMany()
//                        .HasForeignKey("SubCategorieId")
//                        .OnDelete(DeleteBehavior.Cascade)
//                        .IsRequired();
//                });

//            modelBuilder.Entity("Helpdesk_SGVW.Models.SubCategorie", b =>
//                {
//                    b.HasOne("Helpdesk_SGVW.Models.Categorie", "Categorie")
//                        .WithMany()
//                        .HasForeignKey("CategorieId")
//                        .OnDelete(DeleteBehavior.Cascade)
//                        .IsRequired();
//                });

//            modelBuilder.Entity("Helpdesk_SGVW.Models.Ticket", b =>
//                {
//                    b.HasOne("Helpdesk_SGVW.Models.Categorie", "Categorie")
//                        .WithMany()
//                        .HasForeignKey("CategorieId")
//                        .OnDelete(DeleteBehavior.Cascade)
//                        .IsRequired();

//                    b.HasOne("Helpdesk_SGVW.Models.Opvolgers", "Opvolging")
//                        .WithMany()
//                        .HasForeignKey("OpvolgingId");

//                    b.HasOne("Helpdesk_SGVW.Models.School", "School")
//                        .WithMany()
//                        .HasForeignKey("SchoolId")
//                        .OnDelete(DeleteBehavior.Cascade)
//                        .IsRequired();

//                    b.HasOne("Helpdesk_SGVW.Models.SubCategorie", "SubCategorie")
//                        .WithMany()
//                        .HasForeignKey("SubCategorieId")
//                        .OnDelete(DeleteBehavior.Cascade)
//                        .IsRequired();
//                });
//#pragma warning restore 612, 618
//        }
//    }
//}
