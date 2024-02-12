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
                p.Role,

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

    [HttpDelete("{id}")]
    public IActionResult DeleteProyect(Guid id)
    {
        
        try
        {
            var entity = _context.Proyects.Find(id);
            if (entity != null)
            {
                entity.isDeleted = true;
                _context.SaveChanges();
            }
            return Ok($"{entity?.Name ?? "Proyecto"} borrado Exitosamente");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error al borrar el proyecto: {ex.Message}");
            throw;
        }
    }

    //ACTIVAR Proyecto 
    [HttpPut("active/{id}")]
    public IActionResult ActiveProyect(Guid id)
    {
        try
        {
            var entity = _context.Proyects.Find(id);
            if (entity != null)
            {
                entity.isDeleted = false;
                _context.SaveChanges();
                return Ok($"{entity.Name} activado exitosamente");
            }
            else
            {
                return NotFound($"No se encontró el proyecto con el id: {id}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error al activar el proyecto: {ex.Message}");
            return StatusCode(500, "Error interno del servidor");
        }
    }

    [HttpPost]//recibe un json que tiene los datos del proyecto y las id de los usuarios
    public IActionResult AddProyect([FromBody] Proyect pAndU)
    {
        try
        {
            if (ModelState.IsValid)
            {
                var pExist = _context.Proyects.FirstOrDefault(p => p.Name == pAndU.Name);

                if(pExist != null)
                {
                    throw new Exception("El proyecto ya existe");
                }

                var p = new Proyect
                {
                    Name = pAndU.Name,
                    Url = pAndU.Url,
                    Image = pAndU.Image,
                    Role = pAndU.Role
                };
                // Agrega el proyecto al contexto
                _context.Proyects.Add(p);

                //recorro el arreglo de usuarios
                foreach (var userId in pAndU.UserProyects)
                {
                    var user = _context.Users.Find(userId);
                
                    // Crea la relación UserProyect
                    var userProyect = new UserProyect
                    {
                        User = user,  // Asigna el usuario correcto
                        Proyects = p
                    };
                    _context.UserProyects.Add(userProyect);
                    user.UserProyects.Add(userProyect);

                }

                // Guarda los cambios en la base de datos
                _context.SaveChanges();

                return Ok($"Proyecto: {p.Name} creado exitosamente");
            }

            return BadRequest(ModelState);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error al crear proyectos: {ex.Message}");
            return StatusCode(500, ex.Message);
        }
    }

}

