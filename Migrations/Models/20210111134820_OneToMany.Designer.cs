﻿// <auto-generated />
using System;
using DAW_Yacht.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DAW_Yacht.Migrations.Models
{
    [DbContext(typeof(ModelsContext))]
    [Migration("20210111134820_OneToMany")]
    partial class OneToMany
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.1");

            modelBuilder.Entity("DAW_Yacht.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Email")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

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
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.ToTable("ApplicationUser");
                });

            modelBuilder.Entity("DAW_Yacht.Models.BookingModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("DateEnd")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("DateStart")
                        .HasColumnType("datetime(6)");

                    b.Property<float>("Price")
                        .HasColumnType("float");

                    b.Property<string>("UserId")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4");

                    b.Property<int?>("YachtId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.HasIndex("YachtId");

                    b.ToTable("Booking");
                });

            modelBuilder.Entity("DAW_Yacht.Models.GalleryModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100) CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.ToTable("Gallery");
                });

            modelBuilder.Entity("DAW_Yacht.Models.ImageModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int?>("GalleryModelId")
                        .HasColumnType("int");

                    b.Property<string>("RealFilename")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("varchar(500) CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.HasIndex("GalleryModelId");

                    b.ToTable("Images");
                });

            modelBuilder.Entity("DAW_Yacht.Models.PriceModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("DateEnd")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("DateStart")
                        .HasColumnType("datetime(6)");

                    b.Property<float>("Grow")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("Price");
                });

            modelBuilder.Entity("DAW_Yacht.Models.YachtModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<decimal>("BasePrice")
                        .HasColumnType("decimal(10,2)");

                    b.Property<int>("Capacity")
                        .HasColumnType("int(10)");

                    b.Property<int?>("GalleryIdId")
                        .HasColumnType("int");

                    b.Property<int>("Length")
                        .HasColumnType("int(10)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("varchar(500) CHARACTER SET utf8mb4");

                    b.Property<int>("Rooms")
                        .HasColumnType("int(10)");

                    b.HasKey("Id");

                    b.HasIndex("GalleryIdId");

                    b.ToTable("Yachts");
                });

            modelBuilder.Entity("DAW_Yacht.Models.BookingModel", b =>
                {
                    b.HasOne("DAW_Yacht.Models.ApplicationUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId");

                    b.HasOne("DAW_Yacht.Models.YachtModel", "Yacht")
                        .WithMany()
                        .HasForeignKey("YachtId");

                    b.Navigation("User");

                    b.Navigation("Yacht");
                });

            modelBuilder.Entity("DAW_Yacht.Models.ImageModel", b =>
                {
                    b.HasOne("DAW_Yacht.Models.GalleryModel", null)
                        .WithMany("IdImages")
                        .HasForeignKey("GalleryModelId");
                });

            modelBuilder.Entity("DAW_Yacht.Models.YachtModel", b =>
                {
                    b.HasOne("DAW_Yacht.Models.GalleryModel", "GalleryId")
                        .WithMany()
                        .HasForeignKey("GalleryIdId");

                    b.Navigation("GalleryId");
                });

            modelBuilder.Entity("DAW_Yacht.Models.GalleryModel", b =>
                {
                    b.Navigation("IdImages");
                });
#pragma warning restore 612, 618
        }
    }
}
