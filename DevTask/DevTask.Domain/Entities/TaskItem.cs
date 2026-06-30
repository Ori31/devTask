using DevTask.Domain.Enums;

namespace DevTask.Domain.Entities;

public class TaskItem {
    public Guid Id { get; private set; }
    public string Title { get; private set; }
    public string Description { get; private set; }
    public KanbanStatus Status { get; private set; } 
    public DateTime CreatedAt { get; private set; }
    
    
    public TaskItem(string title, string description)
    {
        Id = Guid.NewGuid();
        Title = title;
        Description = description;
        Status = KanbanStatus.Todo; 
        CreatedAt = DateTime.UtcNow;
    }

    public void MoveTo(KanbanStatus newStatus)
    {
        Status = newStatus;
    }
    
}

