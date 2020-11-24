using System.Collections.Generic;

#nullable disable

namespace WebApp.Models
{
    public partial class User
    {
        public User()
        {
            ProductProductCreatedByNavigations = new HashSet<Product>();
            ProductProductDeletedByNavigations = new HashSet<Product>();
            PurchasedProductPurchasedProductCreatedByNavigations = new HashSet<PurchasedProduct>();
            PurchasedProductPurchasedProductDeletedByNavigations = new HashSet<PurchasedProduct>();
            Requests = new HashSet<Request>();
            ThemeThemeCreatedByNavigations = new HashSet<Theme>();
            ThemeThemeDeletedByNavigations = new HashSet<Theme>();
        }

        public int UserId { get; set; }
        public string UserLogin { get; set; }
        public int UserPasswordSalt { get; set; }
        public string UserPasswordHash { get; set; }

        public virtual ICollection<Product> ProductProductCreatedByNavigations { get; set; }
        public virtual ICollection<Product> ProductProductDeletedByNavigations { get; set; }
        public virtual ICollection<PurchasedProduct> PurchasedProductPurchasedProductCreatedByNavigations { get; set; }
        public virtual ICollection<PurchasedProduct> PurchasedProductPurchasedProductDeletedByNavigations { get; set; }
        public virtual ICollection<Request> Requests { get; set; }
        public virtual ICollection<Theme> ThemeThemeCreatedByNavigations { get; set; }
        public virtual ICollection<Theme> ThemeThemeDeletedByNavigations { get; set; }
    }
}
