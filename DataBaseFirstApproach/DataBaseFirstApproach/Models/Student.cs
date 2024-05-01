using System;
using System.Collections.Generic;

namespace DataBaseFirstApproach.Models;

public partial class Student
{
    public int StudentId { get; set; }

    public string StudentName { get; set; } = null!;

    public string StudentAge { get; set; } = null!;

    public string StudentNumer { get; set; } = null!;

    public string StudentEmail { get; set; } = null!;

    public string StudentPassword { get; set; } = null!;

    public string StudentConfirmPassword { get; set; } = null!;
}
