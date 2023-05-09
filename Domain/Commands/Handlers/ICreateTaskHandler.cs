namespace Domain.Commands.Handlers;

public interface ICreateTaskHandler
{
    Task<CreateTaskResponse> Handle(CreateTaskRequest request);
}