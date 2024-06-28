using System.IdentityModel.Tokens.Jwt;
using System.Text.Json;
using System.Web;
using ApplicationDb.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
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
    // [CheckPermissionM("admin:user",5)]
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
                user.AuthId,
                
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

    [HttpPut]
    [TokenValidationMiddleware]
    [CheckPermissionM("user:user",3)]
    public IActionResult PutUser([FromBody] UpdateUserDTO newUser)
    {
        try
        {Console.WriteLine($"inicio {newUser.Email}");
            var tokenData = (TokenDTO)HttpContext.Items["tokenData"];
            var tokenHandler = new JwtSecurityTokenHandler();
            JwtSecurityToken jwt = tokenHandler.ReadJwtToken(tokenData.AccessToken);
            
            var idAuth0 = jwt.Claims.FirstOrDefault(r => r.Type == "sub").Value.Replace("|","%7C");

            UpdateUserDTO user = _userServices.UpdateUser(idAuth0,newUser);

            return Ok(user);
        }
        catch (System.Exception)
        {
            
            throw;
        }
    }

    //Login
    [HttpGet("login")]
    [GetToken]
    [TokenValidationMiddleware]
    [CheckPermissionM("user:user",15)]
    public IActionResult GetUserLogin()
    {
        try
        {
            var tokenData = (TokenDTO)HttpContext.Items["tokenData"];
            var RToken = (RefreshTokenDTO)HttpContext.Items["refreshTokenData"];

            if (tokenData != null)
            {   
                var tokenHandler = new JwtSecurityTokenHandler();
                JwtSecurityToken token = tokenHandler.ReadJwtToken(tokenData.AccessToken);
                Console.WriteLine("emaillllllsssssssssssssssss", tokenData.AccessToken);
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