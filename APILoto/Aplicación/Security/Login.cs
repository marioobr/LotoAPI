using Dominio;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Aplicación.Security
{
    public class Login
    {
        public class New : IRequest<UsuarioData>
        {
            public string Email { get; set; }
            public string Password { get; set; }

        }
        public class NewValidation : AbstractValidator<New>
        {
            public NewValidation()
            {
                RuleFor(x => x.Email).NotEmpty();
                RuleFor(x => x.Password).NotEmpty();
            }
        }
        public class Manejador : IRequestHandler<New, UsuarioData>
        {
            private readonly UserManager<User> _userManager;
            private readonly SignInManager<User> _sigInManager;
            
            public Manejador(UserManager<User> userManager, SignInManager<User> signInManager)
            {
                _userManager = userManager;
                _sigInManager = signInManager;
            }

            public async Task<UsuarioData> Handle(New request, CancellationToken cancellationToken)
            {
                var user = await _userManager.FindByEmailAsync(request.Email);
                if(user == null)
                {
                    throw new Exception("Usuario no encontrado");
                }

                var result = await _sigInManager.CheckPasswordSignInAsync(user, request.Password,false);
                if (result.Succeeded)
                {
                    return new UsuarioData { 
                        FirstNames = user.FirstNames,
                        LastNames = user.LastNames,
                        Token = "Marito López",
                        UserName = user.UserName,
                        Email = user.Email
                    };
                }
                throw new Exception(HttpStatusCode.Unauthorized.ToString());
            }
        }
    }
}
