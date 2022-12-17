using System;
using System.Collections.Generic;

namespace WebCarShop.Data.Models;

public partial class State
{
    public string? StateDescription { get; set; }

    public int IdLot { get; set; }

    public virtual Car IdLotNavigation { get; set; } = null!;
}
