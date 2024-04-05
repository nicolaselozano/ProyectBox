using System.ComponentModel.DataAnnotations;
using Reviews.Model;
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
        public bool isDeleted { get; set; } = false;
        public List<UserProyect> UserProyects {get;} = new List<UserProyect>();
        public ICollection<Review> Reviews { get; set; }

        public User()
        {
            Name="user";
            Email="email";
            Password="pass";
            Reviews = new List<Review>();
        }
    }
}
