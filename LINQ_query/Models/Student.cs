using System;
using System.Collections.Generic;

namespace LINQ_query.Models;

public partial class Student
{
    public int EmployeeId { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string? City { get; set; }
}
