using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CodeFirstApproch.Models
{
    public class Employee
    {

        [Key]
        [Required(ErrorMessage ="id is must")]
        public int Id { get; set; }
        [Column(TypeName = "nvarchar(100)"),StringLength(50)]
        [Required(ErrorMessage = "name is must")]
        public string name { get; set; }
        [Column(TypeName = "nvarchar(100)"), StringLength(50)]
        [Required(ErrorMessage = "email is must")]
        public string email { get; set; }
        [Column(TypeName = "nvarchar(100)"), StringLength(50)]
        [Required(ErrorMessage = "password is must")]
        public string password { get; set; }
        [Column("Conform Password", TypeName = "nvarchar(100)"), StringLength(50)]
        [Required(ErrorMessage = "conformpassword is must")]
        public string conformpassword { get; set; }

    }
}
