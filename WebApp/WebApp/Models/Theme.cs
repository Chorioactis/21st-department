using System;
using System.Collections.Generic;

#nullable disable

namespace WebApp.Models
{
    public partial class Theme
    {
        public Theme()
        {
            ThemeCompositions = new HashSet<ThemeComposition>();
        }

        public int ThemeId { get; set; }
        public string ThemeName { get; set; }
        public string ThemeDescription { get; set; }
        public DateTime ThemeCreationDate { get; set; }
        public int ThemeCreatedBy { get; set; }
        public bool ThemeDeleted { get; set; }
        public DateTime? ThemeDeletionDate { get; set; }
        public int? ThemeDeletedBy { get; set; }

        public virtual User ThemeCreatedByNavigation { get; set; }
        public virtual User ThemeDeletedByNavigation { get; set; }
        public virtual ICollection<ThemeComposition> ThemeCompositions { get; set; }
    }
}
