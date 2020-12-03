using System;
using System.Collections.Generic;

namespace Dominio
{
    public partial class User
    {
        /*public User()
        {
            Bill = new HashSet<Bill>();
        }*/

        public int UserId { get; set; }
        public string FirstNames { get; set; }
        public string LastNames { get; set; }
        public int RoleId { get; set; }
        public int StateId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

        public virtual Role Role { get; set; }
        public virtual State State { get; set; }
    }
}
