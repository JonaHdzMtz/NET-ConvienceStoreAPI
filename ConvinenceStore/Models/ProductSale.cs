using System;
using System.Collections.Generic;

namespace ConvinenceStore.Models;

public partial class ProductSale
{
    public long IdProductSale { get; set; }

    public long? IdSale { get; set; }

    public long? IdProduct { get; set; }

    public double? UnitPrice { get; set; }

    public long? Amount { get; set; }

    public double? Subtotal { get; set; }

    public virtual Product? IdProductNavigation { get; set; }

    public virtual Sale? IdSaleNavigation { get; set; }
}
