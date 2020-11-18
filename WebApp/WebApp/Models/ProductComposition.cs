namespace WebApp.Models
{
    public class ProductComposition
    {
        public int ProductId { get; set; }
        public int PurchasedProductId { get; set; }
        public int PurchasedProductAmount { get; set; }
    }
}