using ApplicationDb.Models;
using Microsoft.AspNetCore.Mvc;
using Proyects.Models;

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
    public IActionResult GetProyects()
    {
        Console.WriteLine("GET");
        var proyects = _context.Proyects.ToList();
        return Ok(proyects);
    }

    [HttpPost]
    public IActionResult AddProyect(Proyect p)
    {
        Console.WriteLine("POST");

        if (ModelState.IsValid)
        {
            _context.Proyects.Add(p);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetProyects), null);
        }

        return BadRequest(ModelState);
    }
}

