using System;
using System.Collections.Generic;

namespace WebCarShop.Data.Models;

public partial class Client
{
    public int IdClient { get; set; }

    public string? Telephone { get; set; }

    public string? Address { get; set; }

    public string NameClient { get; set; } = null!;

    public virtual ICollection<Contract> Contracts { get; } = new List<Contract>();
}
