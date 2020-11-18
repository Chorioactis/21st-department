using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApp.Models
{
    public class Product
    {
        public int Id { get; set; }
        [StringLength(20)]
        public string DecimalNumber { get; set; }
        public DateTime CreationDate { get; set; }
        public int CreatedBy { get; set; }
        public bool Deleted { get; set; }
        public DateTime DeletionDate { get; set; }
        public int DeletedBy { get; set; }
        public virtual ICollection<Tag> Tags { get; set; }
        public virtual ICollection<ProductComposition> PurchasedProducts { get; set; }
    }
}