using System.ComponentModel.DataAnnotations;

namespace MVCExercicio.Models
{
    public class Inventario
    {
        [Key]
        public int idInv {  get; set; }
        public int idCli {  get; set; }
        public int idMaq { get; set; }
        public int Qtd { get; set; }
    }
}
