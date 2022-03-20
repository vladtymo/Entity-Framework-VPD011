using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EF_Core_Intro
{
    // Entity
    public class Worker
    {
        public Worker()
        {
            Projects = new HashSet<Project>();
        }
        // Properties (columns in db)
        // Primary Key: Id/ID/id EntityName+Id (WorkerId)
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string FullName => Name + " " + Surname;
        public DateTime? Birthdate { get; set; }
        public decimal Salary { get; set; }
        public string Address { get; set; }

        // Navigation Properties

        // Relationship Type: 1...* (One to Many)
        public Department Department { get; set; }
        // Relationship Type: 0/1...* (Zero or One to Many)
        public Country Country { get; set; }
        // Relationship Type: *...* (Many to Many)
        public ICollection<Project> Projects { get; set; }
    }
}
