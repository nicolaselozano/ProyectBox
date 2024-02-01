using ApplicationDb.Models;
using Microsoft.AspNetCore.Mvc;
using Users.Models;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public UserController(ApplicationDbContext context)
    {
        _context=context;
    }

    [HttpGet]
    public IActionResult GetUsers(int page = 1, int pageSize = 10)
    {
        try
        {
            int skip = (page - 1) * pageSize;
            var users = _context.Users
            .Skip(skip)
            .Take(pageSize)
            .ToList();
            return Ok(users);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error al obtener usuarios: {ex.Message}");
            return StatusCode(500, "Error interno del servidor");
        }
    }

    [HttpPost]
    public IActionResult AddUser(User u)
    {
        Console.WriteLine("Post User");
        try
        {
            if(ModelState.IsValid)
            {
                _context.Users.Add(u);
                _context.SaveChanges();

                return CreatedAtAction(nameof(GetUsers),null);
            }
            else
            {
                throw new Exception("ModelState is Invalid");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error al obtener usuarios: {ex.Message}");
            return StatusCode(500, "Error interno del servidor");
        }
    }
}