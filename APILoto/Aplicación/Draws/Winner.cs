using MediatR;
using Persistencia;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Dominio;
using Aplicacion.ManejadorError;
using System.Net;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Aplicación.Draws
{
    public class Winner
    {
        public class WinnerNumber : IRequest
        {
            public int number { get; set; }
            public int winner { get; set; }

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
                var draw = await _context.Draw.Where(x => x.Number == request.number).SingleOrDefaultAsync();

                if (draw == null)
                {
                    throw new Exception("El sorteo no existe");
                    //throw new ManejadorExcepcion(HttpStatusCode.NotFound, new { draw = "No se encontró el sorteo" });
                }
                
                draw.Winner = request.winner;

                var resultado = await _context.SaveChangesAsync();
                if (resultado > 0)
                {
                    return Unit.Value;
                }

                throw new Exception("No se actualizó el sorteo");
            }
        }
    }
}
