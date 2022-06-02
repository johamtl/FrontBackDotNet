using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;
using FrontBackClassLib;

namespace ASPNETCOREWEBAPI.Data
{
    public class TodoContext : DbContext
    {
        public TodoContext(DbContextOptions<TodoContext> options)
            : base(options)
        {
        }

        public DbSet<TodoItem> TodoItems { get; set; } = null!;
    }
}




