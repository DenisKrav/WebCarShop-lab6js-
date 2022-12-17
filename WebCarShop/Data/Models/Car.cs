using System;
using System.Collections.Generic;

namespace WebCarShop.Data.Models;

public partial class Car
{
    public int IdLot { get; set; }

    public int? IdCarcase { get; set; }

    public DateTime? YearIssue { get; set; }

    public int? Mileage { get; set; }

    public decimal? Price { get; set; }

    public string? Color { get; set; }

    public string? TypeEngine { get; set; }

    public string? FuelType { get; set; }

    public DateTime? DateIssue { get; set; }

    public string Availability { get; set; } = null!;

    public string ModelName { get; set; } = null!;

    public decimal? EngineCapacity { get; set; }

    public virtual ICollection<Contract> Contracts { get; } = new List<Contract>();

    public virtual Model ModelNameNavigation { get; set; } = null!;

    public virtual PhotoCar? PhotoCar { get; set; }

    public virtual State? State { get; set; }
}
