using System.ComponentModel.DataAnnotations;

namespace CRUD_ADO_DotNET.Models
{
    public class Employess
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string name { get; set; }
        [Required]
        public string gender { get; set; }
        [Required]
        public int age { get; set; }
        [Required]
        public string designation { get; set; }
        [Required]
        public string city { get; set; }
    }
}
