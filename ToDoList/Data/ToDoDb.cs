namespace ToDoList.Data 
{
    using Microsoft.EntityFrameworkCore;
    using ToDoList.Models;
    public class ToDoDb:DbContext
    {
        public DbSet<Task> Task { get; set; }

        private const string ConnectionString = @"Server=***;Database=ToDoDb;Integrated Security=false; User Id=sa;Password=***";

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConnectionString);
        }
    }
}
