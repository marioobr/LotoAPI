using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using Dominio;
using System.Threading.Tasks;
using System.Threading;
using Persistencia;

namespace Aplicación.Bills
{
    public class ConsultaBillId
    {
        public class OneBill : IRequest<Bill>
        {
            public Guid Id { get; set; }
        }

        public class Manejador : IRequestHandler<OneBill, Bill>
        {
            private readonly LotteryContext _contex;
            public Manejador(LotteryContext context)
            {
                _contex = context;
            }

            public async Task<Bill> Handle(OneBill request, CancellationToken cancellationToken)
            {
                var Bill = await _contex.Bill.FindAsync(request.Id);
                return Bill;
            }
        }
    }
}
