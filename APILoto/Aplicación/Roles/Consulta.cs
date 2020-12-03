using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using Dominio;
using System.Threading.Tasks;
using System.Threading;
using Persistencia;
using Microsoft.EntityFrameworkCore;

namespace Aplicación.Roles
{
    public class Consulta
    {
        public class ListaRoles:IRequest<List<Role>> { }
        public class Manejador : IRequestHandler<ListaRoles, List<Role>>
        {
            private readonly LotteryContext _context;
            public Manejador(LotteryContext context)
            {
                _context = context;
            }
            public async Task<List<Role>> Handle(ListaRoles request, CancellationToken cancellationToken)
            {
                var Roles = await _context.Role.ToListAsync();
                return Roles;
            }
        }
    }
}
