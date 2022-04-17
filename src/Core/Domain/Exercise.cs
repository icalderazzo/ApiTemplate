
namespace Core.Domain
{
    public class Exercise : BaseModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Instructions { get; set; }
    }
}
