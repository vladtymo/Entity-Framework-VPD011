using System;
using System.Linq;

namespace EF_Core_Intro
{
    class Program
    {
        static void Main(string[] args)
        {
            SSCompanyDb db = new SSCompanyDb();

            foreach (var item in db.Departments)
            {
                Console.WriteLine($"Department #{item.Number} {item.Name} {item.Phone ?? "Without Phone Number"}");
            }
        }
    }
}
