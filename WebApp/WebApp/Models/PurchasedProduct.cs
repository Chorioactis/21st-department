using System;
using System.Collections.Generic;

#nullable disable

namespace WebApp.Models
{
    public partial class PurchasedProduct
    {
        public PurchasedProduct()
        {
            ProductCompositions = new HashSet<ProductComposition>();
            RequestCompositions = new HashSet<RequestComposition>();
        }

        public int PurchasedProductId { get; set; }
        public string PurchasedProductVendor { get; set; }
        public string PurchasedProductVendorCode { get; set; }
        public string PurchasedProductShortDescription { get; set; }
        public string PurchasedProductFullDescription { get; set; }
        public string PurchasedProductDocLink { get; set; }
        public DateTime PurchasedProductCreationDate { get; set; }
        public int PurchasedProductCreatedBy { get; set; }
        public bool PurchasedProductDeleted { get; set; }
        public DateTime? PurchasedProductDeletionDate { get; set; }
        public int? PurchasedProductDeletedBy { get; set; }

        public virtual User PurchasedProductCreatedByNavigation { get; set; }
        public virtual User PurchasedProductDeletedByNavigation { get; set; }
        public virtual ICollection<ProductComposition> ProductCompositions { get; set; }
        public virtual ICollection<RequestComposition> RequestCompositions { get; set; }
    }
}
