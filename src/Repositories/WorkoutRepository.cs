using Core.Domain;
using Core.Interfaces.Infrastructure.Repositories;
using DapperDatabaseInterface;

namespace Repositories
{
    public class WorkoutRepository : RepositoryBase<Workout>, IWorkoutRepository
    {
        public WorkoutRepository(
            IDbContext dbContext) : base(dbContext)
        {

        }

        public override List<Workout> GetAll()
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

        public override Task<List<Workout>> GetAllAsync()
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
            
            return Task.Run(() => new List<Workout>()
            {
                new Workout() { Id = 1, Exercises = exercises1 },
                new Workout() { Id = 2, Exercises = exercises2 }   
            });
        }
    }
}
