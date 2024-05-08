using System;
using System.Collections.Generic;

namespace DropDown.Models;

public partial class EmployeeInfo
{
    public int EmpId { get; set; }

    public string? EmpFname { get; set; }

    public string? EmpLname { get; set; }

    public string? Department { get; set; }

    public string? Project { get; set; }

    public string? Address { get; set; }

    public DateTime? Dob { get; set; }

    public string? Gender { get; set; }
}
