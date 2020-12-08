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

            public List<BillDetail> Numbers { get; set; }

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
                Guid _BillId = Guid.NewGuid();
                var Bill = new Bill
                {
                    BillId = _BillId,
                    Date = request.Date,
                    Total = request.Total
                };

                _context.Bill.Add(Bill);

                if (request.Numbers != null)
                {
                    foreach(var dt in request.Numbers)
                    {
                        Guid idDet = Guid.NewGuid();
                        var FacturaDetalle = new BillDetail()
                        {
                            BillId = _BillId,
                            DetailId = idDet,
                            Number = dt.Number,
                            DrawId = dt.DrawId,
                            Investment = dt.Investment
                        };
                        _context.BillDetail.Add(FacturaDetalle);
                    }
                }

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
