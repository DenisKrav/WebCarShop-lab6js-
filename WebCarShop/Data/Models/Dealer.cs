using System;
using System.Collections.Generic;

namespace WebCarShop.Data.Models;

public partial class Dealer
{
    public int IdDealer { get; set; }

    public string NameDealer { get; set; } = null!;

    public string Address { get; set; } = null!;

    public string Telephone { get; set; } = null!;

    public virtual ICollection<Contract> Contracts { get; } = new List<Contract>();
}
