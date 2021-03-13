using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Data.Models
{
    public class Day
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual IEnumerable<Exercise> Exercises { get; set; }
        public bool IsRestDay { get; set; }
    }
}