﻿// <auto-generated />
using System;
using Evim.DAL.Content;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Evim.DAL.Migrations
{
    [DbContext(typeof(SQLContext))]
    [Migration("20231013143753_personelpictureupdatev1")]
    partial class personelpictureupdatev1
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Evim.DAL.Entities.Admin", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("LastLoginIP")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)");

                    b.Property<DateTime>("LastLongDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("NameSurname")
                        .IsRequired()
                        .HasMaxLength(32)
                        .HasColumnType("Varchar(50)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(32)
                        .HasColumnType("Varchar(32)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("Varchar(20)");

                    b.HasKey("ID");

                    b.ToTable("Admin");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            LastLoginIP = "",
                            LastLongDate = new DateTime(2023, 10, 13, 17, 37, 52, 957, DateTimeKind.Local).AddTicks(9580),
                            NameSurname = "Arda Oran",
                            Password = "202cb962ac59075b964b07152d234b70",
                            UserName = "arda"
                        });
                });

            modelBuilder.Entity("Evim.DAL.Entities.Category", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int>("DisplayIndex")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasMaxLength(50)
                        .HasColumnType("Varchar(100)");

                    b.Property<int?>("ParentCategoryID")
                        .HasColumnType("int");

                    b.Property<int?>("ParentID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("ParentCategoryID");

                    b.ToTable("Category");
                });

            modelBuilder.Entity("Evim.DAL.Entities.Personel", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int?>("DisplayIndex")
                        .HasColumnType("int");

                    b.Property<string>("Gorev")
                        .HasMaxLength(50)
                        .HasColumnType("Varchar(100)");

                    b.Property<string>("NameSurname")
                        .HasMaxLength(50)
                        .HasColumnType("Varchar(100)");

                    b.Property<string>("Picture")
                        .HasMaxLength(50)
                        .HasColumnType("Varchar(150)");

                    b.HasKey("ID");

                    b.ToTable("Personel");
                });

            modelBuilder.Entity("Evim.DAL.Entities.PersonelPicture", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int>("DisplayIndex")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("Varchar(100)");

                    b.Property<int>("PersonelID")
                        .HasColumnType("int");

                    b.Property<string>("Picture")
                        .HasMaxLength(150)
                        .HasColumnType("Varchar(150)");

                    b.HasKey("ID");

                    b.HasIndex("PersonelID");

                    b.ToTable("PersonelPictures");
                });

            modelBuilder.Entity("Evim.DAL.Entities.Product", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Adres")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("Varchar(100)");

                    b.Property<string>("Banyo")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("Varchar(100)");

                    b.Property<int?>("CategoryID")
                        .HasColumnType("int");

                    b.Property<int>("DisplayIndex")
                        .HasColumnType("int");

                    b.Property<string>("Durum")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("Varchar(100)");

                    b.Property<decimal>("Fiyat")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Metrekare")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("Varchar(100)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("Varchar(100)");

                    b.Property<string>("Tur")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("Varchar(100)");

                    b.Property<string>("YatakOdasi")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("Varchar(100)");

                    b.HasKey("ID");

                    b.HasIndex("CategoryID");

                    b.ToTable("Product");
                });

            modelBuilder.Entity("Evim.DAL.Entities.ProductPicture", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int>("DisplayIndex")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("Varchar(100)");

                    b.Property<string>("Picture")
                        .HasMaxLength(150)
                        .HasColumnType("Varchar(150)");

                    b.Property<int>("ProductID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("ProductID");

                    b.ToTable("ProductPictures");
                });

            modelBuilder.Entity("Evim.DAL.Entities.Slide", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int?>("DisplayIndex")
                        .HasColumnType("int");

                    b.Property<string>("Picture")
                        .HasMaxLength(50)
                        .HasColumnType("Varchar(150)");

                    b.Property<string>("SloganBuyuk")
                        .HasMaxLength(50)
                        .HasColumnType("Varchar(100)");

                    b.Property<string>("SloganKucuk")
                        .HasMaxLength(50)
                        .HasColumnType("Varchar(100)");

                    b.Property<string>("SloganRenkliKelime")
                        .HasMaxLength(50)
                        .HasColumnType("Varchar(100)");

                    b.HasKey("ID");

                    b.ToTable("Slide");
                });

            modelBuilder.Entity("Evim.DAL.Entities.Category", b =>
                {
                    b.HasOne("Evim.DAL.Entities.Category", "ParentCategory")
                        .WithMany("SubCategories")
                        .HasForeignKey("ParentCategoryID");

                    b.Navigation("ParentCategory");
                });

            modelBuilder.Entity("Evim.DAL.Entities.PersonelPicture", b =>
                {
                    b.HasOne("Evim.DAL.Entities.Personel", "Personel")
                        .WithMany("PersonelPictures")
                        .HasForeignKey("PersonelID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Personel");
                });

            modelBuilder.Entity("Evim.DAL.Entities.Product", b =>
                {
                    b.HasOne("Evim.DAL.Entities.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryID");

                    b.Navigation("Category");
                });

            modelBuilder.Entity("Evim.DAL.Entities.ProductPicture", b =>
                {
                    b.HasOne("Evim.DAL.Entities.Product", "Product")
                        .WithMany("ProductPictures")
                        .HasForeignKey("ProductID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");
                });

            modelBuilder.Entity("Evim.DAL.Entities.Category", b =>
                {
                    b.Navigation("Products");

                    b.Navigation("SubCategories");
                });

            modelBuilder.Entity("Evim.DAL.Entities.Personel", b =>
                {
                    b.Navigation("PersonelPictures");
                });

            modelBuilder.Entity("Evim.DAL.Entities.Product", b =>
                {
                    b.Navigation("ProductPictures");
                });
#pragma warning restore 612, 618
        }
    }
}
