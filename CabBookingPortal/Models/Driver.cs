using System;
using System.Collections.Generic;

namespace CabBookingPortal.Models;

public partial class Driver
{
    public int DriverId { get; set; }

    public string DriverName { get; set; } = null!;

    public int? VehicleId { get; set; }

    public string DriverGender { get; set; } = null!;

    public bool DriverStatus { get; set; }

    public string DriverPhone { get; set; } = null!;

    public string DriverBloodgrp { get; set; } = null!;

    public virtual Vehicle? Vehicle { get; set; }
}
