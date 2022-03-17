using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TareasApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TareaController : ControllerBase
    {   
        private readonly DataContext _context;

        public TareaController(DataContext context)
        {
            _context = context;
        }
            
        [HttpGet]
        public async Task<ActionResult<List<Tareas>>> GetTareas()
        {
            return Ok(await _context.Tareas.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Tareas>> GetTarea(int id)
        {
            var tarea = await _context.Tareas.FindAsync(id);
               if (tarea == null)   
                return BadRequest("Tarea not Found"); 
            return Ok(tarea);
        }

        [HttpPost]
        public async Task<ActionResult<List<Tareas>>> AddTarea(Tareas tarea)
        {
            _context.Tareas.Add(tarea);
            await _context.SaveChangesAsync();

            return Ok(await _context.Tareas.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<Tareas>>> UpdateTarea(Tareas request)
        {
            var dbTarea = await _context.Tareas.FindAsync(request.Id);
            if (dbTarea == null)
                return BadRequest("Tarea not Found");


            dbTarea.Nombre = request.Nombre;
            dbTarea.Estado = request.Estado;

            await _context.SaveChangesAsync();

            return Ok(await _context.Tareas.ToListAsync());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Tareas>> DeleteTarea(int id)
        {
            var dbTarea = await _context.Tareas.FindAsync(id);
            if (dbTarea == null)
                return BadRequest("Tarea not Found");

            _context.Tareas.Remove(dbTarea);
            await _context.SaveChangesAsync();

            return Ok(await _context.Tareas.ToListAsync());
        }
    }
}
