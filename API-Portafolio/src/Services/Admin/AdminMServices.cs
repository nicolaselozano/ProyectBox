
using ApplicationDb.Models;
using Users.Models;

namespace Admin.Service
{

    public interface IAdminMService
    {
        List<User> GetAllUsers(int page, int pageSize);
        User GetUserByEmail(string email);
        User DeleteUser(Guid id);
        User ActiveUser(Guid id);
        string AsingRol(Guid id,sbyte rol);
        UserLikeDTO UserLikes(Guid userId);
        ProyectLikesDTO ProyectLikes(Guid proyectId);
        User BanUser(Guid userId);
    }

    public class AdminMService(ApplicationDbContext _context) : IAdminMService
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
        public string AsingRol(Guid id,sbyte rol)
        {
            // 1:admin | 2:user | 3:banned
            try
            {
                User user = _context.Users.First(u => !u.isDeleted && u.Id == id);

                switch(rol)
                {
                    case 1:
                    default:break;
                }
            }
            catch (System.Exception)
            {
                
                throw;
            }
        }
    }


}