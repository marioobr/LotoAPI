using System;
using System.Collections.Generic;
using System.Text;
using Dominio;
using Persistencia;
using MediatR;
using System.Threading.Tasks;
using System.Threading;

namespace Aplicación.Draws
{
    public class New
    {
        public class Create : IRequest
        {
            public DateTime Date { get; set; }

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
                var Draw = new Draw
                {
                    Date = request.Date
                };

                _context.Draw.Add(Draw);
                var data = await _context.SaveChangesAsync();
                if(data > 0)
                {
                    return Unit.Value;
                }

                throw new Exception("No es posible agregar Sorteo");
            }
        }
    }
}
