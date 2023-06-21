using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cashing.Models;

public partial class Employee
{
    public int Id { get; set; }

    public string? Name { get; set; }


    public decimal? Salary { get; set; }

    public DateTime? JoinDate { get; set; }

	[NotMapped]
	public string ErrorMessage { get; set; }
}
