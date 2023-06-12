using Microsoft.EntityFrameworkCore;
using TodoListAPI.Models;

namespace TodoListAPI.Data;

public class TodoTaskDBContext : DbContext {
    public TodoTaskDBContext(DbContextOptions<TodoTaskDBContext> options) : base(options) {

    }

    public DbSet<TodoTask> TodoTasks {get; set;}
}