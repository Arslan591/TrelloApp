using Microsoft.EntityFrameworkCore;
using TrelloApp.Model;

namespace TrelloApp.Data
{
    public class DataContext : DbContext

    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<TaskState> Taskst { get; set; }
    }
}
