using MediatR;
using Persistencia;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Dominio;

namespace Aplicación.Draws
{
    public class Winner
    {
        public class WinnerNumber : IRequest
        {
            public int number { get; set; }

        }
        public class Manejador : IRequestHandler<WinnerNumber>
        {
            private readonly LotteryContext _context;
            public Manejador(LotteryContext context)
            {
                _context = context;
            }
            public async Task<Unit> Handle(WinnerNumber request, CancellationToken cancellationToken)
            {
                var Draw = new Draw
                {
                    Winner = request.number
                };

                _context.Draw.Update(Draw);
                var data = await _context.SaveChangesAsync();
                if (data > 0)
                {
                    return Unit.Value;
                }

                throw new Exception("No es posible modificar Sorteo");
            }
        }
    }
}
