using System.ComponentModel.DataAnnotations;

namespace MVCExercicio.Models
{
    public class CadMaq
    {
        [Key]
        public int idMaq { get; set; }
        public string Maquina { get; set; }
    }
}
