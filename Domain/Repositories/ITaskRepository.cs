using Domain.Entities;

namespace Data.Repositories;

public interface ITaskRepository
{
    Task<Tasks> GetByIdAsync(int id);
    Task<ICollection<Tasks>> GetTasksAsync();
    Task<Tasks> CreateAsync(Tasks tasks);
    Task EditAsync(Tasks tasks);
    Task DeleteAsync(Tasks tasks);
}