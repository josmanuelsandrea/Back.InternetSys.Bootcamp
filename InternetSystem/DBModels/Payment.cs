﻿using System;
using System.Collections.Generic;

namespace InternetSystem.DBModels;

public partial class Payment
{
    public int Paymentid { get; set; }

    public DateTime Paymentdate { get; set; }

    public int Clientid { get; set; }

    public virtual Client Client { get; set; } = null!;
}
