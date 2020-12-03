using System;
using System.Collections.Generic;
using System.Text;
using Dominio;
using Persistencia;
using MediatR;
using System.Threading.Tasks;
using System.Threading;
using FluentValidation;

namespace Aplicación.Users
{
    public class New
    {
        public class Create : IRequest
        {
            public string FirstNames { get; set; }
            public string LastNames { get; set; }
            public int Role { get; set; }
            public int State { get; set; }
            public string UserName { get; set; }
            public string Password { get; set; }

        }
        public class NuevoValidacion : AbstractValidator<Create>
        {
            public NuevoValidacion()
            {
                RuleFor(x => x.FirstNames).NotEmpty();
                RuleFor(x => x.LastNames).NotEmpty();
                RuleFor(x => x.Role).NotEmpty();
                RuleFor(x => x.Password).NotEmpty();
                RuleFor(x => x.UserName).NotEmpty();
                RuleFor(x => x.State).NotEmpty();
            }
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
                var User = new User
                {
                    FirstNames = request.FirstNames,
                    LastNames = request.LastNames,
                    RoleId = request.Role,
                    StateId = request.State,
                    UserName = request.UserName,
                    Password = request.Password
                };

                _context.User.Add(User);
                var data = await _context.SaveChangesAsync();
                if(data > 0)
                {
                    return Unit.Value;
                }

                throw new Exception("No es posible agregar Usuario");
            }
        }
    }
}
