using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q10.TaskManager.Infrastructure.Data
{
    public class PostgreSQLContext : DbContext
    {
        public PostgreSQLContext(DbContextOptions<PostgreSQLContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        //Tablas
        public DbSet<Entities.TaskItem> TaskItems { get; set; }
    }
}
