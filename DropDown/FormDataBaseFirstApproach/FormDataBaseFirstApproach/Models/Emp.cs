using System;
using System.Collections.Generic;

namespace FormDataBaseFirstApproach.Models;

public partial class Emp
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Email { get; set; }

    public string? Password { get; set; }

    public int? GenderId { get; set; }

    public virtual Gender? Gender { get; set; }
}
