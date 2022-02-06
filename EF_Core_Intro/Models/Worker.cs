using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EF_Core_Intro
{
    // Entity
    [Table("Employees")]
    public class Worker
    {
        // Properties (columns in db)
        // Primary Key: Id/ID/id EntityName+Id (WorkerId)
        public int Id { get; set; }
        [Required]          // set not null
        [MaxLength(100)]    // set max length NVarChar(100)
        public string Name { get; set; }
        [Required, MaxLength(100)]
        public string Surname { get; set; }
        public DateTime? Birthdate { get; set; }
        [Column("WorkerSalary")]
        public decimal Salary { get; set; }
        public string Address { get; set; }

        // Navigation Properties
        public Department Department { get; set; }
    }
}
