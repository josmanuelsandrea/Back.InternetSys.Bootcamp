﻿using System;
using System.Collections.Generic;

namespace BackendBootcamp.DBModels;

public partial class Statuscontract
{
    public string Statusid { get; set; } = null!;

    public string Description { get; set; } = null!;

    public virtual ICollection<Contract> Contracts { get; set; } = new List<Contract>();
}
