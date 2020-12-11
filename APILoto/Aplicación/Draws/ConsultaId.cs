using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using Dominio;
using System.Threading.Tasks;
using System.Threading;
using Persistencia;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Aplicación.Draws
{
    public class ConsultaDrawId
    {
        public class OneDraw : IRequest<Draw>
        {
            public int Number { get; set; }
        }

        public class Manejador : IRequestHandler<OneDraw, Draw>
        {
            private readonly LotteryContext _contex;
            public Manejador(LotteryContext context)
            {
                _contex = context;
            }

            public async Task<Draw> Handle(OneDraw request, CancellationToken cancellationToken)
            {
                var Draw = await _contex.Draw.Where(c => c.Number == request.Number).SingleOrDefaultAsync();
                return Draw;
            }
        }
    }
}
