using System.Collections.Generic;

namespace FitRoutine.Models
{
    public class DayIndexModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsRestDay { get; set; }
        public IEnumerable<ExerciseModel> Exercises { get; set; }
    }
}
