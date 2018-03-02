using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TGBackend.Models
{
    [Table("veiculo")]
    public class Veiculo
    {
        [Key]
        public String placa { get; set; }

        public String marca { get; set; }
        public String modelo { get; set; }

        [Column("anomodelo")]
        public int anoModelo { get; set; }

        [Column("anofabricacao")]
        public int anoFabricacao { get; set; }

        public String cor { get; set; }

        [Column("paisfabricacao")]
        public String paisFabricacao { get; set; }

        [Column("raaluno")]
        public String raAluno { get; set; }
    }
}
