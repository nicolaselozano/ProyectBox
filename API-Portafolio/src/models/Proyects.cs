using System.ComponentModel.DataAnnotations;
using UserProyects.Models;

namespace Proyects.Models
{
    public class Proyect
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public string Image { get; set; }
        public string Role { get; set; }
        public List<UserProyect> UserProyects { get; private set; } = new List<UserProyect>();
    }
}
