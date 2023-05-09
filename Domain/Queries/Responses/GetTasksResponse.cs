using Domain.Entities;

namespace Domain.Queries.Responses;

public class GetTasksResponse
{
    public List<Tasks> TasksList { get; set; }
}