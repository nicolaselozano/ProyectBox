using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Reviews.Model;
using UserProyects.Models;

namespace Users.Models
{
    public class User
    {
        [Key]
        public Guid Id {get; set;}
        public string AuthId {get; set;}
        public string Name {get; set;}
        public string Email {get; set;}
        public string Password {get; set;}
        public string Rol {get; set;}
        public bool isDeleted { get; set; } = false;
        [JsonIgnore]
        public List<UserProyect> UserProyects {get;} = new List<UserProyect>();
        [JsonIgnore]
        public ICollection<Review> Reviews { get; set; }

        public User()
        {
            Name="user";
            Email="email";
            AuthId="";
            Rol = "";
            Password="pass";
            Reviews = new List<Review>();
        }
    }
}
