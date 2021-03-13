namespace FitRoutine.Models
{
    public class ExerciseModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Reps { get; set; }
        public int Sets { get; set; }
        public int Weight { get; set; }
        public int DayId { get; set; }
    }
}
