using System.Text.Json.Serialization;
using Proyects.Models;
using Users.Models;

public class  UserLikeDTO
{
    [JsonPropertyName("user")]
    public User User { get; set; }
    [JsonPropertyName("proyects")]
    public List<Proyect> Proyects { get; set; }
}