using System;
using System.Collections.Generic;
using System.Text;
using Dominio;
using Persistencia;
using MediatR;
using System.Threading.Tasks;
using System.Threading;

namespace Aplicación.BillDetails
{
    public class New
    {
        public class Create : IRequest
        {
            public double invesment { get; set; }
            public int number { get; set; }

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
                var detail = new BillDetail
                {
                    Investment = request.invesment,
                    Number = request.number
                };

                _context.BillDetail.Add(detail);
                var data = await _context.SaveChangesAsync();
                if(data > 0)
                {
                    return Unit.Value;
                }

                throw new Exception("No es posible agregar Detalle en factura");
            }
        }
    }
}
