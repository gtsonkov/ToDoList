using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoList.Data 
{
    using Microsoft.EntityFrameworkCore;
    using ToDoList.Models;
    public class ToDoDb:DbContext
    {
        public DbSet<Task> Task { get; set; }

        private const string ConnectionString = @"Server=.\TSSQL;Database=ToDoDb;Integrated Security=true;";

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConnectionString);
        }
    }
}
