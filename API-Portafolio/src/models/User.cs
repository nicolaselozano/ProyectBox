using System.ComponentModel.DataAnnotations;
using UserProyects.Models;

namespace Users.Models
{
    public class User
    {
        [Key]
        public Guid Id {get; set;}
        public string Name {get; set;}
        public string Email {get; set;}
        public string Password {get; set;}
        public List<UserProyect> UserProyects {get;} = new List<UserProyect>();
    }
}
