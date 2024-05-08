using System;
using System.Collections.Generic;

namespace DropDown.Models;

public partial class EmployeePosition
{
    public int? EmpId { get; set; }

    public string? EmpPosition { get; set; }

    public string? DateOfJoining { get; set; }

    public string? Salary { get; set; }

    public virtual EmployeeInfo? Emp { get; set; }
}
