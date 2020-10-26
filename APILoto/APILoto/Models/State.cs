using System;
using System.Collections.Generic;

namespace APILoto.Models
{
    public partial class State
    {
        public State()
        {
            User = new HashSet<User>();
        }

        public int StateId { get; set; }
        public string Description { get; set; }

        public virtual ICollection<User> User { get; set; }
    }
}
