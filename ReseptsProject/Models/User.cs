using System;
using System.Collections.Generic;

#nullable disable

namespace ReseptsProject.Models
{
    public partial class User
    {
        public User()
        {
            Comments = new HashSet<Comment>();
        }

        public int UserId { get; set; }
        public string UserName { get; set; }
        public string UserSurename { get; set; }
        public string UserEmail { get; set; }
        public string UserPhone { get; set; }
        public string Userpassword { get; set; }
        public bool? Authority { get; set; }
        public bool? Active { get; set; }
        public bool? Deleted { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }
    }
}
