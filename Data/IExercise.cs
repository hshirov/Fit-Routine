using Data.Models;
using System.Collections.Generic;

namespace Data
{
    public interface IExercise
    {
        void Add(Exercise newExercise);
        void Remove(int id);
        Exercise Get(int id);
        IEnumerable<Exercise> GetAll();
        IEnumerable<Exercise> GetAllOnDay(int dayId);
        void Update(Exercise model);
    }
}
