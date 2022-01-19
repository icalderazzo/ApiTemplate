using Core.Interfaces.Infrastructure.Repositories;
using Core.Interfaces.Services;
using Core.Model;

namespace Core.Services
{
    public class WorkoutService : ServiceBase<Workout>, IWorkoutService
    {
        private readonly IWorkoutRepository _workoutRepository;
        public WorkoutService(
            IWorkoutRepository workoutRepository) : base(workoutRepository)
        {
            _workoutRepository = workoutRepository;
        }
    }
}
