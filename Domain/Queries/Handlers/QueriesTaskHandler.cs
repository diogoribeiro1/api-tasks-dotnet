using Data.Repositories;
using Domain.Queries.Responses;

namespace Domain.Queries.Handlers;

public class QueriesTaskHandler : IQueriesTaskHandler
{
    
    private readonly ITaskRepository _taskRepository;

    public QueriesTaskHandler(ITaskRepository taskRepository)
    {
        _taskRepository = taskRepository;
    }
    
    public async Task<GetByIdTaskResponse> Handle(int id)
    {
        var task = await _taskRepository.GetByIdAsync(id);

        if (task.Equals(null))
            return null;

        return new GetByIdTaskResponse()
        {
            Id = task.Id,
            Title = task.Title,
            Description = task.Description
        };
    }

    public async Task<GetTasksResponse> Handle()
    {
        var tasks = await _taskRepository.GetTasksAsync();

        var response = new GetTasksResponse
        {
            TasksList = tasks.ToList()
        };

        return response;
    }
}