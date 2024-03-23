﻿using System;
using System.Collections.Generic;

namespace InternetSystem.DBModels;

public partial class Methodpayment
{
    public int Methodpaymentid { get; set; }

    public string Description { get; set; } = null!;

    public virtual ICollection<Contract> Contracts { get; set; } = new List<Contract>();
}
