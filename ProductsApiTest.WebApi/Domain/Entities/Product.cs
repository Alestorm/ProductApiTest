namespace ProductsApiTest.WebApi.Domain.Entities
{
    public class Product
    {
        public int IdProduct { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
