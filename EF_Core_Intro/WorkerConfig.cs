using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EF_Core_Intro
{
    public class WorkerConfig : IEntityTypeConfiguration<Worker>
    {
        public void Configure(EntityTypeBuilder<Worker> builder)
        {
            builder.ToTable("Employees");       // set table name in database
            builder.Property(d => d.Name)
                        .HasMaxLength(100)
                        .IsRequired();
            builder.Property(d => d.Surname)
                        .HasMaxLength(100)
                        .IsRequired();
            builder.Ignore(w => w.FullName);    // only in model
            builder.Property(d => d.Salary)
                        .HasColumnName("WorkerSalary"); // set column name in database

            // Relationship configurations

            // Relationship Type: 1...* (One to Many)
            builder.HasOne(w => w.Department)
                        .WithMany(d => d.Workers);

            // Relationship Type: 0/1...* (Zero or One to Many)
            builder.HasOne(w => w.Country)
                        .WithMany(d => d.Workers)
                        .IsRequired(false);

            // Relationship Type: *...* (Many to Many)
            builder.HasMany(w => w.Projects)
                        .WithMany(d => d.Workers);
        }
    }
}
