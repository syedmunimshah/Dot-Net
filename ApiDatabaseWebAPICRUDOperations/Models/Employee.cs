﻿using System;
using System.Collections.Generic;

namespace ApiDatabaseWebAPICRUDOperations.Models;

public partial class Employee
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string ConformPassword { get; set; } = null!;

    public int? GenderId { get; set; }

    public virtual Gender? Gender { get; set; }
}
