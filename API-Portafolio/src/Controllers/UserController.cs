using System.IdentityModel.Tokens.Jwt;
using System.Text.Json;
using ApplicationDb.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Users.Models;
using Users.Services;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly IUserServices _userServices;
    private readonly ApplicationDbContext _context;

    public UserController(ApplicationDbContext context,IUserServices userServices)
    {   
        _userServices=userServices;
        _context=context;
    }

    [HttpGet]
    [CheckPermissionM("admin:user")]
    public IActionResult GetUsers(int page = 1, int pageSize = 10)
    {
        try
        {
            int skip = (page - 1) * pageSize;
            var users = _context.Users
            .Skip(skip)
            .Take(pageSize)
            .Select(user => new
            {
                user.Id,
                user.Name,
                user.Email,
                user.Password,
                user.isDeleted,
                
                ProductID = user.UserProyects.Select(up => up.ProyectsId).ToList()
            }
            )
            .ToList();
            return Ok(users);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error al obtener usuarios: {ex.Message}");
            return StatusCode(500, "Error interno del servidor");
        }
    }
    

    //login
    [HttpPost]
    [GetToken]
    [CheckPermissionM("user:user")]
    [TokenValidationMiddleware]
    public IActionResult AddUser()
    {
        try
        {
            Console.WriteLine("Hola");
            var tokenData = (JwtSecurityToken)HttpContext.Items["tokendata"];

            if (tokenData != null)
            {

                var response = _userServices.AddUser(tokenData);

                return Ok(response);
            }
            else
            {
                throw new Exception("Authorization header missing or invalid");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error al obtener usuarios: {ex.Message}");
            return StatusCode(500, ex.Message);
        }
    }

    [HttpGet("login")]
    [GetToken]
    [TokenValidationMiddleware]
    public IActionResult GetUserLogin()
    {
        try
        {
            var tokenData = (JwtSecurityToken)HttpContext.Items["tokendata"];
            Console.WriteLine("HOLAAAAAAAAAAAAAA");
            if (tokenData != null)
            {   
                string email = tokenData.Claims.First(c => c.Type == "custom_email_claim").Value;
            
                User userResponse = _userServices.GetUser(email);

                var authorizationHeader = HttpContext.Request.Headers["Authorization"].FirstOrDefault();
                var tokenResponse = authorizationHeader.Substring("Bearer ".Length).Trim();

                ResponseUserDTO response = new ResponseUserDTO 
                {
                    token = tokenResponse,
                    user = userResponse
                };              

                return Ok(response);
            }
            else
            {
                throw new Exception("Authorization header missing or invalid");
            }

        }
        catch (System.Exception)
        {
            
            throw;
        }
    }

    [HttpDelete("{id}")]
    [CheckPermissionM("admin:user")]
    public IActionResult DeleteUser(Guid id)
    {
        
        try
        {
            var entity = _userServices.DeleteUser(id);

            return Ok($"{entity?.Name ?? "Usuario"} borrado Exitosamente");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error al borrar el usuario: {ex.Message}");
            throw;
        }
    }

    //ACTIVAR Proyecto 
    [HttpPatch("active/{id}")]
    [CheckPermissionM("admin:user")]
    public IActionResult ActiveUser(Guid id)
    {
        try
        {
            User entity = _userServices.ActiveUser(id);

            return Ok($"{entity.Name} activado exitosamente");

        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error al activar el usuario: {ex.Message}");
            return StatusCode(500, "Error interno del servidor");
        }
    }
}