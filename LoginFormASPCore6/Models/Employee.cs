using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LoginFormASPCore6.Models;

public partial class Employee
{
    [Required]
    public int Id { get; set; }
    [Required]
    public string Name { get; set; } = null!;

    [Required]
    public string Email { get; set; } = null!;
    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; } = null!;
    [Required]
    public string ConformPassword { get; set; } = null!;
}
