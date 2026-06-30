using DevTask.Application.DTOs;
using DevTask.Application.Services;
using DevTask.Domain.Enums;
using Microsoft.AspNetCore.Mvc;

namespace DevTask.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TasksController(TaskService taskService) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetBoard()
    {
        var tasks = await taskService.GetBoardAsync();
        return Ok(tasks);
    }

    [HttpPost]
    public async Task<IActionResult> CreateTask([FromBody] CreateTaskDto dto)
    {
        var task = await taskService.CreateTaskAsync(dto);
        return CreatedAtAction(nameof(GetBoard), new { id = task.Id }, task);
    }

    [HttpPatch("{id}/move")]
    public async Task<IActionResult> MoveTask(Guid id, [FromBody] KanbanStatus newStatus)
    {
        await taskService.MoveTaskAsync(id, newStatus);
        return NoContent();
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteTask(Guid id) 
    {
        try
        {
            
            var taskDeleted = await taskService.DeleteTaskAsync(id);

            if (!taskDeleted)
            {
                return NotFound(new { message = "La tarea no existe." });
            }

            return Ok(); 
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = "Error interno", error = ex.Message });
        }
    }
}