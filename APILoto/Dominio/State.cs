using System;
using System.Collections.Generic;

namespace Dominio
{
    public partial class State
    {
      /*  public State()
        {
            User = new HashSet<User>();
        }*/

        public int StateId { get; set; }
        public string Description { get; set; }

        public ICollection<User> User { get; set; }
    }
}
