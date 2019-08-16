using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Tweeter_API.Model;

namespace Tweeter_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TweetersController : ControllerBase
    {
        private readonly TweeterContext _context;

        public TweetersController(TweeterContext context)
        {
            _context = context;
        }

        // GET: api/Tweeters
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tweeter>>> GetTweeter()
        {
            return await _context.Tweeter.ToListAsync();
        }

        // GET: api/Tweeters/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Tweeter>> GetTweeter(int id)
        {
            var tweeter = await _context.Tweeter.FindAsync(id);

            if (tweeter == null)
            {
                return NotFound();
            }

            return tweeter;
        }

        // PUT: api/Tweeters/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTweeter(int id, Tweeter tweeter)
        {
            if (id != tweeter.Postid)
            {
                return BadRequest();
            }

            _context.Entry(tweeter).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TweeterExists(id))
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

        // POST: api/Tweeters
        [HttpPost]
        public async Task<ActionResult<Tweeter>> PostTweeter(Tweeter tweeter)
        {
            _context.Tweeter.Add(tweeter);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTweeter", new { id = tweeter.Postid }, tweeter);
        }

        // DELETE: api/Tweeters/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Tweeter>> DeleteTweeter(int id)
        {
            var tweeter = await _context.Tweeter.FindAsync(id);
            if (tweeter == null)
            {
                return NotFound();
            }

            _context.Tweeter.Remove(tweeter);
            await _context.SaveChangesAsync();

            return tweeter;
        }

        private bool TweeterExists(int id)
        {
            return _context.Tweeter.Any(e => e.Postid == id);
        }
    }
}
