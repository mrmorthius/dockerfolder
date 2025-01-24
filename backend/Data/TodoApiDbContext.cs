using Microsoft.EntityFrameworkCore;
using todoAPI.Models;

namespace todoAPI.Data
{
    public class TodoApiDbContext : DbContext
    {
        public TodoApiDbContext(DbContextOptions<TodoApiDbContext> options) : base(options) { }
        public DbSet<Todo> todos { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Todo>().HasData(
                new Todo { Id = 1, Title = "Vaske hus", Description = "Vask bad og kjøkken", Completed = false },
                new Todo { Id = 2, Title = "Rydde rommet", Description = "Rommet ser ikke ut", Completed = false },
                new Todo { Id = 3, Title = "Vaske bil", Description = "Bilen er skitten" }
            );
        }
    }
}