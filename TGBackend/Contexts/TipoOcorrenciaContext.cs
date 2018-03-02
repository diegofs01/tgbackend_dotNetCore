using Microsoft.EntityFrameworkCore;
using TGBackend.Models;

namespace TGBackend.Contexts
{
    public class TipoOcorrenciaContext : DbContext
    {
        public TipoOcorrenciaContext(DbContextOptions<TipoOcorrenciaContext> options) : base(options)
        {
        }

        public DbSet<TipoOcorrencia> tipoOcorrencia { get; set; }
    }
}
