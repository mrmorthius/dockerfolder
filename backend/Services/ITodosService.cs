using todoAPI.Models;

namespace todoAPI.Services
{
    public interface ITodosService
    {
        IEnumerable<Todo> GetTodos();
        IEnumerable<Todo> GetCompletedTodos();
        Todo? GetTodo(int id);
        void AddTodo(Todo todo);
        void UpdateTodo(int id, Todo todo);
        void DeleteTodo(int id);
    }
}