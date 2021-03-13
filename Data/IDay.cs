using Data.Models;
using System.Collections.Generic;

namespace Data
{
    public interface IDay
    {
        void AddExercise(Exercise exercise);
        void ChangeIsRestDay(int dayId, bool restDayState);
        Day Get(int id);
        IEnumerable<Day> GetAll();
    }
}
