namespace Domain.Commands;

public class CreateTaskResponse
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
}