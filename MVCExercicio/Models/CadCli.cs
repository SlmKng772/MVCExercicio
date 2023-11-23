using System.ComponentModel.DataAnnotations;

namespace MVCExercicio.Models
{
    public class CadCli
    {
        [Key]
        public int idCli {  get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
    }
}
