using Microsoft.EntityFrameworkCore;

namespace CodeFirstApproch.Models
{
    public class StudentDBContext:DbContext
    {
        public StudentDBContext(DbContextOptions options): base(options)
        {
                
        }
       public DbSet<Employee> Employees { get; set; }
    }
}
