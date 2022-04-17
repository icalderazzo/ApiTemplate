namespace WebApi.Contracts.Responses;

public class ExerciseResponse : BaseResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Instructions { get; set; } = string.Empty;
}