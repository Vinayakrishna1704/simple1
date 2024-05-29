using System;
using System.Collections.Generic;

namespace CabBookingPortal.Models;

public partial class VehicleStatus
{
    public int VehicleId { get; set; }

    public DateOnly BookingDate { get; set; }

    public int IncomingApproved { get; set; }

    public int OutgoingApproved { get; set; }

    public virtual Vehicle Vehicle { get; set; } = null!;
}
