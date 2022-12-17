using System;
using System.Collections.Generic;

namespace WebCarShop.Data.Models;

public partial class Carcase
{
    public int IdCarcase { get; set; }

    public string TypeCarcase { get; set; } = null!;

    public virtual ICollection<Model> Models { get; } = new List<Model>();
}
