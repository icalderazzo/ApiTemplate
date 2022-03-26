using System.Collections.Generic;
using Core.Interfaces.Infrastructure.Repositories;
using Core.Interfaces.Services;
using Core.Model;
using Core.Services;
using Xunit;
using Moq;

namespace Tests.Services
{
    public class WorkoutServiceTests
    {
        private readonly IWorkoutService _workoutService;
        private readonly Mock<IWorkoutRepository> _workoutRepositoryMock = new();

        public WorkoutServiceTests()
        {
            _workoutService = new WorkoutService(_workoutRepositoryMock.Object);
        }

        [Fact]
        public void GetAll_Ok()
        {
            _workoutRepositoryMock
                .Setup(r => r.GetAll())
                .Returns(GetListOfWorkouts());

            var workouts = _workoutService.GetAll();

            Assert.Equal(2, workouts.Count);
        }

        private List<Workout> GetListOfWorkouts()
        {
            var exercises1 = new List<Exercise>()
            {
                new Exercise() { Id = 1, Name = "Pull-ups" },
                new Exercise() { Id = 2, Name = "Sit-ups"}
            };

            var exercises2 = new List<Exercise>()
            {
                new Exercise() { Id = 1, Name = "Jumping Jacks" },
                new Exercise() { Id = 2, Name = "Burpies"}
            };
            return new List<Workout>()
            {
                new Workout() { Id = 1, Exercises = exercises1 },
                new Workout() { Id = 2, Exercises = exercises2 }
            };
        }
    }
}