using System.IdentityModel.Tokens.Jwt;
using System.Text.Json;
using ApplicationDb.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NuGet.Common;
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
    // [CheckPermissionM("admin:user")]
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
                user.Rol,
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
    

    //Register
    [HttpPost]
    [GetToken]
    [TokenValidationMiddleware]
    public IActionResult AddUser()
    {
        try
        {

            var tokenData = (TokenDTO)HttpContext.Items["tokenData"];
            var RToken = (RefreshTokenDTO)HttpContext.Items["refreshTokenData"];

            if (tokenData != null)
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                JwtSecurityToken token = tokenHandler.ReadJwtToken(tokenData.AccessToken);
                User user = _userServices.AddUser(token);
                ResponseUserDTO response = new ResponseUserDTO 
                {
                    token = tokenData.AccessToken,
                    user = user,
                    refreshToken = RToken.RefreshToken
                };              

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

    //Login
    [HttpGet("login")]
    [GetToken]
    [TokenValidationMiddleware]
    // [CheckPermissionM("user:user",15)]
    public IActionResult GetUserLogin()
    {
        try
        {
            Console.WriteLine("ENTRO AL CONTROLADOR");
            var tokenData = (TokenDTO)HttpContext.Items["tokenData"];
            var RToken = (RefreshTokenDTO)HttpContext.Items["refreshTokenData"];

            if (tokenData != null)
            {   
                var tokenHandler = new JwtSecurityTokenHandler();
                JwtSecurityToken token = tokenHandler.ReadJwtToken(tokenData.AccessToken);

                string email = token.Claims.First(c => c.Type == "custom_email_claim").Value;
            
                User userResponse = _userServices.GetUser(email);

                var authorizationHeader = HttpContext.Request.Headers["Authorization"].FirstOrDefault();
                var tokenResponse = authorizationHeader.Substring("Bearer ".Length).Trim();

                ResponseUserDTO response = new ResponseUserDTO 
                {
                    token = tokenResponse,
                    user = userResponse,
                    refreshToken= RToken.RefreshToken
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

    //ACTIVAR Usuario
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