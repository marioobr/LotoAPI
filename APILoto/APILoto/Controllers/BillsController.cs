using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Dominio;
using Persistencia;
using Aplicación.Bills;
using MediatR;

namespace APILoto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BillsController : MiControllerBase
    {
        private readonly LotteryContext _context;

        public BillsController(LotteryContext context)
        {
            _context = context;
        }

        // GET: api/Bills
        /*[HttpGet]
        public async Task<ActionResult<IEnumerable<Bill>>> GetBill()
        {
            return await _mediator.Send(new Consulta.ListaBills());
        }*/
        // GET: api/Albums
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Bill>>> GetBill1()
        {
            return await _context.Bill.ToListAsync();
            // return await _context.Album.Join(_context.Artista, album => album.ArtistaId, artista => artista.ArtistaId, (album, artista) => new AlbumArtista(album.Titulo, artista.Nombre)).ToListAsync();
        }

        // GET: api/Bills/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Bill>> GetBill(Guid id)
        {
            var bill = await _mediator.Send(new ConsultaBillId.OneBill{ Id = id });

            if (bill == null)
            {
                return NotFound();
            }

            return bill;
        }
        //Crear Bill
        [HttpPost]
        public async Task<ActionResult<Unit>> PostBill(New.Create data)
        {
            return await _mediator.Send(data);
        }

        // PUT: api/Bills/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        /*[HttpPut("{id}")]
        public async Task<IActionResult> PutBill(int id, Bill bill)
        {
            if (id != bill.BillId)
            {
                return BadRequest();
            }

            _context.Entry(bill).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BillExists(id))
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

        // POST: api/Bills
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Bill>> PostBill(Bill bill)
        {
            _context.Bill.Add(bill);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBill", new { id = bill.BillId }, bill);
        }

        // DELETE: api/Bills/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Bill>> DeleteBill(int id)
        {
            var bill = await _context.Bill.FindAsync(id);
            if (bill == null)
            {
                return NotFound();
            }

            _context.Bill.Remove(bill);
            await _context.SaveChangesAsync();

            return bill;
        }

        private bool BillExists(int id)
        {
            return _context.Bill.Any(e => e.BillId == id);
        }*/
    }
}
