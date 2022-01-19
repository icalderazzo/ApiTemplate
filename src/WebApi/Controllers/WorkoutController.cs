using Core.Interfaces.Services;
using Core.Model;

namespace WebApi.Controllers
{
    public class WorkoutController : GenericController<Workout>
    {
        private readonly IWorkoutService _workoutService;

        public WorkoutController(
            IWorkoutService workoutService) : base(workoutService)
        {
            _workoutService = workoutService;
        }
    }
}
