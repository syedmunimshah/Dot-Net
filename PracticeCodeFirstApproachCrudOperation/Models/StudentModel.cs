using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PracticeCodeFirstApproachCrudOperation.Models
{
    public class StudentModel
    {
        [Key]
        [Column("Student ID")]
        public int ID { get; set; }
        [Required]
        [Column("Student Name",TypeName ="Varchar(100)"),StringLength(50)]
        public string Name { get; set; }
        [Required]
        [Column("Student Age",TypeName="varchar(100)"),StringLength(10)]
        public string Age { get; set; }
        [Required]
        [Column("Student Numer", TypeName = "Varchar(100)"), StringLength(30)]
        public string Number { get; set; }
        [Required]
        [Column("Student Email", TypeName = "Varchar(100)"), StringLength(50)]
        public string Email { get; set; }
        [Required]
        [Column("Student Password", TypeName = "Varchar(100)")]
        public string Password { get; set; }
        [Required]
        [Column("Student Confirm Password", TypeName = "Varchar(100)")]

        public string Con_Password { get; set; }
    }
}
