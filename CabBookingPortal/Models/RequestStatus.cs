﻿using System;
using System.Collections.Generic;

namespace CabBookingPortal.Models;

public partial class RequestStatus
{
    public int StatusId { get; set; }

    public string StatusName { get; set; } = null!;

    public virtual ICollection<Request> Requests { get; set; } = new List<Request>();
}
