using ApplicationDb.Models;
using Microsoft.AspNetCore.Mvc;
using Proyects.Models;
using UserProyects.Models;

[ApiController]
[Route("api/[controller]")]
public class ProyectController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public ProyectController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult GetProyects([FromQuery]int page = 1,[FromQuery] int pageSize= 10)
    {
        try
        {
            Console.WriteLine("GET");

            int skip = (page - 1) * pageSize;

            var proyects = _context.Proyects
            .Skip(skip)
            .Take(pageSize)
            .Select(p => new
            {
                p.Id,
                p.Name,
                p.Image,
                p.Url,
                UsersID = p.UserProyects.Select(up => up.UserId).ToList()
            }
            )
            .ToList();
            
            
            return Ok(proyects);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error al obtener proyectos: {ex.Message}");
            return StatusCode(500, "Error interno del servidor");
        }
    }

    [HttpPost]
    public IActionResult AddProyect([FromBody] Proyect p, [FromQuery] Guid UserId)
    {
         Console.WriteLine($"UserId received: {UserId}");

        try
        {
            if (ModelState.IsValid)
            {
                // Agrega el proyecto al contexto
                _context.Proyects.Add(p);

                // Encuentra el usuario correspondiente en el contexto
                var user = _context.Users.Find(UserId);

                // Crea la relación UserProyect
                var userProyect = new UserProyect
                {
                    User = user,  // Asigna el usuario correcto
                    Proyects = p
                };

                // Agrega el UserProyect al contexto
                _context.UserProyects.Add(userProyect);

                // Agrega el UserProyect a la lista UserProyects del usuario
                user.UserProyects.Add(userProyect);

                // Guarda los cambios en la base de datos
                _context.SaveChanges();

                // Retorna la respuesta CreatedAtAction después de guardar los cambios
                return CreatedAtAction(nameof(GetProyects), null);
            }

            return BadRequest(ModelState);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error al crear proyectos: {ex.Message}");
            return StatusCode(500, "Error interno del servidor");
        }
    }

}

