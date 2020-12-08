using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Dominio;
using Persistencia;
using MediatR;
using Aplicación.Draws;

namespace APILoto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DrawsController : MiControllerBase
    {
        private readonly LotteryContext _context;

        public DrawsController(LotteryContext context)
        {
            _context = context;
        }

        // GET: api/Draws
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Draw>>> GetDraws()
        {
            return await _mediator.Send(new Consulta.ListaDraws());
        }

        // GET: api/Draws/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Draw>> GetDraw(Guid id)
        {
            var draw = await _mediator.Send(new ConsultaDrawId.OneDraw { Id = id });

            if (draw == null)
            {
                return NotFound();
            }

            return draw;
        }
        //Crear usuario
        [HttpPost]
        public async Task<ActionResult<Unit>> PostDraw(New.Create data)
        {
            return await _mediator.Send(data);
        }

        [HttpPut]
        public async Task<ActionResult<Unit>> Editar(Winner.WinnerNumber data)
        {
            return await _mediator.Send(data);
        }

        /*// PUT: api/Draws/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDraw(Guid id, Draw draw)
        {
            if (id != draw.DrawId)
            {
                return BadRequest();
            }

            _context.Entry(draw).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DrawExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Draws
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Draw>> PostDraw(Draw draw)
        {
            _context.Draw.Add(draw);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDraw", new { id = draw.DrawId }, draw);
        }

        // DELETE: api/Draws/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Draw>> DeleteDraw(int id)
        {
            var draw = await _context.Draw.FindAsync(id);
            if (draw == null)
            {
                return NotFound();
            }

            _context.Draw.Remove(draw);
            await _context.SaveChangesAsync();

            return draw;
        }

        private bool DrawExists(int id)
        {
            return _context.Draw.Any(e => e.DrawId == id);
        }*/
    }
}
