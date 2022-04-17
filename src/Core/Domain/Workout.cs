
namespace Core.Domain
{
    public class Workout : BaseModel
    {
        public int Id { get; set; }
        public List<Exercise> Exercises { get; set; } = new();
    }
}