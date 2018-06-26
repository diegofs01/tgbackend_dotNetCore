using Microsoft.EntityFrameworkCore;
using TGBackend.Models;

namespace TGBackend.Contexts
{
    public class OcorrenciaContext : DbContext
    {
        public OcorrenciaContext(DbContextOptions<OcorrenciaContext> options) : base(options)
        {
        }

        public DbSet<Ocorrencia> ocorrencia { get; set; }
        public DbSet<TipoOcorrencia> tipoOcorrencia { get; set; }
        public DbSet<Veiculo> veiculo { get; set; }
    }
}
