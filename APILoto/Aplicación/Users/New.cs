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
            public string UserName { get; set; }
            public string Password { get; set; }
            public string Email { get; set; }

        }
        public class NewValidacion : AbstractValidator<Create>
        {
            public NewValidacion()
            {
                RuleFor(x => x.FirstNames).NotEmpty();
                RuleFor(x => x.LastNames).NotEmpty();
                RuleFor(x => x.Password).NotEmpty();
                RuleFor(x => x.UserName).NotEmpty();
                RuleFor(x => x.Email).NotEmpty();
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
                    UserName = request.UserName,
                    PasswordHash = request.Password,
                    Email = request.Email
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
