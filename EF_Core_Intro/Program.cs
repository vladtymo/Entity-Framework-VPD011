using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace EF_Core_Intro
{
    class Program
    {
        static void Main(string[] args)
        {
            SSCompanyDb db = new SSCompanyDb();

            var result = db.Departments.Include(d => d.Workers); // get data from nav prop

            foreach (var item in result)
            {
                Console.WriteLine($"Department #{item.Number} {item.Name} {item.Phone ?? "Without Phone Number"} {item.Workers.Count}");
            }

            var goodWorkers = db.Workers.Include(w => w.Country)
                                        .Include(w => w.Projects)
                                        .Include(w => w.Department)
                                        .Where(w => w.Salary > 1000);

            foreach (var w in goodWorkers)
            {
                Console.WriteLine($"Worker {w.FullName} with salary of {w.Salary}$\n" +
                    $"Department: {w.Department.Name}\n" +
                    $"Country: {(w.Country != null ? w.Country.Name : "no country")}\n" +
                    $"Projects: {w.Projects.Count}");
            }
        }
    }
}
