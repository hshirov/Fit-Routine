using Data;
using Data.Models;
using FitRoutine.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace FitRoutine.Controllers
{
    public class DayController : Controller
    {
        private readonly IDay _days;
        private readonly IExercise _exerciseActivities;

        public DayController(IDay days, IExercise exerciseActivites)
        {
            _days = days;
            _exerciseActivities = exerciseActivites;
        }

        public IActionResult Index(int id)
        {
            Day day = _days.Get(id);
            IEnumerable<Exercise> exercises = _exerciseActivities.GetAllOnDay(id);

            IEnumerable<ExerciseModel> currentExercises = exercises.Select(e => new ExerciseModel
            {
                Id = e.Id,
                Name = e.Name,
                Reps = e.Reps,
                Sets = e.Sets,
                Weight = e.WeightInKg
            });

            DayIndexModel dayModel = new DayIndexModel
            {
                Id = id,
                Name = day.Name,
                IsRestDay = day.IsRestDay,
                Exercises = currentExercises
            };

            return View(dayModel);
        }

        public IActionResult AddExercise(int id)
        {
            Exercise emptyExerciseModel = new Exercise
            {
                Day = _days.Get(id)
            };

            return View(emptyExerciseModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddExercise(Exercise model)
        {
            if (ModelState.IsValid)
            {
                Exercise exerciseModel = new Exercise
                {
                    Name = model.Name,
                    Sets = model.Sets,
                    Reps = model.Reps,
                    WeightInKg = model.WeightInKg,
                    Day = _days.Get(model.Day.Id)
                };

                _days.AddExercise(exerciseModel);

                return RedirectToAction("Index", new { id = model.Day.Id });
            }

            return View(model);
        }

        [HttpPost]
        public IActionResult RemoveExercise(int id, int dayid)
        {
            _exerciseActivities.Remove(id);

            return RedirectToAction("Index", new { id = dayid });
        }

        [HttpPost]
        public IActionResult ChangeRestDayStatus(int id)
        {
            Day day = _days.Get(id);
            _days.ChangeIsRestDay(id, !day.IsRestDay);

            return RedirectToAction("Index", new { id = id });
        }

        public IActionResult EditExercise(int id)
        {
            Exercise exercise = _exerciseActivities.Get(id);

            return View(exercise);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditExercise(Exercise model)
        {
            if (ModelState.IsValid)
            {
                _exerciseActivities.Update(model);
                return RedirectToAction("Index", new { id = model.Day.Id });
            }

            return View(model);
        }
    }
}
