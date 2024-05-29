using System;
using System.Collections.Generic;

namespace CabBookingPortal.Models;

public partial class EmployeeType
{
    public int TypeId { get; set; }

    public string TypeName { get; set; } = null!;

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
}
