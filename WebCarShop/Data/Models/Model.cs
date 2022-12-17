using System;
using System.Collections.Generic;

namespace WebCarShop.Data.Models;

public partial class Model
{
    public string ModelName { get; set; } = null!;

    public int? IdCarcase { get; set; }

    public int? IdBrand { get; set; }

    public virtual ICollection<Car> Cars { get; } = new List<Car>();

    public virtual Brand? IdBrandNavigation { get; set; }

    public virtual Carcase? IdCarcaseNavigation { get; set; }
}
