using System.ComponentModel.DataAnnotations;

namespace ImageUploadingAndRetrievingDatabase.Models
{
    public class ProductViewModel
    {
        [Required]
        public int Id { get; set; }
        [Required]

        public string Name { get; set; } = null!;
        [Required]
        public int Price { get; set; }
        [Required]
        public IFormFile Photo { get; set; } = null!;
    }
}
