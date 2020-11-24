using System;
using System.Collections.Generic;

#nullable disable

namespace WebApp.Models
{
    public partial class Product
    {
        public Product()
        {
            ProductCompositions = new HashSet<ProductComposition>();
            ProductTags = new HashSet<ProductTag>();
            ThemeCompositions = new HashSet<ThemeComposition>();
        }

        public int ProductId { get; set; }
        public string ProductDecimalNumber { get; set; }
        public DateTime ProductCreationDate { get; set; }
        public int ProductCreatedBy { get; set; }
        public bool ProductDeleted { get; set; }
        public DateTime? ProductDeletionDate { get; set; }
        public int? ProductDeletedBy { get; set; }

        public virtual User ProductCreatedByNavigation { get; set; }
        public virtual User ProductDeletedByNavigation { get; set; }
        public virtual ICollection<ProductComposition> ProductCompositions { get; set; }
        public virtual ICollection<ProductTag> ProductTags { get; set; }
        public virtual ICollection<ThemeComposition> ThemeCompositions { get; set; }
    }
}
