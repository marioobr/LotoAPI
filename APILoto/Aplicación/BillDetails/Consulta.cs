using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using Dominio;
using System.Threading.Tasks;
using System.Threading;
using Persistencia;
using Microsoft.EntityFrameworkCore;

namespace Aplicación.BillDetails
{
    public class Consulta
    {
        public class ListaDetails:IRequest<List<BillDetail>> { }
        public class Manejador : IRequestHandler<ListaDetails, List<BillDetail>>
        {
            private readonly LotteryContext _context;
            public Manejador(LotteryContext context)
            {
                _context = context;
            }
            public async Task<List<BillDetail>> Handle(ListaDetails request, CancellationToken cancellationToken)
            {
                var Details = await _context.BillDetail.ToListAsync();
                return Details;
            }
        }
    }
}
