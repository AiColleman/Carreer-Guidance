using System.ComponentModel.DataAnnotations;

namespace Core.Entities
{
    public class Actividad
    {
        [Key]
        public int Id { get; set; }
        public int Numero { get; set; }
        [Required]
        public string TextoActividad { get; set; }
        
        public int AreaId { get; set; }
        public Area Area { get; set; }
    }
}
