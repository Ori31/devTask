using DevTask.Domain.Entities;
using DevTask.Domain.Repositories;
using DevTask.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace DevTask.Infrastructure.Repositories;

public class TaskRepository(DevTaskDbContext context) : ITaskRepository
{
    public async Task<IEnumerable<TaskItem>> GetAllAsync()
    {
        return await context.Tasks.ToListAsync();
    }

    public async Task<TaskItem?> GetByIdAsync(Guid id)
    {
        return await context.Tasks.FindAsync(id);
    }

    public async Task AddAsync(TaskItem task)
    {
        await context.Tasks.AddAsync(task);
        await context.SaveChangesAsync();
    }
    
    public async Task DeleteAsync(TaskItem task)
    {
        context.Tasks.Remove(task);
        await context.SaveChangesAsync();
    }

    public async Task UpdateAsync(TaskItem task)
    {
        context.Tasks.Update(task);
        await context.SaveChangesAsync();
    }
}