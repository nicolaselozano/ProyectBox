using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Proyects.Models;

namespace ProyectImages.Models
{
    public class ProyectImage
    {
        [Key]
        public Guid Id { get; set; }

        public Proyect Proyect { get; set; } 

        [Required]
        public string Url { get; set; }
    }
}