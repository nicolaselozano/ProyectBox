
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Proyects.Models;
using Users.Models;

namespace UserProyects.Models
{
    public class UserProyect
    {
    [Key, Column(Order = 0)]
    public Guid ProyectsId { get; set; }

    [Key, Column(Order = 1)]
    public Guid UserId { get; set; }

    [ForeignKey("UserId")]
    public User User { get; set; }

    [ForeignKey("ProyectsId")]
    public Proyect Proyects { get; set; }    
    }
}