namespace Domain.Commands.Handlers;

public interface ICommandsTaskHandler
{
    Task<CreateTaskResponse> Handle(CreateTaskRequest request);
    Task Handle(int id);
    Task<UpdateTaskResponse> Handle(int id, UpdateTaskRequest request);

}