namespace WebApi.Contracts.Responses;

public class WorkoutResponse : BaseResponse
{
    public int Id { get; set; }
    public List<ExerciseResponse> Exercises { get; set; } = new List<ExerciseResponse>();
}
