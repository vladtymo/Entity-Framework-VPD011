﻿// <auto-generated />
using System;
using EF_Core_Intro;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EF_Core_Intro.Migrations
{
    [DbContext(typeof(SSCompanyDb))]
    partial class SSCompanyDbModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.14")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EF_Core_Intro.Country", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Countries");
                });

            modelBuilder.Entity("EF_Core_Intro.Department", b =>
                {
                    b.Property<int>("Number")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

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

            modelBuilder.Entity("EF_Core_Intro.Project", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.HasKey("Id");

                    b.ToTable("Projects");
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

                    b.Property<int?>("CountryId")
                        .HasColumnType("int");

                    b.Property<int>("DepartmentNumber")
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

                    b.HasIndex("CountryId");

                    b.HasIndex("DepartmentNumber");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("ProjectWorker", b =>
                {
                    b.Property<int>("ProjectsId")
                        .HasColumnType("int");

                    b.Property<int>("WorkersId")
                        .HasColumnType("int");

                    b.HasKey("ProjectsId", "WorkersId");

                    b.HasIndex("WorkersId");

                    b.ToTable("ProjectWorker");
                });

            modelBuilder.Entity("EF_Core_Intro.Worker", b =>
                {
                    b.HasOne("EF_Core_Intro.Country", "Country")
                        .WithMany("Workers")
                        .HasForeignKey("CountryId");

                    b.HasOne("EF_Core_Intro.Department", "Department")
                        .WithMany("Workers")
                        .HasForeignKey("DepartmentNumber")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Country");

                    b.Navigation("Department");
                });

            modelBuilder.Entity("ProjectWorker", b =>
                {
                    b.HasOne("EF_Core_Intro.Project", null)
                        .WithMany()
                        .HasForeignKey("ProjectsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EF_Core_Intro.Worker", null)
                        .WithMany()
                        .HasForeignKey("WorkersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EF_Core_Intro.Country", b =>
                {
                    b.Navigation("Workers");
                });

            modelBuilder.Entity("EF_Core_Intro.Department", b =>
                {
                    b.Navigation("Workers");
                });
#pragma warning restore 612, 618
        }
    }
}
