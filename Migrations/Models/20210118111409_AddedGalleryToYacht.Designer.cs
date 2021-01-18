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
    [Migration("20210118111409_AddedGalleryToYacht")]
    partial class AddedGalleryToYacht
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

                    b.ToTable("AspNetUsers");
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

                    b.Property<int>("YachtId")
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

                    b.Property<string>("RealFilename")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("varchar(500) CHARACTER SET utf8mb4");

                    b.HasKey("Id");

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

                    b.Property<int>("GalleryId")
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

                    b.HasIndex("GalleryId");

                    b.ToTable("Yachts");
                });

            modelBuilder.Entity("GalleryModelImageModel", b =>
                {
                    b.Property<int>("GalleryModelsId")
                        .HasColumnType("int");

                    b.Property<int>("ImageModelsId")
                        .HasColumnType("int");

                    b.HasKey("GalleryModelsId", "ImageModelsId");

                    b.HasIndex("ImageModelsId");

                    b.ToTable("GalleryModelImageModel");
                });

            modelBuilder.Entity("DAW_Yacht.Models.BookingModel", b =>
                {
                    b.HasOne("DAW_Yacht.Models.ApplicationUser", "User")
                        .WithMany("BookingModels")
                        .HasForeignKey("UserId");

                    b.HasOne("DAW_Yacht.Models.YachtModel", "Yacht")
                        .WithMany("BookingModels")
                        .HasForeignKey("YachtId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");

                    b.Navigation("Yacht");
                });

            modelBuilder.Entity("DAW_Yacht.Models.YachtModel", b =>
                {
                    b.HasOne("DAW_Yacht.Models.GalleryModel", "Gallery")
                        .WithMany()
                        .HasForeignKey("GalleryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Gallery");
                });

            modelBuilder.Entity("GalleryModelImageModel", b =>
                {
                    b.HasOne("DAW_Yacht.Models.GalleryModel", null)
                        .WithMany()
                        .HasForeignKey("GalleryModelsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DAW_Yacht.Models.ImageModel", null)
                        .WithMany()
                        .HasForeignKey("ImageModelsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DAW_Yacht.Models.ApplicationUser", b =>
                {
                    b.Navigation("BookingModels");
                });

            modelBuilder.Entity("DAW_Yacht.Models.YachtModel", b =>
                {
                    b.Navigation("BookingModels");
                });
#pragma warning restore 612, 618
        }
    }
}
