
namespace Core.Model
{
    public class Workout
    {
        public int Id { get; set; }
        public List<Exercise> Exercises { get; set; } = new();
    }
}
