using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TP.Models;

namespace TP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GastosController : ControllerBase
    {
        private readonly AppDbContext _context;
        public GastosController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Gastos>>> Get()
        {
            return await _context.Gastos.OrderByDescending(x => x.Fecha).ThenByDescending(x => x.Id).ToListAsync();
        }
        [HttpPost]
        public async Task<ActionResult<Gastos>> Post(Gastos gastos)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (gastos.Fecha > DateOnly.FromDateTime(DateTime.Today))
            {
                return BadRequest("No se permite ingresar fecha futura");
            }
            _context.Gastos.Add(gastos);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = gastos.Id }, gastos);
        }
    }
}
