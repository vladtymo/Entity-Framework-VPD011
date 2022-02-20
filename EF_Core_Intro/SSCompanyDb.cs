using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_Core_Intro
{
    public class SSCompanyDb : DbContext
    {
        public SSCompanyDb()
        {
            //Database.EnsureDeleted();
            //Database.EnsureCreated();

            // Use Migrations instead: (install NuGet: EFCore.Tools)
            // add-migration <MigrationName> - add new migration with available changes
            // update-migration              - update the database by the newest migration
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(@"data source=(LocalDb)\MSSQLLocalDB;initial catalog=SS_Db_2022;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Initialize (Seeder)
            modelBuilder.SeedDepartments();
            modelBuilder.SeedCountries();
            modelBuilder.SeedProjects();

            // Fluent API configurations
            modelBuilder.Entity<Department>().HasKey(d => d.Number);        // set primary key
            modelBuilder.Entity<Department>().Property(d => d.Name)
                                                .HasMaxLength(250)          // set max length NVarChar(250)
                                                .IsRequired();              // set not null
            modelBuilder.Entity<Department>().Property(d => d.Phone)
                                                .HasMaxLength(40);

            modelBuilder.Entity<Country>().Property(c => c.Name)
                                                .HasMaxLength(100)
                                                .IsRequired();

            modelBuilder.Entity<Project>().Property(p => p.Title)
                                                .HasMaxLength(150)
                                                .IsRequired();

            // Worker
            modelBuilder.Entity<Worker>().ToTable("Employees");                 // set table name in database
            modelBuilder.Entity<Worker>().Property(d => d.Name)
                                                .HasMaxLength(100)
                                                .IsRequired(); 
            modelBuilder.Entity<Worker>().Property(d => d.Surname)
                                               .HasMaxLength(100)
                                               .IsRequired();
            modelBuilder.Entity<Worker>().Ignore(w => w.FullName);              // only in model
            modelBuilder.Entity<Worker>().Property(d => d.Salary)
                                                .HasColumnName("WorkerSalary"); // set column name in database

            // Relationship configurations

            // Relationship Type: 1...* (One to Many)
            modelBuilder.Entity<Worker>().HasOne(w => w.Department)
                                         .WithMany(d => d.Workers);

            // Relationship Type: 0/1...* (Zero or One to Many)
            modelBuilder.Entity<Worker>().HasOne(w => w.Country)
                                        .WithMany(d => d.Workers)
                                        .IsRequired(false);

            // Relationship Type: *...* (Many to Many)
            modelBuilder.Entity<Worker>().HasMany(w => w.Projects)
                                         .WithMany(d => d.Workers);
        }

        // Collections (tables in db)
        public DbSet<Worker> Workers { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Project> Projects { get; set; }
    }
}
