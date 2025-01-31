namespace ConvinenceStore.Models.DTO
{
    public class ProductDTO
    {
        public long IdProduct { get; set; }

        public string ProductName { get; set; } = null!;

        public string? ProductDescription { get; set; }

        public double Price { get; set; }

        public long? Stock { get; set; }
    }
}
