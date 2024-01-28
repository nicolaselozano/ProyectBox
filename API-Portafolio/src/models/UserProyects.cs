
using Proyects.Models;
using Users.Models;

namespace UserProyects.Models
{
    public class UserProyect
    {
        public int ProyectsId {get; set;}
        public int UserId {get; set;}
        public User User {get; set;} = null;
        public Proyect Proyects {get; set;} = null;
    }
}