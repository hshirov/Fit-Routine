using Data;
using Data.Models;
using Moq;
using NUnit.Framework;
using Services;
using System.Collections.Generic;
using UnitTests.Helpers;

namespace UnitTests
{
    [TestFixture]
    public class ExerciseServiceTests
    {
        ExerciseService service;
        Mock<FitRoutineContext> dbContext;
        List<Day> days;
        List<Exercise> exercises;

        [SetUp]
        public void SetUp()
        {
            days = new List<Day>
            {
                new Day { Id = 1, Name = "Monday", IsRestDay = false },
                new Day { Id = 2, Name = "Tuesday", IsRestDay = true }
            };
            exercises = new List<Exercise>
            {
                new Exercise { Id = 1, Day = days[0], Name = "Bench", Reps = 10, Sets = 4, WeightInKg = 100 }
            };

            dbContext = new Mock<FitRoutineContext>();

            dbContext.Setup(p => p.Days)
                .Returns(DbContextMock.GetQueryableMockDbSet(days));

            dbContext.Setup(p => p.Exercises)
                .Returns(DbContextMock.GetQueryableMockDbSet(exercises));

            dbContext.Setup(p => p.SaveChanges()).Returns(1);

            service = new ExerciseService(dbContext.Object);
        }

        [Test]
        public void GetAll_NotNull()
        {
            IEnumerable<Exercise> exercises = service.GetAll();

            Assert.That(exercises, Is.Not.Null);
        }

        [Test]
        public void Get_NotNull()
        {
            Exercise exercise = service.Get(1);

            Assert.That(exercise, Is.Not.Null);
        }
    }
}
