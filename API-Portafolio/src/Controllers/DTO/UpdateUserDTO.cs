using UserProyects.Models;

public class UpdateUserDTO
{
        public string Id {get; set;}
        public string Name {get; set;}
        public string Email {get; set;}
        public List<UserProyect> UserProyects {get;set;} = new List<UserProyect>();
}