using DevTask.Application.DTOs;
using DevTask.Domain.Entities;
using DevTask.Domain.Repositories;
using DevTask.Domain.Enums;

namespace DevTask.Application.Services;

public class TaskService(ITaskRepository repository)
{
    public async Task<TaskItem> CreateTaskAsync(CreateTaskDto dto)
    {
        var task = new TaskItem(dto.Title, dto.Description);
        await repository.AddAsync(task);
        return task;
    }

    public async Task MoveTaskAsync(Guid id, KanbanStatus newStatus)
    {
        var task = await repository.GetByIdAsync(id);
        if (task is null) throw new Exception("Tarea no encontrada"); 

        task.MoveTo(newStatus);
        await repository.UpdateAsync(task);
    }
    
    public async Task<bool> DeleteTaskAsync(Guid id) 
    {
        var task = await repository.GetByIdAsync(id); 

        if (task == null) 
        {
            return false; 
        }

   
        await repository.DeleteAsync(task); 
    
        return true; 
    }
    
    public async Task<IEnumerable<TaskItem>> GetBoardAsync()
    {
        return await repository.GetAllAsync();
    }
}