using System;
using System.Collections.Generic;

#nullable disable

namespace ReseptsProject.Models
{
    public partial class Comment
    {
        public int CommentId { get; set; }
        public string Comment1 { get; set; }
        
        public int? ReseptId { get; set; }
        public int? UserId { get; set; }
        public DateTime? CreateDate { get; set; }
        public bool? Active { get; set; }
        public bool? Deleted { get; set; }

        public virtual Resept ReseptNavigation { get; set; }
        public virtual User User { get; set; }
    }
}
