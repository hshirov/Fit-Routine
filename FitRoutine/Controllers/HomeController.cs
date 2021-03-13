using Data;
using Data.Models;
using FitRoutine.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace FitRoutine.Controllers
{
    public class HomeController : Controller
    {
        private readonly IDay _days;
        private readonly IExercise _exerciseActivities;

        public HomeController(IDay days, IExercise exerciseActivites)
        {
            _days = days;
            _exerciseActivities = exerciseActivites;
        }

        public IActionResult Index()
        {
            IEnumerable<Day> days = _days.GetAll();
            IEnumerable<Exercise> exercises = _exerciseActivities.GetAll();

            IEnumerable<ExerciseModel> currentExercises = exercises.Select(e => new ExerciseModel {
                Name = e.Name,
                Reps = e.Reps,
                Sets = e.Sets,
                Weight = e.WeightInKg,
                DayId = e.Day.Id
            });

            IEnumerable<DayIndexListingModel> listingResult = days.Select(d => new DayIndexListingModel
            {
                Id = d.Id,
                Name = d.Name,
                IsRestDay = d.IsRestDay,
                Exercises = currentExercises.Where(ex => ex.DayId == d.Id)
            });

            DayListModel model = new DayListModel
            {
                Days = listingResult
            };

            return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
