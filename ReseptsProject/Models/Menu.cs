using System;
using System.Collections.Generic;

#nullable disable

namespace ReseptsProject.Models
{
    public partial class Menu
    {
        public int MenuId { get; set; }
        public string Title { get; set; }
        public string Url { get; set; }
        public byte? Row { get; set; }
        public int? TopId { get; set; }
        public bool? Active { get; set; }
        public bool? Deleted { get; set; }
    }
}
