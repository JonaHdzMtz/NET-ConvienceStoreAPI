using System;
using System.Collections.Generic;

namespace ConvinenceStore.Models;

public partial class Product
{
    public long IdProduct { get; set; }

    public string ProductName { get; set; } = null!;

    public string? ProductDescription { get; set; }

    public double Price { get; set; }

    public long? Stock { get; set; }

    public virtual ICollection<ProductSale> ProductSales { get; set; } = new List<ProductSale>();
}
