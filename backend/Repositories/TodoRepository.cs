using todoAPI.Models;
using todoAPI.Data;

namespace todoAPI.Repositories
{
    public class TodoRepository : ITodoRepository
    {
        private readonly TodoApiDbContext _context;

        public TodoRepository(TodoApiDbContext context)
        {
            _context = context;
        }
        public IQueryable<Todo> GetTodos() => _context.todos;

        public Todo? GetTodo(int id) => _context.todos.FirstOrDefault(t => t.Id == id);

        public void AddTodo(Todo todo)
        {
            _context.todos.Add(todo);
            _context.SaveChanges();
        }

        public void DeleteTodo(Todo todo)
        {
            _context.todos.Remove(todo);
            _context.SaveChanges();
        }


        public void UpdateTodo(Todo todo)
        {
            _context.todos.Update(todo);
            _context.SaveChanges();
        }
    }
}