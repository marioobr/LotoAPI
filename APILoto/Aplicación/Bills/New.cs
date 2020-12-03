using System;
using System.Collections.Generic;
using System.Text;
using Dominio;
using Persistencia;
using MediatR;
using System.Threading.Tasks;
using System.Threading;

namespace Aplicación.Bills
{
    public class New
    {
        public class Create : IRequest
        {
            public DateTime Date { get; set; }
            public float Total { get; set; }

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
                var Bill = new Bill
                {
                    Date = request.Date,
                    Total = request.Total
                };

                _context.Bill.Add(Bill);
                var data = await _context.SaveChangesAsync();
                if(data > 0)
                {
                    return Unit.Value;
                }

                throw new Exception("No es posible agregar Factura");
            }
        }
    }
}
