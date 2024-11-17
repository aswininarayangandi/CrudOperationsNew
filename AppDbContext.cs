using CrudOperations.Models;
using Microsoft.EntityFrameworkCore;

namespace CrudOperations
{
    public class AppDbContext:DbContext
    {
        public DbSet<User> users { get; set; }
        public DbSet<Product> products { get; set; }

        public DbSet<AuditLog> auditLogs { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    }
}
