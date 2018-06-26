using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TGBackend.Models
{
    [Table("ocorrencia")]
    public class Ocorrencia
    {
        [Key]
        public int numero { get; set; }

        [Column("placaveiculo")]
        public String placaVeiculo { get; set; }

        public DateTime data { get; set; }        
        public TimeSpan hora { get; set; }
        public String descricao { get; set; }

        [Column("tipoocorrencia")]
        public virtual int idTipoOcorrencia { get; set; }

        [NotMapped]
        public TipoOcorrencia tipoOcorrencia { get; set; }

        [Column("veiculocadastrado")]
        public Boolean veiculoCadastrado { get; set; }
    }
}
