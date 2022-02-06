using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EF_Core_Intro
{
    public class Department
    {
        [Key]   // set primary key
        public int Number { get; set; }
        [Required, MaxLength(200)]
        public string Name { get; set; }
        [MaxLength(40)]
        public string Phone { get; set; }

        // Navigation Properties
        public ICollection<Worker> Workers { get; set; }
    }
}
