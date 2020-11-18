using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApp.Models
{
    public class Tag
    {
        public int Id { get; set; }
        [StringLength(20)]
        public string Name { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}