using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using Dominio;
using System.Threading.Tasks;
using System.Threading;
using Persistencia;

namespace Aplicación.States
{
    public class ConsultaStateId
    {
        public class OneState : IRequest<State>
        {
            public int Id { get; set; }
        }

        public class Manejador : IRequestHandler<OneState, State>
        {
            private readonly LotteryContext _contex;
            public Manejador(LotteryContext context)
            {
                _contex = context;
            }

            public async Task<State> Handle(OneState request, CancellationToken cancellationToken)
            {
                var State = await _contex.State.FindAsync(request.Id);
                return State;
            }
        }
    }
}
