using System;
using System.ComponentModel.DataAnnotations;

namespace Core.Entities
{
    public class Respuesta
    {
        [Key]
        public int Id { get; set; }
        public Guid SesionId { get; set; }
        public int ActividadId { get; set; }
        public bool MeInteresa { get; set; }

        public Sesion Sesion { get; set; }
        public Actividad Actividad { get; set; }
    }
}
