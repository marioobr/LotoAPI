using System;
using System.Collections.Generic;
using System.Text;
using Dominio;
using Persistencia;
using MediatR;
using System.Threading.Tasks;
using System.Threading;

namespace Aplicación.Roles
{
    public class New
    {
        public class Create : IRequest
        {
            public string Description { get; set; }

        }
        public class Manejador : IRequestHandler<Create>
        {
            private readonly LotteryContext _context;
            public Manejador(LotteryContext context)
            {
                _context = context;
            }
            public async Task<Unit> Handle(Create request, CancellationToken cancellationToken)
            {
                var Role = new Role
                {
                    Description = request.Description
                };

                _context.Role.Add(Role);
                var data = await _context.SaveChangesAsync();
                if(data > 0)
                {
                    return Unit.Value;
                }

                throw new Exception("No es posible agregar Rol");
            }
        }
    }
}
