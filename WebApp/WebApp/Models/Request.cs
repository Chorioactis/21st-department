using System;
using System.Collections.Generic;

#nullable disable

namespace WebApp.Models
{
    public partial class Request
    {
        public Request()
        {
            RequestCompositions = new HashSet<RequestComposition>();
        }

        public int RequestId { get; set; }
        public string RequestName { get; set; }
        public string RequestDescription { get; set; }
        public DateTime RequestCreationDate { get; set; }
        public int? RequestCreatedBy { get; set; }

        public virtual User RequestCreatedByNavigation { get; set; }
        public virtual ICollection<RequestComposition> RequestCompositions { get; set; }
    }
}
