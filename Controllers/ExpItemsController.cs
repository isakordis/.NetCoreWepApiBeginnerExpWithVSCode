using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Example.Models;

namespace Example.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExpItemsController : ControllerBase
    {
        private readonly ExpItemContext _context;

        public ExpItemsController(ExpItemContext context)
        {
            _context = context;
        }

        // GET: api/ExpItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ExpItem>>> GetExpItems()
        {
            return await _context.ExpItems.ToListAsync();
        }

        // GET: api/ExpItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ExpItem>> GetExpItem(long id)
        {
            var expItem = await _context.ExpItems.FindAsync(id);

            if (expItem == null)
            {
                return NotFound();
            }

            return expItem;
        }

        // PUT: api/ExpItems/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutExpItem(long id, ExpItem expItem)
        {
            if (id != expItem.Id)
            {
                return BadRequest();
            }

            _context.Entry(expItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ExpItemExists(id))
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

        // POST: api/ExpItems
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<ExpItem>> PostExpItem(ExpItem expItem)
        {
            _context.ExpItems.Add(expItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetExpItem", new { id = expItem.Id }, expItem);
        }

        // DELETE: api/ExpItems/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ExpItem>> DeleteExpItem(long id)
        {
            var expItem = await _context.ExpItems.FindAsync(id);
            if (expItem == null)
            {
                return NotFound();
            }

            _context.ExpItems.Remove(expItem);
            await _context.SaveChangesAsync();

            return expItem;
        }

        private bool ExpItemExists(long id)
        {
            return _context.ExpItems.Any(e => e.Id == id);
        }
    }
}
