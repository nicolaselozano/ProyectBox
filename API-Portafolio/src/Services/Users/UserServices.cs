using System.IdentityModel.Tokens.Jwt;
using System.Web;
using ApplicationDb.Models;
using Proyects.Models;
using UserProyects.Models;
using Users.Models;

namespace Users.Services
{
    public interface IUserServices
    {
        User AddUser(JwtSecurityToken jwt);
        User GetUser(string email);
        User DeleteUser(Guid id);
        User ActiveUser(Guid id);
        UpdateUserDTO UpdateUser(string AuthId,UpdateUserDTO user);
    }

    public class UserService(ApplicationDbContext _context,IConfiguration configuration):IUserServices
    {
        public User GetUser(string email)
        {
            try
            {  
                Console.WriteLine(email);

                User user = _context.Users.First( u => !u.isDeleted && u.Email == email);

                Console.WriteLine($" {user.Name} {user.Email}");

                return user;
            }
            catch (System.Exception)
            {
                
                throw;
            }
        }

        public User DeleteUser(Guid id)
        {
            try
            {
                User user = _context.Users.Find(id);
                if (user != null)
                {
                    user.isDeleted = true;
                    _context.SaveChanges();
                }
                return user;
            }
            catch (System.Exception)
            {
                throw;
            }
        }
        
        public User ActiveUser(Guid id)
        {
            try
            {
                User user = _context.Users.Find(id);
                if (user != null)
                {
                    user.isDeleted = false;
                    _context.SaveChanges(); 
                }
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
                var idAuth0 = jwt.Claims.FirstOrDefault(r => r.Type == "sub").Value;
                
                Console.WriteLine("Hello");

                UserDTO newUser = new UserDTO{
                    Email = email,
                    Name = name ?? email,
                    AuthId = idAuth0,
                    Rol = configuration.GetSection("AUTH")["UROL"].ToString()                     
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
        public UpdateUserDTO UpdateUser(string AuthId,UpdateUserDTO user)
        {
            try
            {
                User userExist = _context.Users.FirstOrDefault(u => u.AuthId == AuthId);
                if(userExist == null)
                {
                    throw new Exception("El usuario ingresado no existe en la base de datos");
                }

                userExist.Name = user.Name ?? userExist.Name;               

                if(user.UserProyects.Count() != 0)
                {
                    List<UserProyect> allUserProyects = _context.UserProyects.Where( up => up.UserId.ToString() == user.Id).ToList();

                    foreach (var userProyect in allUserProyects)
                    {
                        if(!user.UserProyects.Contains(userProyect))
                        {
                            _context.UserProyects.Remove(userProyect);
                            user.UserProyects.Remove(userProyect);
                        }
                    }

                    foreach (var newUP in user.UserProyects)
                    {
                        if(!allUserProyects.Contains(newUP))
                        {
                            _context.UserProyects.Add(newUP);
                            user.UserProyects.Add(newUP);
                        }
                    }
                    _context.SaveChanges();
                }

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