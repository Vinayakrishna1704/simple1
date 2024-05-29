using System;
using System.Collections.Generic;

namespace CabBookingPortal.Models;

public partial class Vehicle
{
    public int VehicleId { get; set; }

    public int? ShiftId { get; set; }

    public int? RouteName { get; set; }

    public int MaxCapacity { get; set; }

    public string VehicleNumber { get; set; } = null!;

    public virtual ICollection<Driver> Drivers { get; set; } = new List<Driver>();

    public virtual ICollection<Request> Requests { get; set; } = new List<Request>();

    public virtual Route? RouteNameNavigation { get; set; }

    public virtual Shift? Shift { get; set; }

    public virtual VehicleStatus? VehicleStatus { get; set; }
}
