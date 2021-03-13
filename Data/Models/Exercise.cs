using System.ComponentModel.DataAnnotations;

namespace Data.Models
{
    public class Exercise
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "A name is required.")]
        [StringLength(45)]
        [Display(Name = "Exercise Name")]
        public string Name { get; set; }
        [Required]
        [Range(1, 25)]
        public int Sets { get; set; }
        [Required]
        [Range(1, 100)]
        public int Reps { get; set; }
        [Range(0, 700)]
        [Display(Name = "Weight In Kg")]
        public int WeightInKg { get; set; }
        public virtual Day Day { get; set; }
    }
}