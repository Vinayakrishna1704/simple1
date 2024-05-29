using System;
using System.Collections.Generic;

namespace CabBookingPortal.Models;

public partial class Employee
{
    public int EmpId { get; set; }

    public string Username { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string Gender { get; set; } = null!;

    public string Department { get; set; } = null!;

    public bool EmpStatus { get; set; }

    public string EmpAddress { get; set; } = null!;

    public bool IsAdmin { get; set; }

    public byte[]? Pfp { get; set; }

    public int? CostCode { get; set; }

    public int? ShiftId { get; set; }

    public int? EmpType { get; set; }

    public virtual CostCenter? CostCodeNavigation { get; set; }

    public virtual EmployeeType? EmpTypeNavigation { get; set; }

    public virtual ICollection<Request> Requests { get; set; } = new List<Request>();

    public virtual Shift? Shift { get; set; }
}
