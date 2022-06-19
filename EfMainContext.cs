using entity_framework_minimal_example.models;
using Microsoft.EntityFrameworkCore;

namespace entity_framework_minimal_example
{
    public class EfMainContext : DbContext
    {
        public EfMainContext(DbContextOptions options) : base(options) { }

        public DbSet<CategoryModel> Categories { get; set; }
        public DbSet<Task> Tasks { get; set; }
    }
}