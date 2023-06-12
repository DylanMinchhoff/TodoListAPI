using TodoListAPI.Data;
using TodoListAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace TodoListAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TodoTaskController : Controller {
    private readonly TodoTaskDBContext _dbContext;

    public TodoTaskController(TodoTaskDBContext dbContext) {
        this._dbContext = dbContext;
    }

    [HttpGet]
    public async Task<IActionResult> GetTodoTask() {
        return Ok(await _dbContext.TodoTasks.ToListAsync());
    }

    [HttpPost]
    public async Task<IActionResult> AddTodoTask([FromBody] AddTodoTask addTodoTask) {
        Console.WriteLine("name: {0}\npriority: {1}\ntaskDescription: {2}\ndueDate: {3}\n", addTodoTask.taskName, addTodoTask.priority, addTodoTask.taskDescription, addTodoTask.dueDate);
        TodoTask newTodoTask = new TodoTask(){
            id = Guid.NewGuid(),
            taskName = addTodoTask.taskName,
            priority = addTodoTask.priority,
            taskDescription = addTodoTask.taskDescription,
            dueDate = addTodoTask.dueDate
        };

        await _dbContext.TodoTasks.AddAsync(newTodoTask);
        await _dbContext.SaveChangesAsync();

        return Ok(newTodoTask);
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteTodoTask(Guid id) {
        // unsafe code, possible SQL injection
        var obj = _dbContext.TodoTasks.Find(id);
        if (obj == null) return NotFound();

        _dbContext.TodoTasks.Remove(obj);
        await _dbContext.SaveChangesAsync();
        return Ok(obj);

    }
}