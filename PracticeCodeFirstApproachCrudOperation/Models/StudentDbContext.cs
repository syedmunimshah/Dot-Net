using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace PracticeCodeFirstApproachCrudOperation.Models
{
    public class StudentDbContext:DbContext
    {
        public StudentDbContext(DbContextOptions option):base(option)
        {

        }
        public DbSet<StudentModel> Students { get; set; }
    }
}
