using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace APILoto.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class MiControllerBase:ControllerBase
    {
        private IMediator Mediator;
        protected IMediator _mediator => Mediator ?? (Mediator = HttpContext.RequestServices.GetService<IMediator>());

    }
}
