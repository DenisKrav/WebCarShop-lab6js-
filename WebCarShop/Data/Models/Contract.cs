using System;
using System.Collections.Generic;

namespace WebCarShop.Data.Models;

public partial class Contract
{
    public int IdContract { get; set; }

    public DateTime DateTransaction { get; set; }

    public int IdClient { get; set; }

    public int IdDealer { get; set; }

    public int IdLot { get; set; }

    public decimal ActualPrice { get; set; }

    public virtual Client IdClientNavigation { get; set; } = null!;

    public virtual Dealer IdDealerNavigation { get; set; } = null!;

    public virtual Car IdLotNavigation { get; set; } = null!;
}
