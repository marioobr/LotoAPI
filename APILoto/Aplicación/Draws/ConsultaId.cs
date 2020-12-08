using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using Dominio;
using System.Threading.Tasks;
using System.Threading;
using Persistencia;

namespace Aplicación.Draws
{
    public class ConsultaDrawId
    {
        public class OneDraw : IRequest<Draw>
        {
            public Guid Id { get; set; }
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
                var Draw = await _contex.Draw.FindAsync(request.Id);
                return Draw;
            }
        }
    }
}
