using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using myBooksAppService.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace myBooksAppService.Controllers
{
    [Route("api/[controller]")]
    public class UsuariosController : ControllerBase
    {
        private readonly MyBooksDBContext _context;

        public UsuariosController(MyBooksDBContext context)
        {
            _context = context;
        }

        // GET: api/<controller>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Usuarios>>> GetUsers()
        {
            return await _context.Usuarios.ToListAsync();
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById([FromRoute] short id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            Usuarios user = await _context.Usuarios.FindAsync(id);
            return user == null ? NoContent() : (IActionResult)Ok(user);
        }

        // POST api/<controller>
        [HttpPost]
        public async Task<IActionResult> PostUser([FromBody]Usuarios usuario)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            Usuarios userExistente = await _context.Usuarios.FirstOrDefaultAsync(x => x.Email == usuario.Email);

            if (userExistente == null)
            {
                _ = _context.Usuarios.Add(usuario);
                _ = await _context.SaveChangesAsync();

                Usuarios userCriado = await _context.Usuarios.FirstOrDefaultAsync(x => x.Email == usuario.Email);
                return CreatedAtAction("GetUserById", new { id = userCriado.UserId }, usuario);
            }

            return Ok(userExistente);
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser([FromRoute]short id, [FromBody]Usuarios usuario)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (id != usuario.UserId)
                return BadRequest();

            _context.Entry(usuario).State = EntityState.Modified;
            Usuarios userExistente = await _context.Usuarios.FirstOrDefaultAsync(x => x.Email == usuario.Email);
            if (userExistente == null)
            {
                try
                {
                    _ = await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    var _User = await _context.Usuarios.FirstOrDefaultAsync(x => x.UserId == id);
                    if (_User == null)
                        return NotFound();
                    else
                        throw;
                }
            }
            
            return BadRequest();
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] short id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            //Usuarios user = await _context.Usuarios.FindAsync(id);
            var _User = await _context.Usuarios.FirstOrDefaultAsync(x => x.UserId == id);
            if (_User != null)
            {
                _ = _context.Usuarios.Remove(_User);
                _ = _context.SaveChangesAsync();

                return Ok(_User);
            }

            return NotFound();
        }
    }
}
