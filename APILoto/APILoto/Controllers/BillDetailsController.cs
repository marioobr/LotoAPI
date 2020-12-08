﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Dominio;
using Persistencia;
using MediatR;
using Aplicación.BillDetails;

namespace APILoto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BillDetailsController : MiControllerBase
    {


        // GET: api/BillDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BillDetail>>> GetBillDetail()
        {
            return await _mediator.Send(new Consulta.ListaDetails());
        }

        // GET: api/BillDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BillDetail>> GetBillDetail(Guid id)
        {
            var billDetail = await _mediator.Send(new ConsultaDetailId.OneDetail { Id = id });

            if (billDetail == null)
            {
                return NotFound();
            }

            return billDetail;
        }
        //Crear Detail
        [HttpPost]
        public async Task<ActionResult<Unit>> PostDetail(New.Create data)
        {
            return await _mediator.Send(data);
        }

        // PUT: api/BillDetails/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        /*[HttpPut("{id}")]
        public async Task<IActionResult> PutBillDetail(int id, BillDetail billDetail)
        {
            if (id != billDetail.DetailId)
            {
                return BadRequest();
            }

            _context.Entry(billDetail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BillDetailExists(id))
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

        // POST: api/BillDetails
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<BillDetail>> PostBillDetail(BillDetail billDetail)
        {
            _context.BillDetail.Add(billDetail);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBillDetail", new { id = billDetail.DetailId }, billDetail);
        }

        // DELETE: api/BillDetails/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<BillDetail>> DeleteBillDetail(int id)
        {
            var billDetail = await _context.BillDetail.FindAsync(id);
            if (billDetail == null)
            {
                return NotFound();
            }

            _context.BillDetail.Remove(billDetail);
            await _context.SaveChangesAsync();

            return billDetail;
        }

        private bool BillDetailExists(int id)
        {
            return _context.BillDetail.Any(e => e.DetailId == id);
        }*/
    }
}
