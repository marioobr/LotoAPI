using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using Dominio;
using System.Threading.Tasks;
using System.Threading;
using Persistencia;
using Microsoft.EntityFrameworkCore;

namespace Aplicación.States
{
    public class ConsultaStates
    {
        public class ListaStates:IRequest<List<State>> { }
        public class Manejador : IRequestHandler<ListaStates, List<State>>
        {
            private readonly LotteryContext _context;
            public Manejador(LotteryContext context)
            {
                _context = context;
            }
            public async Task<List<State>> Handle(ListaStates request, CancellationToken cancellationToken)
            {
                var States = await _context.State.ToListAsync();
                return States;
            }
        }
    }
}
