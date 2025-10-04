using Microsoft.EntityFrameworkCore;
using TodoMvc.Models;

namespace TodoMvc.Data
{
    public class TodoContext : DbContext
    {
        public TodoContext(DbContextOptions<TodoContext> options) : base(options) { }

        public DbSet<TodoItem> Todos { get; set; } = null!;
    }
}
