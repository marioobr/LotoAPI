using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using Dominio;
using System.Threading.Tasks;
using System.Threading;
using Persistencia;
using Microsoft.EntityFrameworkCore;

namespace Aplicación.Draws
{
    public class Consulta
    {
        public class ListaDraws:IRequest<List<Draw>> { }
        public class Manejador : IRequestHandler<ListaDraws, List<Draw>>
        {
            private readonly LotteryContext _context;
            public Manejador(LotteryContext context)
            {
                _context = context;
            }
            public async Task<List<Draw>> Handle(ListaDraws request, CancellationToken cancellationToken)
            {
                var Draws = await _context.Draw.ToListAsync();
                return Draws;
            }
        }
    }
}
