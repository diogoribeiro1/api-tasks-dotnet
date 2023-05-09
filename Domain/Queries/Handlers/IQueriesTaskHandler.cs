using Domain.Queries.Responses;

namespace Domain.Queries.Handlers;

public interface IQueriesTaskHandler
{
    Task<GetByIdTaskResponse> Handle(int id);
    
    Task<GetTasksResponse> Handle();

}