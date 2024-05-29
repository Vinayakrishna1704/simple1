using System;
using System.Collections.Generic;

namespace CabBookingPortal.Models;

public partial class Shift
{
    public int ShiftId { get; set; }

    public string ShiftName { get; set; } = null!;

    public TimeOnly ShiftIn { get; set; }

    public TimeOnly ShiftOut { get; set; }

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();

    public virtual ICollection<Vehicle> Vehicles { get; set; } = new List<Vehicle>();
}
