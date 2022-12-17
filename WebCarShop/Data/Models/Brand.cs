using System;
using System.Collections.Generic;

namespace WebCarShop.Data.Models;

public partial class Brand
{
    public string NameBrand { get; set; } = null!;

    public int IdBrand { get; set; }

    public virtual ICollection<Model> Models { get; } = new List<Model>();
}
