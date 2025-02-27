namespace ConvinenceStore.Models.DTO
{
    public class SaleDTO
    {
        public long IdSale { get; set; }

        public DateTime SaleDate { get; set; }

        public double SaleTotal { get; set; }

        public long? IdUser { get; set; }
    }
}
