using Domain.Entities;

namespace Application.Services;

public interface ITasksServices
{
    Task<Tasks> CreateAsync(Tasks tasks);
    Task<ICollection<Tasks>> GetAllAsync();
    Task<Tasks> GetOneAsync(int id);
    Task DeleteAsync(Tasks tasks);
    Task UpdateAsync(Tasks tasks);
}