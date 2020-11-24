#nullable disable

namespace WebApp.Models
{
    public partial class ThemeComposition
    {
        public int ThemeId { get; set; }
        public int ProductId { get; set; }
        public int ProductAmount { get; set; }

        public virtual Product Product { get; set; }
        public virtual Theme Theme { get; set; }
    }
}
