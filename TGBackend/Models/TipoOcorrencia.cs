using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TGBackend.Models
{
    [Table("tipoocorrencia")]
    public class TipoOcorrencia
    {
        [Key]
        public int id { get; set; }

        public string nome { get; set; }
    }
}
