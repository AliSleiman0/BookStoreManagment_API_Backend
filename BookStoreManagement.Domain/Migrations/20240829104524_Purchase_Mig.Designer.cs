﻿// <auto-generated />
using System;
using BookStoreManagement.Domain.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BookStoreManagement.Domain.Migrations
{
    [DbContext(typeof(BookStoreDBContext))]
    [Migration("20240829104524_Purchase_Mig")]
    partial class Purchase_Mig
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("BookStoreManagement.Domain.Models.Author", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("DateOfBirth")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("date_of_birth");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("varchar(250)")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.ToTable("author");
                });

            modelBuilder.Entity("BookStoreManagement.Domain.Models.Book", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AuthorId")
                        .HasColumnType("int")
                        .HasColumnName("auther_id");

                    b.Property<int>("Genre")
                        .HasColumnType("int")
                        .HasColumnName("genre");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("varchar(250)")
                        .HasColumnName("title");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.ToTable("book");
                });

            modelBuilder.Entity("BookStoreManagement.Domain.Models.BookPublisher", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("BookId")
                        .HasColumnType("int")
                        .HasColumnName("book_id");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(65,30)")
                        .HasColumnName("price");

                    b.Property<int>("PublisherId")
                        .HasColumnType("int")
                        .HasColumnName("publisher_id");

                    b.HasKey("Id");

                    b.HasIndex("BookId");

                    b.HasIndex("PublisherId");

                    b.ToTable("book_publisher");
                });

            modelBuilder.Entity("BookStoreManagement.Domain.Models.Publisher", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("varchar(250)")
                        .HasColumnName("location");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("varchar(250)")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.ToTable("publisher");
                });

            modelBuilder.Entity("BookStoreManagement.Domain.Models.Purchase", b =>
                {
                    b.Property<int>("PurchaseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("PurchaseId");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("PurchaseId"));

                    b.Property<int>("BookId")
                        .HasColumnType("int")
                        .HasColumnName("book_id");

                    b.Property<double>("Bookprice")
                        .HasColumnType("double")
                        .HasColumnName("book_price");

                    b.Property<DateTime>("PurchaseDate")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("PurchaseDate");

                    b.Property<int>("Quantity")
                        .HasColumnType("int")
                        .HasColumnName("quantity");

                    b.HasKey("PurchaseId");

                    b.HasIndex("BookId");

                    b.ToTable("purchase");
                });

            modelBuilder.Entity("BookStoreManagement.Domain.Models.Book", b =>
                {
                    b.HasOne("BookStoreManagement.Domain.Models.Author", "Author")
                        .WithMany("Books")
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Author");
                });

            modelBuilder.Entity("BookStoreManagement.Domain.Models.BookPublisher", b =>
                {
                    b.HasOne("BookStoreManagement.Domain.Models.Book", "Book")
                        .WithMany("Publishers")
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BookStoreManagement.Domain.Models.Publisher", "Publisher")
                        .WithMany("PublishedBooks")
                        .HasForeignKey("PublisherId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Book");

                    b.Navigation("Publisher");
                });

            modelBuilder.Entity("BookStoreManagement.Domain.Models.Purchase", b =>
                {
                    b.HasOne("BookStoreManagement.Domain.Models.Book", "Book")
                        .WithMany()
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Book");
                });

            modelBuilder.Entity("BookStoreManagement.Domain.Models.Author", b =>
                {
                    b.Navigation("Books");
                });

            modelBuilder.Entity("BookStoreManagement.Domain.Models.Book", b =>
                {
                    b.Navigation("Publishers");
                });

            modelBuilder.Entity("BookStoreManagement.Domain.Models.Publisher", b =>
                {
                    b.Navigation("PublishedBooks");
                });
#pragma warning restore 612, 618
        }
    }
}
