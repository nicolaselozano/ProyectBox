using ApplicationDb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectImages.Models;
using Proyects.Models;
using Proyects.Services;

[ApiController]
[Route("api/[controller]")]
public class ProyectController : ControllerBase
{
    private readonly IProyectService _proyectService;

    public ProyectController(IProyectService proyectService)
    {
        _proyectService = proyectService;
    }

    [HttpGet]
    public IActionResult GetProyectsC([FromQuery]int page = 1,[FromQuery] int pageSize= 10)
    {
        try
        {
            Console.WriteLine("GET");

            int skip = (page - 1) * pageSize;

            var proyects = _proyectService.GetProyects(page,pageSize);

            Console.WriteLine(proyects);
            
            
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
            var entity = _proyectService.UpdateProyect(id,UpdateP);

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
            var entity = _proyectService.DeleteProyect(id);

            return Ok(entity);
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
            var entity = _proyectService.ActiveProyect(id);

            return Ok(id);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error al activar el proyecto: {ex.Message}");
            return StatusCode(500, "Error interno del servidor");
        }
    }

    [HttpPost]
    public IActionResult AddProyect([FromBody] AddProyectRequest request)
    {
        try
        {


            var entity = _proyectService.AddProyect(request);

            return Ok(entity);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error al crear proyectos: {ex.Message}");
            return StatusCode(500, ex.Message);
        }
    }

    [HttpGet("{id}")]
    public IActionResult GetProyectById(Guid id)
    {
        try
        {
            var entity = _proyectService.GetProyect(id);
            if (entity != null)
            {
                return Ok(entity);
            }
            else
            {
                return NotFound($"No se encontró el proyecto con el id: {id}");
            }
        }
        catch (Exception)
        {
            
            throw;
        }
    }

    [HttpPost("images/{id}")]
    public IActionResult AddImage([FromRoute]Guid id, [FromBody] ImagesRequest request)
    {
        try
        {
            var entityProyect = _proyectService.AddImage(id,request);

            return Ok(entityProyect);
        }
        catch (Exception)
        {
            throw;
        }
    }
}

