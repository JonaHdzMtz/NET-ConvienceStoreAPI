using System;
using System.Collections.Generic;

namespace ConvinenceStore.Models;

public partial class Sale
{
    public long IdSale { get; set; }

    public DateTime SaleDate { get; set; }

    public double SaleTotal { get; set; }

    public long? IdUser { get; set; }

    public virtual User? IdUserNavigation { get; set; }

    public virtual ICollection<ProductSale> ProductSales { get; set; } = new List<ProductSale>();
}
