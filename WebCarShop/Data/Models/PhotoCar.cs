using System;
using System.Collections.Generic;

namespace WebCarShop.Data.Models;

public partial class PhotoCar
{
    public byte[] Photo { get; set; } = null!;

    public int IdLot { get; set; }

    public virtual Car IdLotNavigation { get; set; } = null!;
}
