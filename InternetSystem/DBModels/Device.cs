﻿using System;
using System.Collections.Generic;

namespace InternetSystem.DBModels;

public partial class Device
{
    public int Deviceid { get; set; }

    public string Devicename { get; set; } = null!;

    public int Serviceid { get; set; }

    public virtual Service Service { get; set; } = null!;
}
