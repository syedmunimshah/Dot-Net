using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ImageUploadingAndRetrievingDatabase.Models;

public partial class Product
{
    [Required]
    public int Id { get; set; }
    [Required]
    public string Name { get; set; } = null!;
    [Required]
    public int Price { get; set; }
    [Required]
    public string Image { get; set; } = null!;
}
