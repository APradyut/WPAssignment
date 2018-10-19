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
    public partial class UsersController : ControllerBase
    {
        private readonly DB _context;

        public UsersController(DB context)
        {
            _context = context;
        }

		// GET: api/Users
		[HttpGet]
		public IEnumerable<User> GetUsers()
		{
			return _context.Users;
		}
		//GET: api/Users/5
        [HttpPost("Login")]
		public IActionResult LoginUser([FromBody]LoginRequestModel Data)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = _context.Users.Where(a=>a.Username == Data.Username && a.Password == Data.Password).FirstOrDefault();

            if (user == null)
            {
                return BadRequest(new { Message = "Username or Password dosenot match" });
            }

            return Ok(new { Token = user.Id});
        }

        //// PUT: api/Users/5
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutUser([FromRoute] long id, [FromBody] User user)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (id != user.Id)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(user).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!UserExists(id))
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

        // POST: api/Users
        [HttpPost("Register")]
        public IActionResult PostUser([FromBody] RegisterRequestModel user)
		{
			try
			{

				if (!ModelState.IsValid)
				{
					return BadRequest(ModelState);
				}

				_context.Users.Add(new WPAssign.Models.User()
				{
					EmailId = user.EmailId,
					Name = user.Name,
					Id = Guid.NewGuid().ToString(),
					Password = user.Password,
					PhoneNumber = user.PhoneNumber,
					Username = user.Username,
					Tickets = new List<Ticket>()
				});
				_context.SaveChanges();
				return Ok(new { Message = "Ok" });

			}
			catch (Exception)
			{

				throw;
			}

        }

        //// DELETE: api/Users/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteUser([FromRoute] long id)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    var user = await _context.Users.FindAsync(id);
        //    if (user == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Users.Remove(user);
        //    await _context.SaveChangesAsync();

        //    return Ok(user);
        //}

        private bool UserExists(string id)
        {
            return _context.Users.Any(e => e.Id == id);
        }
    }
}