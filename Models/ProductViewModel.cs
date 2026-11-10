namespace thuchanh3.Models
{
    public class ProductViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; } = string.Empty;
        public String? CategoryName { get; set; }= string.Empty;
    }
}
