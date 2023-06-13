using System;
using System.Collections.Generic;

namespace ORM_Dapper.Models;

public partial class Employee
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public decimal? Salary { get; set; }

    public DateTime? JoinDate { get; set; }
}
