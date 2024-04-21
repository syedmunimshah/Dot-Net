using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CodeFirstApproch.Models
{
    public class Employee
    {


        [Key]
        public int Id { get; set; }
        [Column(TypeName = "nvarchar(100)"),StringLength(50)]
        public string name { get; set; }
        [Column(TypeName = "nvarchar(100)"), StringLength(50)]
        public string email { get; set; }
        [Column(TypeName = "nvarchar(100)"), StringLength(50)]
        public string password { get; set; }
        [Column("Conform Password", TypeName = "nvarchar(100)"), StringLength(50)]
        public string conformpassword { get; set; }

    }
}
