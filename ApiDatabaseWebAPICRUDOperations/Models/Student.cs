﻿using System;
using System.Collections.Generic;

namespace ApiDatabaseWebAPICRUDOperations.Models;

public partial class Student
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Gender { get; set; }

    public string? Age { get; set; }

    public string? Standard { get; set; }

    public string? FatherNeme { get; set; }
}
