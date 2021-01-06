﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WDPR_BuurtApp_3G.Data;

namespace WDPR_BuurtApp_3G.Migrations
{
    [DbContext(typeof(WDPR_BuurtApp_3GContext))]
    [Migration("20201223185420_crash")]
    partial class crash
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.1");

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256) CHARACTER SET utf8mb4");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256) CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("ClaimType")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("ClaimType")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("varchar(128) CHARACTER SET utf8mb4");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("varchar(128) CHARACTER SET utf8mb4");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4");

                    b.Property<string>("RoleId")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("varchar(128) CHARACTER SET utf8mb4");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("varchar(128) CHARACTER SET utf8mb4");

                    b.Property<string>("Value")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("WDPR_BuurtApp_3G.Areas.Identity.Data.WDPR_BuurtApp_3GUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<int>("Achternaam")
                        .HasColumnType("int");

                    b.Property<string>("Adres")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256) CHARACTER SET utf8mb4");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Foto")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256) CHARACTER SET utf8mb4");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256) CHARACTER SET utf8mb4");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256) CHARACTER SET utf8mb4");

                    b.Property<int>("Voornaam")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("WDPR_BuurtApp_3G.Models.Categorie", b =>
                {
                    b.Property<int>("CategorieID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Naam")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("CategorieID");

                    b.ToTable("Categorie");
                });

            modelBuilder.Entity("WDPR_BuurtApp_3G.Models.Like", b =>
                {
                    b.Property<string>("UserID")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4");

                    b.Property<int>("MeldingID")
                        .HasColumnType("int");

                    b.HasKey("UserID", "MeldingID");

                    b.HasIndex("MeldingID");

                    b.ToTable("Like");
                });

            modelBuilder.Entity("WDPR_BuurtApp_3G.Models.Melding", b =>
                {
                    b.Property<int>("MeldingID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<bool>("Anoniem")
                        .HasColumnType("tinyint(1)");

                    b.Property<int>("CategorieID")
                        .HasColumnType("int");

                    b.Property<DateTime>("Datum")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Foto")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<bool>("Gesloten")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Omschrijving")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Titel")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("UserID")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4");

                    b.HasKey("MeldingID");

                    b.HasIndex("CategorieID");

                    b.HasIndex("UserID");

                    b.ToTable("Melding");
                });

            modelBuilder.Entity("WDPR_BuurtApp_3G.Models.Reactie", b =>
                {
                    b.Property<string>("UserID")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4");

                    b.Property<int>("MeldingID")
                        .HasColumnType("int");

                    b.Property<DateTime>("Datum")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Reactietekst")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("UserID", "MeldingID");

                    b.HasIndex("MeldingID");

                    b.ToTable("Reactie");
                });

            modelBuilder.Entity("WDPR_BuurtApp_3G.Models.Report", b =>
                {
                    b.Property<string>("UserID")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4");

                    b.Property<int>("MeldingID")
                        .HasColumnType("int");

                    b.Property<string>("Omschrijving")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("UserID", "MeldingID");

                    b.HasIndex("MeldingID");

                    b.ToTable("Report");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("WDPR_BuurtApp_3G.Areas.Identity.Data.WDPR_BuurtApp_3GUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("WDPR_BuurtApp_3G.Areas.Identity.Data.WDPR_BuurtApp_3GUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WDPR_BuurtApp_3G.Areas.Identity.Data.WDPR_BuurtApp_3GUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("WDPR_BuurtApp_3G.Areas.Identity.Data.WDPR_BuurtApp_3GUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("WDPR_BuurtApp_3G.Models.Like", b =>
                {
                    b.HasOne("WDPR_BuurtApp_3G.Models.Melding", "melding")
                        .WithMany("Likes")
                        .HasForeignKey("MeldingID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WDPR_BuurtApp_3G.Areas.Identity.Data.WDPR_BuurtApp_3GUser", "User")
                        .WithMany("Likes")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("melding");

                    b.Navigation("User");
                });

            modelBuilder.Entity("WDPR_BuurtApp_3G.Models.Melding", b =>
                {
                    b.HasOne("WDPR_BuurtApp_3G.Models.Categorie", "Categorie")
                        .WithMany("Meldingen")
                        .HasForeignKey("CategorieID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WDPR_BuurtApp_3G.Areas.Identity.Data.WDPR_BuurtApp_3GUser", "User")
                        .WithMany("Meldingen")
                        .HasForeignKey("UserID");

                    b.Navigation("Categorie");

                    b.Navigation("User");
                });

            modelBuilder.Entity("WDPR_BuurtApp_3G.Models.Reactie", b =>
                {
                    b.HasOne("WDPR_BuurtApp_3G.Models.Melding", "melding")
                        .WithMany("Reacties")
                        .HasForeignKey("MeldingID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WDPR_BuurtApp_3G.Areas.Identity.Data.WDPR_BuurtApp_3GUser", "User")
                        .WithMany("Reacties")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("melding");

                    b.Navigation("User");
                });

            modelBuilder.Entity("WDPR_BuurtApp_3G.Models.Report", b =>
                {
                    b.HasOne("WDPR_BuurtApp_3G.Models.Melding", "melding")
                        .WithMany("Reports")
                        .HasForeignKey("MeldingID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WDPR_BuurtApp_3G.Areas.Identity.Data.WDPR_BuurtApp_3GUser", "User")
                        .WithMany("Reports")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("melding");

                    b.Navigation("User");
                });

            modelBuilder.Entity("WDPR_BuurtApp_3G.Areas.Identity.Data.WDPR_BuurtApp_3GUser", b =>
                {
                    b.Navigation("Likes");

                    b.Navigation("Meldingen");

                    b.Navigation("Reacties");

                    b.Navigation("Reports");
                });

            modelBuilder.Entity("WDPR_BuurtApp_3G.Models.Categorie", b =>
                {
                    b.Navigation("Meldingen");
                });

            modelBuilder.Entity("WDPR_BuurtApp_3G.Models.Melding", b =>
                {
                    b.Navigation("Likes");

                    b.Navigation("Reacties");

                    b.Navigation("Reports");
                });
#pragma warning restore 612, 618
        }
    }
}
