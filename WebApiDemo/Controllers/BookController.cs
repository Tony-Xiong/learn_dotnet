using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiDemo.Domains;

namespace WebApiDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly InMemoryContext _context;
    
        public BookController(InMemoryContext context)
        {
            _context = context;
        }
    
        // GET: api/Book
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DmBook>>> GetBooks()
        {
            return await _context.Books.ToListAsync();
        }
    
        // GET: api/Book/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DmBook>> GetBook(long id)
        {
            var book = await _context.Books.FindAsync(id);
    
            if (book == null)
            {
                return NotFound();
            }
    
            return book;
        }
    
        // PUT: api/Book/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBook(long id, DmBook book)
        {
            if (id != book.Id)
            {
                return BadRequest();
            }
    
            _context.Entry(book).State = EntityState.Modified;
    
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookExists(id))
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
    
        // POST: api/Book
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DmBook>> PostBook(DmBook book)
        {
            _context.Books.Add(book);
            await _context.SaveChangesAsync();
    
            return CreatedAtAction("GetBook", new { id = book.Id }, book);
        }
    
        // DELETE: api/Book/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook(long id)
        {
            var book = await _context.Books.FindAsync(id);
            if (book == null)
            {
                return NotFound();
            }
    
            _context.Books.Remove(book);
            await _context.SaveChangesAsync();
    
            return NoContent();
        }
    
        private bool BookExists(long id)
        {
            return _context.Books.Any(e => e.Id == id);
        }
    }
}
