using ApplicationDb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

    //Put Proyect
    [HttpPut("{id}")]
    public IActionResult UpdateProyect(Guid id, [FromBody] Proyect UpdateP)
    {
        try
        {
            Console.WriteLine("hola");
            var entity = _context.Proyects.Find(id);
            if (entity == null)
            {
                return NotFound($"No se encontró el proyecto con ID {id}");
            }

            entity.Name = UpdateP.Name ?? entity.Name;
            entity.Image = UpdateP.Image ?? entity.Image;
            entity.Url = UpdateP.Url ?? entity.Url;
            entity.Role = UpdateP.Role ?? entity.Role;

            _context.SaveChanges();

            return Ok($"Proyecto con ID {id} actualizado exitosamente");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error al borrar el proyecto: {ex.Message}");
            throw;
        }
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteProyect(Guid id)
    {
        
        try
        {
            var entity = _context.Proyects.Find(id);
        
            if (entity == null)
            {
                return NotFound($"No se encontró el proyecto con ID {id}");
            }

            entity.isDeleted = true;
            _context.SaveChanges();
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

    public class AddProyectRequest
    {
        public Proyect Proyect { get; set; }
        public List<Guid> UserProyects { get; set; }
    }

    [HttpPost]
    public IActionResult AddProyect([FromBody] AddProyectRequest request)
    {
        try
        {
            if (ModelState.IsValid)
            {
                var pExist = _context.Proyects.FirstOrDefault(p => p.Name == request.Proyect.Name);

                if (pExist != null)
                {
                    throw new Exception("El proyecto ya existe");
                }

                var p = new Proyect
                {
                    Name = request.Proyect.Name,
                    Url = request.Proyect.Url,
                    Image = request.Proyect.Image,
                    Role = request.Proyect.Role
                };

                // Agrega el proyecto al contexto
                _context.Proyects.Add(p);

                // Recorro el arreglo de usuarios
                foreach (var userId in request.UserProyects)
                {
                    var user = _context.Users.FirstOrDefault(u => u.Id == userId);

                    if (user == null)
                    {
                        throw new Exception($"El usuario con ID {userId} no existe");
                    }

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

