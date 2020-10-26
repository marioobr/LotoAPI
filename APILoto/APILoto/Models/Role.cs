using System;
using System.Collections.Generic;

namespace APILoto.Models
{
    public partial class Role
    {
        public Role()
        {
            User = new HashSet<User>();
        }

        public int RoleId { get; set; }
        public string Description { get; set; }

        public virtual ICollection<User> User { get; set; }
    }
}
