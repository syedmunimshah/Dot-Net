﻿using System;
using System.Collections.Generic;

namespace ApiDatabaseWebAPICRUDOperations.Models;

public partial class Gender
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
}
