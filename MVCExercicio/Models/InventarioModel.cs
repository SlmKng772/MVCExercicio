using System.ComponentModel.DataAnnotations;

namespace MVCExercicio.Models
{
    public class InventarioModel : CadCli
    {
        [Key]
        public int idInv { get; set; }
        public int idCli { get; set; }
        public int idMaq { get; set; }
        public int Qtd { get; set; }
        public List<CadCli> ClientesList { get; set; }
        public List<CadMaq> MaqList { get; set; }
    }
}
