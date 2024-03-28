using System;
using System.Collections.Generic;

namespace BackendBootcamp.DBModels;

public partial class Attentionstatus
{
    public int Statusid { get; set; }

    public string Description { get; set; } = null!;

    public virtual ICollection<Attention> Attentions { get; set; } = new List<Attention>();
}
