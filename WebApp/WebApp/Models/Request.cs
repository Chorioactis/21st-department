using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApp.Models
{
    public class Request
    {
        public int Id { get; set; }
        [StringLength(20)]
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreationDate { get; set; }
        public int CreatedBy { get; set; }
        public virtual ICollection<RequestComposition> PurchasedProducts { get; set; }
    }
}