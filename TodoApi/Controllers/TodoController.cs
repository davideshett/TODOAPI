using Microsoft.AspNetCore.Mvc;
using TodoApi.Interface;
using TodoApi.Models;

namespace TodoApi.Controllers;

[ApiController]
[Route("[controller]")]
public class TodoController : ControllerBase
{
    private readonly ITodoData todoData;

    public TodoController(ITodoData todoData)
    {
        this.todoData = todoData;
    }

    [HttpGet]
    public IActionResult GetTodos()
    {
        return Ok(todoData.GetTodos());
    }

    [HttpGet]
    [Route("{id}")]
    public IActionResult GetTodo(int id)
    {
        var todo = todoData.GetTodo(id);
        if (todo!= null)
        {
            return Ok(todo);
        }
        return NotFound("Id not found");
    }
    
    [HttpPost]
    public IActionResult AddTodo(Todo todo)
    { 
        todoData.AddTodo(todo);
        return Created(HttpContext.Request.Scheme + "://"
            +HttpContext.Request.Host 
            + HttpContext.Request.Path + "/"
            + todo.Id, todo);
    }


    [HttpPatch]
    [Route("{id}")]
    public IActionResult EditTodo(int Id, Todo todo)
    {
        var currentTodo = todoData.GetTodo(Id);
        if(currentTodo!= null)
        {
            todo.Id = currentTodo.Id;
            todoData.EditTodo(todo);
        }
        return Ok(todo);
    }

    [HttpDelete]
    [Route("{id}")]
    public IActionResult DeleteTodo(int Id)
    {
        var todo = todoData.GetTodo(Id);
        if(todo!= null)
        {
            todoData.DeleteTodo(todo);
        }
        return Ok("Todo Deleted Successfully");
    }


    
}
