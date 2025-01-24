using todoAPI.Models;

namespace todoAPI.Repositories
{
    public interface ITodoRepository
    {
        IQueryable<Todo> GetTodos();
        Todo? GetTodo(int id);
        void AddTodo(Todo todo);
        void UpdateTodo(Todo todo);
        void DeleteTodo(Todo todo);
    }
}