using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LoginFormASPCore6.Models;

public partial class Employee
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Email { get; set; } = null!;

    [DataType(DataType.Password)]
    public string Password { get; set; } = null!;



    public string ConformPassword { get; set; } = null!;
}
