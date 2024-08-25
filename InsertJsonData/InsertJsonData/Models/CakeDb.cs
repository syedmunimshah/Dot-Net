using Microsoft.EntityFrameworkCore;

namespace InsertJsonData.Models
{
    public class CakeDb:DbContext
    {
        public CakeDb(DbContextOptions<CakeDb> options):base (options)
        {
            
        }
        public DbSet<CakeModel> Cake { get; set; }
    }
}
