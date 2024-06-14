using System.Text.Json.Serialization;
using Proyects.Models;
using Users.Models;

public class  UserLikeProductsDTO
{
    public string UserId { get; set; }
    [JsonPropertyName("proyects")]
    public List<Proyect> Proyects { get; set; }
}