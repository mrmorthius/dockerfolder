using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using todoAPI.Models;
using todoAPI.Services;


namespace todoAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TodosController : ControllerBase
{
    private readonly ITodosService _todoService;

    public TodosController(ITodosService todoService)
    {
        _todoService = todoService;
    }

    // GET /api/todos: Hent alle Todo-oppgaver.
    [HttpGet]
    public IActionResult GetTodos()
    {
        var todos = _todoService.GetTodos();
        return Ok(todos);
    }

    // GET /api/todos/completed: Henter alle todos som er fullførte.
    [HttpGet("completed")]
    public IActionResult GetCompletedTodos()
    {
        var todos = _todoService.GetCompletedTodos();
        return Ok(todos);
    }

    //GET /api/todos/{id}: Hent en spesifikk Todo-oppgave basert på ID.
    [HttpGet("{id}")]
    public IActionResult GetTodo(int id)
    {
        var todo = _todoService.GetTodo(id);
        return Ok(todo);
    }

    // POST /api/todos: Opprett en ny Todo-oppgave.
    [HttpPost]
    public IActionResult CreateTodo(Todo todo)
    {
        if (!ModelState.IsValid)
        {
            throw new ValidationException("Feil i validering av data");
        }
        _todoService.AddTodo(todo);
        return CreatedAtAction(nameof(GetTodo), new { id = todo.Id }, todo);
    }

    //PUT /api/todos/{id}: Oppdater en Todo-oppgave basert på ID.
    [HttpPut("{id}")]
    public IActionResult UpdateTodo(int id, Todo updatedTodo)
    {
        if (!ModelState.IsValid)
        {
            var errors = ModelState.Values
            .SelectMany(v => v.Errors)
            .Select(e => e.ErrorMessage)
            .ToList();

            var errorMessage = string.Join(". ", errors);
            throw new ValidationException(errorMessage);
        }
        _todoService.UpdateTodo(id, updatedTodo);
        return NoContent();
    }

    //DELETE /api/todos/{id}:
    [HttpDelete("{id}")]
    public IActionResult DeleteTodo(int id)
    {
        _todoService.DeleteTodo(id);
        return NoContent();
    }
}
