using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EF_Core_Intro
{
    public class Country
    {
        public Country()
        {
            Workers = new HashSet<Worker>();
        }

        public int Id { get; set; }
        [Required, MaxLength(100)]
        public string Name { get; set; }

        // Navigation Properties
        public ICollection<Worker> Workers { get; set; }
    }
}
