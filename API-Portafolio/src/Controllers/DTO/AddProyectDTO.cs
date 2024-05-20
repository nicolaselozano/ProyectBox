using Proyects.Models;

public class AddProyectRequest
{
    public Proyect Proyect { get; set; }
    public List<Guid> UserProyects { get; set; }
}