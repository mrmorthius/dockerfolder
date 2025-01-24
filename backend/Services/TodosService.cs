using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using todoAPI.Models;
using todoAPI.Repositories;

namespace todoAPI.Services;
public class TodosService : ITodosService
{
    private readonly ITodoRepository _todoRepository;

    public TodosService(ITodoRepository todoRepository)
    {
        _todoRepository = todoRepository;
    }

    public IEnumerable<Todo> GetTodos() => _todoRepository.GetTodos().ToList();

    public IEnumerable<Todo> GetCompletedTodos()
    {
        var todos = _todoRepository.GetTodos().Where(t => t.Completed == true).ToList();
        return todos;
    }

    public Todo? GetTodo(int id)
    {
        var todo = _todoRepository.GetTodo(id);
        return todo;
    }


    public void AddTodo(Todo todo)
    {
        if (todo.Completed == true)
        {
            throw new ValidationException("Feil i validering av data: Complete må være false");
        }
        _todoRepository.AddTodo(todo);
    }

    public void UpdateTodo(int id, Todo updatedTodo)
    {
        var todo = GetTodo(id);
        if (todo == null)
        {
            throw new Exception("Todo ikke funnet - kan ikke oppdatere");
        }

        todo.Title = updatedTodo.Title;
        todo.Description = updatedTodo.Description;
        todo.Completed = updatedTodo.Completed;
        _todoRepository.UpdateTodo(todo);
        return;
    }

    public void DeleteTodo(int id)
    {
        var todo = GetTodo(id);
        if (todo == null)
        {
            throw new Exception("Todo ikke funnet - kan ikke slettes");
        }
        _todoRepository.DeleteTodo(todo);
        return;
    }
}