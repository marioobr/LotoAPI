using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using Dominio;
using System.Threading.Tasks;
using System.Threading;
using Persistencia;
using Microsoft.EntityFrameworkCore;

namespace Aplicación.Users
{
    public class Consulta
    {
        public class ListaUsers:IRequest<List<User>> { }
        public class Manejador : IRequestHandler<ListaUsers, List<User>>
        {
            private readonly LotteryContext _context;
            public Manejador(LotteryContext context)
            {
                _context = context;
            }
            public async Task<List<User>> Handle(ListaUsers request, CancellationToken cancellationToken)
            {
                var Users = await _context.User.ToListAsync();
                return Users;
            }
        }
    }
}
