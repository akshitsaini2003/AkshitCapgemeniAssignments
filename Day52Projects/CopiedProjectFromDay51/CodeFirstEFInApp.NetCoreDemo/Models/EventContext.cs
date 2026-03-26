using Microsoft.EntityFrameworkCore;

namespace CodeFirstEFInApp.NetCoreDemo.Models
{
    public class EventContext : DbContext
    {
        public EventContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Author> Authors { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Author1> Authors1 { get; set; }
        public DbSet<Course1> Courses1 { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<UserDetail> UserDetails { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Post> Posts { get; set; }

    }
}
