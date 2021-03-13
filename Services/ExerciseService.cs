using Data;
using Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Services
{
    public class ExerciseService : IExercise
    {
        private FitRoutineContext _context;
        public ExerciseService(FitRoutineContext context)
        {
            _context = context;
        }

        public void Add(Exercise newExercise)
        {
            _context.Add(newExercise);
            _context.SaveChanges();
        }

        public Exercise Get(int id)
        {
            return GetAll().FirstOrDefault(e => e.Id == id);
        }

        public IEnumerable<Exercise> GetAll()
        {
            return _context.Exercises
                .Include(ex => ex.Day)
                .ToList();
        }

        public IEnumerable<Exercise> GetAllOnDay(int dayId)
        {
            return GetAll()
                .Where(ex => ex.Day.Id == dayId)
                .ToList();
        }

        public void Remove(int id)
        {
            Exercise exercise = Get(id);
            _context.Exercises.Remove(exercise);
            _context.SaveChanges();
        }

        public void Update(Exercise model)
        {
            Exercise exerciseToUpdate = Get(model.Id);
            _context.Update(exerciseToUpdate);

            exerciseToUpdate.Sets = model.Sets;
            exerciseToUpdate.Reps = model.Reps;
            exerciseToUpdate.WeightInKg = model.WeightInKg;

            _context.SaveChanges();
        }
    }
}
