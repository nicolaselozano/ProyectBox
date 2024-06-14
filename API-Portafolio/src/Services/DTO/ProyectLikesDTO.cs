using System.Text.Json.Serialization;
using Proyects.Models;
using Users.Models;

public class ProyectLikesDTO
{
    [JsonPropertyName("proyect")]
    public Proyect Proyect { get; set; }
    [JsonPropertyName("users")]
    public List<User> Users{ get; set; }
}