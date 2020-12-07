using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Dominio;
using System.Linq;

namespace Persistencia
{
    public class DataPrueba
    {
        public static async Task InsertData(LotteryContext context, UserManager<User> usuarioManager)
        {
            if (!usuarioManager.Users.Any())
            {
                var usuario = new User()
                {
                    FirstNames = "Mario Alberto",
                    LastNames = "Obregón López",
                    UserName = "marioobr",
                    Email = "obrlop@gmail.com"
                };
                await usuarioManager.CreateAsync(usuario, "Cl@ro2020");
            }
        }
    }
}
