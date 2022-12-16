using System;
using System.Collections.Generic;

#nullable disable

namespace ReseptsProject.Models
{
    public partial class Resept
    {
        public Resept()
        {
            Comments = new HashSet<Comment>();
        }

        public int ReseptId { get; set; }
        public string EatName { get; set; }
        public string Resept1 { get; set; }
        public byte? Row { get; set; }
        public int? CategoryId { get; set; }
        public DateTime? CreateDate { get; set; }
        public bool? Active { get; set; }
        public bool? Deleted { get; set; }

        public virtual Category Category { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
    }
}
