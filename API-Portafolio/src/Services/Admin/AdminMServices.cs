
using Users.Models;

namespace Admin.Service
{

    public interface IAdminMService
    {
        List<User> GetAllUsers(int page, int pageSize);
        User DeleteUser(Guid id);
        User ActiveUser(Guid id);
        User AsingRol(Guid id,sbyte rol);
        UserLikeDTO UserLikes(Guid userId);
        ProyectLikesDTO ProyectLikes(Guid proyectId);
        User BanUser(Guid userId);
    }

}