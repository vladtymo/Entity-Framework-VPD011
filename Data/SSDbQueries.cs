using EF_Core_Intro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class SSDbQueries
    {
        private readonly SSCompanyDb db;

        public SSDbQueries(SSCompanyDb context)
        {
            db = context;
        }

        // public interface
        public IEnumerable<Worker> GetAllWorkers()
        {
            return db.Workers.ToList();
        }
        public IEnumerable<Worker> GetWorkersBySalary(decimal from, decimal to)
        {
            return db.Workers.Where(w => w.Salary >= from && w.Salary <= to).ToList();
        }

        public void AddProject(string title, string description)
        {
            Project newProject = new Project()
            {
                Title = title,
                Description = description
            };
            db.Projects.Add(newProject);
            db.SaveChanges();
        }
        public void DeleteProjectById(int id)
        {
            var pr = db.Projects.Find(id);

            if (pr == null) return;

            db.Projects.Remove(pr);
            db.SaveChanges();
        }
    }
}
