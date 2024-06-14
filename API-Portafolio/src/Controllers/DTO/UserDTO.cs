using UserProyects.Models;

public class UserDTO
{
        public Guid Id {get; set;}
        public string Name {get; set;}
        public string Email {get; set;}
        public string AuthId {get; set;}
        public string Rol {get; set;}
        public string Password {get; set;}
        public List<UserProyect> UserProyects {get;} = new List<UserProyect>();
}