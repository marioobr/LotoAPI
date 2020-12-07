using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using Dominio;
using System.Threading.Tasks;
using System.Threading;
using Persistencia;

namespace Aplicación.BillDetails
{
    public class ConsultaDetailId
    {
        public class OneDetail : IRequest<BillDetail>
        {
            public int Id { get; set; }
        }

        public class Manejador : IRequestHandler<OneDetail, BillDetail>
        {
            private readonly LotteryContext _contex;
            public Manejador(LotteryContext context)
            {
                _contex = context;
            }

            public async Task<BillDetail> Handle(OneDetail request, CancellationToken cancellationToken)
            {
                var Detail = await _contex.BillDetail.FindAsync(request.Id);
                return Detail;
            }
        }
    }
}
