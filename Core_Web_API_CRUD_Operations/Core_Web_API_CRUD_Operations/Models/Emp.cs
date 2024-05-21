using System;
using System.Collections.Generic;

namespace Core_Web_API_CRUD_Operations.Models;

public partial class Emp
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Gender { get; set; }

    public string? Age { get; set; }

    public string? Standard { get; set; }

    public string? FatherName { get; set; }
}
