using ApplicationDb.Models;
using Users.Models;

namespace Users.Services
{
    public interface IUserServices
    {
        User AddUser(UserDTO user);
    }

    public class UserService:IUserServices
    {
        private readonly ApplicationDbContext _context;

        public UserService(ApplicationDbContext context)
        {
            _context = context;
        }


        public User AddUser(UserDTO user)
        {

            User uExist = _context.Users.FirstOrDefault(u => u.Email == user.Email);

            if(uExist !=null)
            {
                throw new Exception("El email ya esta registrado, Registrese con otro email");
            }

            User newUser = new User
            {
                Email = user.Email,
                Name = user.Name,
                Password = user.Password,
            };

            _context.Users.Add(newUser);

            _context.SaveChanges();            

            return newUser;

        }
    }


}