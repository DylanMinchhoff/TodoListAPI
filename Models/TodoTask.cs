using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TodoListAPI.Models;

public class TodoTaskBaseModel {
    [Required]
    public string taskName {get; set;}
    // priority should be between 0 to 5
    // POST method checks range, 0 -> 5, 5 least priority
    [Range(0, 5)]
    public int priority {get; set;}
    public string taskDescription {get; set;} = "";
    public DateTime dueDate {get; set;} = DateTime.Today;
}

public class TodoTask : TodoTaskBaseModel{
    [Key]
    public Guid id {get; set;}
}

public class AddTodoTask : TodoTaskBaseModel{}