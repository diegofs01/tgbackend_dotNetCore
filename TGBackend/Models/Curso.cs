using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TGBackend.Models
{
    [Table("curso")]
    public class Curso
    {
        [Key]
        public int id { get; set; }

        public string nome { get; set; }
    }
}
