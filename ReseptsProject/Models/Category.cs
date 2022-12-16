using System;
using System.Collections.Generic;

#nullable disable

namespace ReseptsProject.Models
{
    public partial class Category
    {
        public Category()
        {
            Resepts = new HashSet<Resept>();
        }

        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public bool? Active { get; set; }
        public bool? Deleted { get; set; }

        public virtual ICollection<Resept> Resepts { get; set; }
    }
}
