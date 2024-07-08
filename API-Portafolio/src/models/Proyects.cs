using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using ProyectImages.Models;
using UserProyects.Models;

namespace Proyects.Models
{
    public class Proyect
    {
        [Key]
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Url { get; set; }
        public string? Image { get; set; }
        public string? Role { get; set; }
        public string? Description { get; set;}
        public bool isDeleted { get; set; } = false;

        [JsonIgnore]
        public List<UserProyect> UserProyects { get; set; } = new List<UserProyect>();
    
        public List<ProyectImage>? ImagesP { get; set;} = new List<ProyectImage>();
    }
}
