﻿// <auto-generated />
using System;
using EF_Core_Intro;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EF_Core_Intro.Migrations
{
    [DbContext(typeof(SSCompanyDb))]
    [Migration("20220213150025_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.14")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EF_Core_Intro.Department", b =>
                {
                    b.Property<int>("Number")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Phone")
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.HasKey("Number");

                    b.ToTable("Departments");

                    b.HasData(
                        new
                        {
                            Number = 1,
                            Name = "Design"
                        },
                        new
                        {
                            Number = 2,
                            Name = "Programming",
                            Phone = "45-34-23"
                        });
                });

            modelBuilder.Entity("EF_Core_Intro.Worker", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("Birthdate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("DepartmentNumber")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<decimal>("Salary")
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("WorkerSalary");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("DepartmentNumber");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("EF_Core_Intro.Worker", b =>
                {
                    b.HasOne("EF_Core_Intro.Department", "Department")
                        .WithMany("Workers")
                        .HasForeignKey("DepartmentNumber");

                    b.Navigation("Department");
                });

            modelBuilder.Entity("EF_Core_Intro.Department", b =>
                {
                    b.Navigation("Workers");
                });
#pragma warning restore 612, 618
        }
    }
}
