using System.IdentityModel.Tokens.Jwt;
using ApplicationDb.Models;
using Users.Models;

namespace Users.Services
{
    public interface IUserServices
    {
        User AddUser(JwtSecurityToken jwt);
        User GetUser(string email);
    }

    public class UserService:IUserServices
    {
        private readonly ApplicationDbContext _context;

        public UserService(ApplicationDbContext context)
        {
            _context = context;
        }

        public User GetUser(string email)
        {
            try
            {  
                Console.WriteLine(email);

                User user = _context.Users.First( u => u.Email == email);

                Console.WriteLine($" {user.Name} {user.Email}");

                return user;
            }
            catch (System.Exception)
            {
                
                throw;
            }
        }
        public User AddUser(JwtSecurityToken jwt)
        {   

            try
            {
                var email = jwt.Claims.First(claim => claim.Type == "custom_email_claim").Value;
                var name = jwt.Claims.FirstOrDefault(claim => claim.Type == "custom_name_claim")?.Value ?? email;
                
                Console.WriteLine("Hello");

                UserDTO newUser = new UserDTO{
                    Email = email,
                    Name = name ?? email
                };

                User uExist = _context.Users.FirstOrDefault(u => u.Email == newUser.Email);

                if(uExist !=null)
                {
                    throw new Exception("El email ya esta registrado, Registrese con otro email y no con :" + uExist.Email.ToString());
                }

                User user = new User
                {
                    Email = newUser.Email,
                    Name = newUser.Name
                };

                _context.Users.Add(user);

                _context.SaveChanges();            

                return user;
            }
            catch (System.Exception)
            {
                
                throw;
            }


        }
    }


}