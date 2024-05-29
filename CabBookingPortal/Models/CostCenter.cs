using System;
using System.Collections.Generic;

namespace CabBookingPortal.Models;

public partial class CostCenter
{
    public int CostCode { get; set; }

    public string CenterName { get; set; } = null!;

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();

    public virtual ICollection<Request> Requests { get; set; } = new List<Request>();
}
