using System;
using System.Collections.Generic;

namespace ThreeLayerArchitecture.DAL;

public partial class Employee
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public int? Salary { get; set; }
}
