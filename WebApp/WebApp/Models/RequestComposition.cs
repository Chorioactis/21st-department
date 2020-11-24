#nullable disable

namespace WebApp.Models
{
    public partial class RequestComposition
    {
        public int RequestId { get; set; }
        public int PurchasedProductId { get; set; }
        public int PurchasedProductAmount { get; set; }

        public virtual PurchasedProduct PurchasedProduct { get; set; }
        public virtual Request Request { get; set; }
    }
}
