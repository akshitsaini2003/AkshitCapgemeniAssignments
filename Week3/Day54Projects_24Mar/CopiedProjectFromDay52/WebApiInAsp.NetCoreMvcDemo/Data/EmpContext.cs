using Microsoft.EntityFrameworkCore;
using WebApiInAsp.NetCoreMvcDemo.Models;

namespace WebApiInAsp.NetCoreMvcDemo.Data
{
    public class EmpContext : DbContext
    {
        public EmpContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Employee> Employees { get; set; }
        
    }
}
