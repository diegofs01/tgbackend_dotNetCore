using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TGBackend.Models
{
    [Table("aluno")]
    public class Aluno
    {
        [Key]
        public String ra { get; set; }

        public String nome { get; set; }
        public String cpf { get; set; }
        public String rg { get; set; }
        public String endereco { get; set; }
        public int numero { get; set; }
        public String complemento { get; set; }
        public String bairro { get; set; }
        public String cidade { get; set; }
        public String estado { get; set; }
        public String cep { get; set; }

        [Column("numerotelefone")]
        public String numeroTelefone { get; set; }

        [Column("numerocelular")]
        public String numeroCelular { get; set; }

        public String email { get; set; }

        [Column("idcurso")]
        public int idCurso { get; set; }

    }
}
