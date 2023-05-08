using Data.Repositories;
using Domain.Entities;

namespace Application.Services;

public class TasksService : ITasksServices  
{
    private readonly ITaskRepository _tasksRepository;

    public TasksService(ITaskRepository tasksRepository)
    {
        _tasksRepository = tasksRepository;
    }

    public async Task<Tasks> CreateAsync(Tasks tasks)
    {
        return await _tasksRepository.CreateAsync(tasks);
    }

    public async Task<ICollection<Tasks>> GetAllAsync()
    {
        return await _tasksRepository.GetTasksAsync();
    }
    
    public async Task<Tasks> GetOneAsync(int id)
    {
        return await _tasksRepository.GetByIdAsync(id);
    }
    
    public async Task DeleteAsync(Tasks tasks)
    {
        await _tasksRepository.DeleteAsync(tasks);
    }
    
    public async Task UpdateAsync(Tasks tasks)
    {
        await _tasksRepository.EditAsync(tasks);
    }
}