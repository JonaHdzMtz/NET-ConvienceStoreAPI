namespace ConvinenceStore.Models.DTO
{
    public class ProductSaleDTO
    {
        public long IdProductSale { get; set; }

        public long? IdSale { get; set; }

        public long? IdProduct { get; set; }

        public double? UnitPrice { get; set; }

        public long? Amount { get; set; }

        public double? Subtotal { get; set; }
    }
}
