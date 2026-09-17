using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Core.Entities
{
    public class Area
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Nombre { get; set; }

        public ICollection<Actividad> Actividades { get; set; }
    }
}
