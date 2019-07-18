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
        public IEnumerable<Livros> GetBooks()
        {
            return _context.Livros;
        }

        //// GET: api/Todo
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<TodoItem>>> GetTodoItems()
        //{
        //    return await _context.TodoItems.ToListAsync();
        //}



        // GET api/Livros/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBookById([FromRoute] int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var _livro = await _context.Livros.FindAsync(id);

            return _livro.Equals(null) ? NotFound() : (IActionResult)Ok(_livro);

            //if (_livros.Equals(null))
            //    return NotFound();

            //return Ok(_livros);
        }

        // POST api/Livros
        [HttpPost]
        public async Task<IActionResult> PostBook([FromBody]Livros livro)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _ = _context.Livros.Add(livro);
            _ = await _context.SaveChangesAsync();
            /*Dar uma olhada nesse retorno bugado*/
            return CreatedAtAction("Get Book", new { id = livro.BookId }, livro);
        }

        // PUT api/Livros/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBook([FromRoute] int id, [FromBody]Livros livro)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!id.Equals(livro.BookId))
                return BadRequest();

            _context.Entry(livro).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LivroExist(id))
                    return NotFound();
                else
                    throw;
            }
            return NoContent();
        }

        // DELETE api/Livros/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var livro = await _context.Livros.FindAsync(id);

            if (livro.Equals(null))
                return NotFound();

            _context.Livros.Remove(livro);
            await _context.SaveChangesAsync();

            return Ok(livro);
        }

        private bool LivroExist(int id)
        {
            var _livro = _context.Livros.FindAsync(id);
            if (_livro.Equals(null))
                return false;
            return true;
        }
    }
}
