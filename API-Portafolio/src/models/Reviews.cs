
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Proyects.Models;
using Users.Models;

namespace Reviews.Model
{
    public class Review
    {
        [Key]
        public Guid Id { get; set; }

        public bool Like { get; set; } = false;

        [Required]
        public User User { get; set; }

        [ForeignKey("PId")]
        public Guid PId { get; set; }

        public Proyect Proyect { get; set; }
    }



}