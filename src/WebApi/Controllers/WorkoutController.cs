using Core.Interfaces.Services;
using Core.Model;

namespace WebApi.Controllers
{
    public class WorkoutController : GenericController<Workout>
    {
        private readonly IWorkoutService _workoutService;

        public WorkoutController(
            IWorkoutService workoutService,
            ILogger<Workout> logger) : base(workoutService, logger)
        {
            _workoutService = workoutService;
        }
    }
}
