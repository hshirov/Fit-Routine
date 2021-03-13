using Data;
using FitRoutine.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;

namespace UnitTests
{
    [TestFixture]
    public class ControllerTests
    {
        private Mock<IDay> _days; 
        private Mock<IExercise> _exerciseActivities;
        
        [SetUp]
        public void SetUp()
        {
            _days = new Mock<IDay>();
            _exerciseActivities = new Mock<IExercise>();
        }

        [Test]
        public void Home_Index_IsNotNull()
        {
            HomeController controller = new HomeController(_days.Object, _exerciseActivities.Object);

            ViewResult result = controller.Index() as ViewResult;

            Assert.That(result, Is.Not.Null);
        }

        [Test]
        public void Exercise_Index_IsNotNull()
        {
            ExercisesController controller = new ExercisesController();

            ViewResult result = controller.Index() as ViewResult;

            Assert.That(result, Is.Not.Null);
        }
    }
}