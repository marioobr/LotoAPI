using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace Dominio
{
    public class User:IdentityUser
    {
        /*public User()
        {
            Bill = new HashSet<Bill>();
        }*/
        public string FirstNames { get; set; }
        public string LastNames { get; set; }
    }
}
