using System;
using System.Collections.Generic;

#nullable disable

namespace ReseptsProject.Models
{
    public partial class Page
    {
        public int PageId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public bool? Active { get; set; }
        public bool? Deleted { get; set; }
    }
}
