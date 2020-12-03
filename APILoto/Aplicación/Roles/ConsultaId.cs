using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using Dominio;
using System.Threading.Tasks;
using System.Threading;
using Persistencia;

namespace Aplicación.Roles
{
    public class ConsultaRoleId
    {
        public class OneRole : IRequest<Role>
        {
            public int Id { get; set; }
        }

        public class Manejador : IRequestHandler<OneRole, Role>
        {
            private readonly LotteryContext _contex;
            public Manejador(LotteryContext context)
            {
                _contex = context;
            }

            public async Task<Role> Handle(OneRole request, CancellationToken cancellationToken)
            {
                var rol = await _contex.Role.FindAsync(request.Id);
                return rol;
            }
        }
    }
}
