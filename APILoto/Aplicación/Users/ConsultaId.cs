using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using Dominio;
using System.Threading.Tasks;
using System.Threading;
using Persistencia;

namespace Aplicación.Users
{
    public class ConsultaId
    {
        public class OneUser : IRequest<User>
        {
            public int Id { get; set; }
        }

        public class Manejador : IRequestHandler<OneUser, User>
        {
            private readonly LotteryContext _contex;
            public Manejador(LotteryContext context)
            {
                _contex = context;
            }
            public async Task<User> Handle(OneUser request, CancellationToken cancellationToken)
            {
                var curso = await _contex.User.FindAsync(request.Id);
                return curso;
            }
        }
    }
}
