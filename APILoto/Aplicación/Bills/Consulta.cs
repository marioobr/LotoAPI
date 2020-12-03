using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using Dominio;
using System.Threading.Tasks;
using System.Threading;
using Persistencia;
using Microsoft.EntityFrameworkCore;

namespace Aplicación.Bills
{
    public class Consulta
    {
        public class ListaBills:IRequest<List<Bill>> { }
        public class Manejador : IRequestHandler<ListaBills, List<Bill>>
        {
            private readonly LotteryContext _context;
            public Manejador(LotteryContext context)
            {
                _context = context;
            }
            public async Task<List<Bill>> Handle(ListaBills request, CancellationToken cancellationToken)
            {
                var Bills = await _context.Bill.ToListAsync();
                return Bills;
            }
        }
    }
}
