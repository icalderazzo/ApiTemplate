using AutoMapper;
using Core.Domain;
using Core.Interfaces.Services;
using WebApi.Contracts.Responses;

namespace WebApi.Controllers
{
    public class WorkoutController : GenericController<Workout, WorkoutResponse>
    {
        private readonly IWorkoutService _workoutService;

        public WorkoutController(
            IWorkoutService workoutService,
            ILogger<Workout> logger,
            IMapper mapper) : base(workoutService, logger, mapper)
        {
            _workoutService = workoutService;
        }
    }
}
