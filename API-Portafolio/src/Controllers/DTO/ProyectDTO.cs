using ProyectImages.Models;

public class ProyectDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Url { get; set; }
    public string Image { get; set; }
    public string Role { get; set; }
    public string Description { get; set; }
    public List<Guid> UsersID { get; set; }
    public List<ProyectImage> Imgs { get; set; }
    public bool isDeleted { get; set; } = false;

}