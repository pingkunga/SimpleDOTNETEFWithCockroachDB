﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using bojpawnapi.DataAccess;

#nullable disable

namespace bojpawnapi.Migrations
{
    [DbContext(typeof(PawnDBContext))]
    [Migration("20231212131206_aspnetidentity")]
    partial class aspnetidentity
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("bojpawnapi.Entities.CollateralTxDetailEntities", b =>
                {
                    b.Property<int>("CollateralDetailId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("CollateralDetailId"));

                    b.Property<int>("CollateralId")
                        .HasColumnType("integer");

                    b.Property<string>("CollateralItemName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("CollateralItemNo")
                        .HasColumnType("integer");

                    b.Property<decimal>("CollateralPrice")
                        .HasColumnType("numeric");

                    b.HasKey("CollateralDetailId");

                    b.HasIndex("CollateralId");

                    b.ToTable("CollateralTxDetails");
                });

            modelBuilder.Entity("bojpawnapi.Entities.CollateralTxEntities", b =>
                {
                    b.Property<int>("CollateralId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("CollateralId"));

                    b.Property<string>("CollateralCode")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("CustomerId")
                        .HasColumnType("integer");

                    b.Property<int>("EmployeeId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<decimal>("Interest")
                        .HasColumnType("numeric");

                    b.Property<decimal>("LoanAmt")
                        .HasColumnType("numeric");

                    b.Property<DateTime>("PaidDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("PrevCollateralId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("StatusCode")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Store")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("CollateralId");

                    b.HasIndex("CustomerId");

                    b.HasIndex("EmployeeId");

                    b.ToTable("CollateralTxs");
                });

            modelBuilder.Entity("bojpawnapi.Entities.CustomerEntities", b =>
                {
                    b.Property<int>("CustomerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("CustomerId"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("IdCardNo")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("CustomerId");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("bojpawnapi.Entities.EmployeeEntities", b =>
                {
                    b.Property<int>("EmployeeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("EmployeeId"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("IdCardNo")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("EmployeeId");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("bojpawnapi.Entities.CollateralTxDetailEntities", b =>
                {
                    b.HasOne("bojpawnapi.Entities.CollateralTxEntities", "CollateralTx")
                        .WithMany("CollateralDetaills")
                        .HasForeignKey("CollateralId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CollateralTx");
                });

            modelBuilder.Entity("bojpawnapi.Entities.CollateralTxEntities", b =>
                {
                    b.HasOne("bojpawnapi.Entities.CustomerEntities", "Customer")
                        .WithMany("CollateralTxls")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("bojpawnapi.Entities.EmployeeEntities", "Employee")
                        .WithMany("CollateralTxls")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("bojpawnapi.Entities.CollateralTxEntities", b =>
                {
                    b.Navigation("CollateralDetaills");
                });

            modelBuilder.Entity("bojpawnapi.Entities.CustomerEntities", b =>
                {
                    b.Navigation("CollateralTxls");
                });

            modelBuilder.Entity("bojpawnapi.Entities.EmployeeEntities", b =>
                {
                    b.Navigation("CollateralTxls");
                });
#pragma warning restore 612, 618
        }
    }
}
