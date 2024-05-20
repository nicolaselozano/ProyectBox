
using ApplicationDb.Models;
using Auth0Management;
using Microsoft.EntityFrameworkCore;
using Proyects.Models;
using Users.Models;

namespace Admin.Service
{

    public interface IAdminMService
    {
        List<User> GetAllUsers(int page, int pageSize);
        User GetUserByEmail(string email);
        User DeleteUser(Guid id);
        User ActiveUser(Guid id);
        Task<string> AsingRol(Guid id,sbyte rol);
        UserLikeDTO UserLikes(Guid userId,int page, int pageSize);
        ProyectLikesDTO ProyectLikes(Guid proyectId,int page, int pageSize);
    }

    public class AdminMService(ApplicationDbContext _context,IConfiguration configuration,RolManagment rolManagment) : IAdminMService
    {
        //no hace falta hacer el contructor a partir de c# 12
        // private readonly ApplicationDbContext _context;

        // public AdminMService(ApplicationDbContext context)
        // {
        //     _context = context;
        // }
        
        public List<User> GetAllUsers(int page,int pageSize)
        {
            try
            {
                int skip = (page - 1) * pageSize;

                List<User> users = _context.Users.Skip(skip)
                .Take(pageSize)
                .Where(u => !u.isDeleted)
                .ToList();

                return users;
            }
            catch (System.Exception)
            {
                throw;
            }
        }
        public User GetUserByEmail(string email)
        {
            try
            {
                User user = _context.Users.First(u => u.isDeleted && u.Email == email);
                return user;
            }
            catch (System.Exception)
            {
                throw;
            }
        }
        public User DeleteUser(Guid userId)
        {
            try
            {
                User user = _context.Users.First(u => u.Id == userId && u.isDeleted);

                if(user != null)
                {
                    user.isDeleted = true;
                }

                return user;
                
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        public User ActiveUser(Guid userId)
        {
            try
            {
                User user = _context.Users.First(u => u.Id == userId && !u.isDeleted);

                if(user != null)
                {
                    user.isDeleted = false;
                }

                return user;
                
            }
            catch (System.Exception)
            {
                throw new Exception("El usuario no esta registrado en la db o esta desactivado");
            }
        }
        public async Task<string> AsingRol(Guid id,sbyte rol)
        {
            // 1:admin | 2:user
            try
            {
                User user = _context.Users.First(u => !u.isDeleted && u.Id == id);
                string setRol;
                switch(rol)
                {
                    case 1: {
                        setRol = await rolManagment.SetUserRol(user.Email,[configuration.GetSection("AUTH")["AROLID"]]);
                        break;
                    };
                    case 2: {
                        setRol = await rolManagment.SetUserRol(user.Email,[configuration.GetSection("AUTH")["UROLID"]]);
                        break;
                    };
                    default:throw new Exception("EL rol nocoincide con los registrados");
                }
                return setRol;
            }
            catch (System.Exception)
            {
                
                throw;
            }
        }
        public UserLikeDTO UserLikes(Guid userId,int page, int pageSize)
        {
            try
            {
                int skip = (page - 1) * pageSize;
                var response = _context.Review.Where(r => r.User.Id == userId && !r.isDeleted)
                .Skip(skip)
                .Take(pageSize)
                .Include(r => r.Proyect)
                .Select(r => new Proyect {
                    Id = r.Proyect.Id,
                    Image = r.Proyect.Image,
                    Description = r.Proyect.Description,
                    ImagesP = r.Proyect.ImagesP,
                    isDeleted = r.Proyect.isDeleted,
                    Name = r.Proyect.Name,
                    Role = r.Proyect.Role,
                    Url = r.Proyect.Url
                })
                .ToList();

                if (response == null)
                {
                    throw new Exception("No se encontraron proyectos likeados por el Usuario");
                }

                User user = _context.Users.FirstOrDefault(u => u.Id == userId);

                if (user == null)
                {
                    throw new Exception("No se encontro al usuario");
                }

                UserLikeDTO userLike = new UserLikeDTO {
                    Proyects = response,
                    User = user
                };

                return userLike;
            }
            catch (System.Exception e)
            {
                Console.WriteLine("Obtencion de likes del usuario fallida : ",e);
                throw;
            }
        }
        public ProyectLikesDTO ProyectLikes(Guid proyectId,int page, int pageSize)
        {   
            try
            {
                int skip = (page - 1) * pageSize;
                var response = _context.Review.Where(r => r.Proyect.Id == proyectId && !r.isDeleted)
                .Skip(skip)
                .Take(pageSize)
                .Include(r => r.User)
                .Select(r => new User {
                    Id = r.User.Id,
                    Email = r.User.Email,
                    isDeleted = r.isDeleted,
                    Name = r.User.Name
                })
                .ToList();

                if(response == null)
                {
                    throw new Exception("No se encontraron reviews del proyecto");
                }

                Proyect proyect = _context.Proyects.FirstOrDefault(p => p.Id == proyectId);

                ProyectLikesDTO proyectLikes = new ProyectLikesDTO{
                    Proyect =proyect,
                    Users = response
                };

                return proyectLikes;
            }
            catch (System.Exception)
            {
                
                throw;
            }
        }

    }

}