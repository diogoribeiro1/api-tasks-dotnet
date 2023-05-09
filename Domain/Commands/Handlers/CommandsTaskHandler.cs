using Data.Repositories;
using Domain.Entities;

namespace Domain.Commands.Handlers;

public class CommandsTaskHandler : ICommandsTaskHandler
{
    private readonly ITaskRepository _taskRepository;

    public CommandsTaskHandler(ITaskRepository taskRepository)
    {
        _taskRepository = taskRepository;
    }

    public async Task<CreateTaskResponse> Handle(CreateTaskRequest request)
    {
        var task = new Tasks(request.Title, request.Description);

        await _taskRepository.CreateAsync(task);
        
        return new CreateTaskResponse
        {
            Id = task.Id,
            Title = request.Title,
            Description = request.Description
        };
    }

    public async Task Handle(int id)
    {
        var taskToDelete = await _taskRepository.GetByIdAsync(id);
        if (taskToDelete == null)
        {
            throw new Exception();
        }
        _taskRepository.DeleteAsync(taskToDelete);
    }

    public async Task<UpdateTaskResponse> Handle(int id, UpdateTaskRequest request)
    {
        var payloadToUpdate = await _taskRepository.GetByIdAsync(id);
        payloadToUpdate.Title = request.Title;
        payloadToUpdate.Description = request.Description;
        await _taskRepository.EditAsync(payloadToUpdate);
        return new UpdateTaskResponse()
        {
            Id = payloadToUpdate.Id,
            Title = payloadToUpdate.Title,
            Description = payloadToUpdate.Description
        };
    }
}