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
    
    public async Task DeleteAsync(int id)
    {
        var payload = await GetOneAsync(id);
        await _tasksRepository.DeleteAsync(payload);
    }
    
    public async Task UpdateAsync(int id, Tasks task)
    {
        var payloadToUpdate = await GetOneAsync(id);
        payloadToUpdate.Title = task.Title;
        payloadToUpdate.Description = task.Description;
        await _tasksRepository.EditAsync(payloadToUpdate);
    }
}