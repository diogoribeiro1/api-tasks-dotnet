using Data.Context;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories;

public class TasksRepository : ITaskRepository
{
    private readonly ApplicationDbContext _db;

    public TasksRepository(ApplicationDbContext db)
    {
        _db = db;
    }
    
    public async Task<Tasks> GetByIdAsync(int id)
    {
        return await _db.Tasks.FindAsync(id); 
    }

    public async Task<ICollection<Tasks>> GetTasksAsync()
    {
       return await _db.Tasks.ToListAsync();
    }

    public async Task<Tasks> CreateAsync(Tasks tasks)
    {
        _db.Add(tasks);
        await _db.SaveChangesAsync();
        return tasks;
    }

    public async Task EditAsync(Tasks tasks)
    {
        _db.Update(tasks);
        await _db.SaveChangesAsync();
    }

    public async Task DeleteAsync(Tasks task)
    {
        _db.Remove(task);
        await _db.SaveChangesAsync();
    }
}