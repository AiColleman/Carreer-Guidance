using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Core.Entities
{
    public class Sesion
    {
        [Key]
        public Guid Id { get; set; }
        public DateTime FechaCreacion { get; set; }

        public ICollection<Respuesta> Respuestas { get; set; }
    }
}
