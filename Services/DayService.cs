using Data;
using Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Services
{
    public class DayService : IDay
    {
        private FitRoutineContext _context;
        public DayService(FitRoutineContext context)
        {
            _context = context;
        }

        public void AddExercise(Exercise exercise)
        {
            Day day = Get(exercise.Day.Id);

            _context.Add(exercise);
            _context.Update(day);

            day.Exercises.Append(exercise);

            _context.SaveChanges();
        }

        public void ChangeIsRestDay(int dayId, bool restDayState)
        {
            Day day = Get(dayId);
            _context.Update(day);

            day.IsRestDay = restDayState;

            _context.SaveChanges();
        }

        public Day Get(int id)
        {
            return GetAll().FirstOrDefault(d => d.Id == id);
        }

        public IEnumerable<Day> GetAll()
        {
            return _context.Days.Include(d => d.Exercises);
        }
    }
}
