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
            modelBuilder.Entity<Department>().HasData(
                new Department()
                {
                    Number = 1,
                    Name = "Design"
                },
                new Department()
                {
                    Number = 2,
                    Name = "Programming",
                    Phone = "45-34-23"
                }
            );
        }

        // Collections (tables in db)
        public DbSet<Worker> Workers { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Project> Projects { get; set; }
    }
}
