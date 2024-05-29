using System;
using System.Collections.Generic;

namespace CabBookingPortal.Models;

public partial class Request
{
    public int ReqId { get; set; }

    public DateOnly BookingDate { get; set; }

    public DateOnly CreationDate { get; set; }

    public bool IsPickup { get; set; }

    public bool IsDrop { get; set; }

    public string InputAddress { get; set; } = null!;

    public int? ReqStatus { get; set; }

    public int? EmpId { get; set; }

    public int? CostCode { get; set; }

    public int? VehicleId { get; set; }

    public virtual CostCenter? CostCodeNavigation { get; set; }

    public virtual Employee? Emp { get; set; }

    public virtual RequestStatus? ReqStatusNavigation { get; set; }

    public virtual Vehicle? Vehicle { get; set; }
}
