using Data.Repositories;
using Domain.Entities;

namespace Domain.Commands.Handlers;

public class CreateTaskHandler : ICreateTaskHandler
{
    private readonly ITaskRepository _taskRepository;

    public CreateTaskHandler(ITaskRepository taskRepository)
    {
        _taskRepository = taskRepository;
    }

    public async Task<CreateTaskResponse> Handle(CreateTaskRequest request)
    {
        var task = new Tasks(request.Title, request.Description);

        await _taskRepository.CreateAsync(task);
        
        return new CreateTaskResponse
        {
            Id = task.id,
            Title = request.Title,
            Description = request.Description
        };
    }
}