using System;
using System.Collections.Generic;

namespace FormDataBaseFirstApproach.Models;

public partial class Gender
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<Emp> Emps { get; set; } = new List<Emp>();
}
