using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using myBooksAppService.Models;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace myBooksAppService.Controllers
{
    [Route("api/[controller]")]
    public class LivrosController : ControllerBase
    {
        private readonly MyBooksDBContext _context;

        public LivrosController(MyBooksDBContext context)
        {
            _context = context;
        }

        // GET: api/Livros
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Livros>>> GetBooks()
        {
            return await _context.Livros.ToListAsync();
        }

        // GET api/Livros/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBookById([FromRoute] short id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            Livros livro = await _context.Livros.FindAsync(id);
            return livro == null ? NoContent() : (IActionResult)Ok(livro);
        }

        // POST api/Livros
        [HttpPost]
        public async Task<IActionResult> PostBook([FromBody]Livros livro)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            Livros livroExistente = await _context.Livros.FirstOrDefaultAsync(x => x.Title == livro.Title);

            if (livroExistente == null)
            {
                _ = _context.Livros.Add(livro);
                _ = await _context.SaveChangesAsync();
                Livros livroCriado = await _context.Livros.FirstOrDefaultAsync(x => x.Title == livro.Title);
                return CreatedAtAction("GetBookById", new { id = livroCriado.BookId }, livro);
            }

            return Ok(livroExistente);
        }


        // PUT api/Livros/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBook([FromRoute] short id, [FromBody]Livros livro)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);


            if (id != livro.BookId)
                return BadRequest();


            _context.Entry(livro).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                var _Livro = _context.Livros.FirstOrDefaultAsync(x => x.BookId == id);
                if (_Livro == null)
                    return NotFound();
                else
                    throw;
            }
            return NoContent();
        }

        // DELETE api/Livros/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] short id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            //Livros livro = await _context.Livros.FindAsync(id);
            var _Livro = await _context.Livros.FirstOrDefaultAsync(x => x.BookId == id);
            if (_Livro != null)
            {
                _ = _context.Livros.Remove(_Livro);
                _ = await _context.SaveChangesAsync();

                return Ok(_Livro);
            }
            return NotFound();
        }
    }
}
