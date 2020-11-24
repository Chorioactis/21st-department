#nullable disable

namespace WebApp.Models
{
    public partial class ProductComposition
    {
        public int ProductId { get; set; }
        public int PurchasedProductId { get; set; }
        public int PurchasedProductAmount { get; set; }

        public virtual Product Product { get; set; }
        public virtual PurchasedProduct PurchasedProduct { get; set; }
    }
}
