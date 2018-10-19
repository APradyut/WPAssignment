using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WPAssign.Models;

namespace WPAssign.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketsController : ControllerBase
    {
        private readonly DB _context;

        public TicketsController(DB context)
        {
            _context = context;
        }

        // GET: api/Tickets
        [HttpGet]
        public IEnumerable<Ticket> GetTickets()
        {
            return _context.Tickets;
        }

        // GET: api/Tickets/5
        [HttpGet("GetTickets/{id}")]
        public async Task<IActionResult> GetTicket([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

			var user = _context.Users.Where(a => a.Id == id).FirstOrDefault();
			var ticket = user.Tickets;

            return Ok(ticket);
        }

        //// PUT: api/Tickets/5
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutTicket([FromRoute] string id, [FromBody] Ticket ticket)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (id != ticket.Id)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(ticket).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!TicketExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        // POST: api/Tickets
        [HttpPost]
        public async Task<IActionResult> PostTicket([FromBody] TicketAddRequestModel ticket)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Tickets.Add(new Ticket()
			{
				Id = Guid.NewGuid().ToString(),
				Start = ticket.From,
				To = ticket.To,
				User = _context.Users.Where(a=>a.Id == ticket.Token).FirstOrDefault()
			});
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
            }

            return Ok(new { Message = "Ok" });
        }

        //// DELETE: api/Tickets/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteTicket([FromRoute] string id)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    var ticket = await _context.Tickets.FindAsync(id);
        //    if (ticket == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Tickets.Remove(ticket);
        //    await _context.SaveChangesAsync();

        //    return Ok(ticket);
        //}

        private bool TicketExists(string id)
        {
            return _context.Tickets.Any(e => e.Id == id);
        }
    }
}