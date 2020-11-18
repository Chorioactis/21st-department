using System;
using System.ComponentModel.DataAnnotations;

namespace WebApp.Models
{
    public class PurchasedProduct
    {
        public int Id { get; set; }
        [StringLength(30)]
        public string Vendor { get; set; }
        [StringLength(20)]
        public string VendorCode { get; set; }
        [StringLength(20)]
        public string ShortDescription { get; set; }
        public string FullDescription { get; set; }
        [StringLength(50)]
        public string DocLink { get; set; }
        public DateTime CreationDate { get; set; }
        public int CreatedBy { get; set; }
        public bool Deleted { get; set; }
        public DateTime DeletionDate { get; set; }
        public int DeletedBy { get; set; }
        
    }
}