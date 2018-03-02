using Microsoft.EntityFrameworkCore;
using TGBackend.Models;

namespace TGBackend.Contexts
{
    public class OcorrenciaContext : DbContext
    {
        public OcorrenciaContext(DbContextOptions<OcorrenciaContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Ocorrencia>().HasKey(ocorrencia => new {
                ocorrencia.placaVeiculo, ocorrencia.data, ocorrencia.hora
            });
        }

        public DbSet<Ocorrencia> ocorrencia { get; set; }
        public DbSet<TipoOcorrencia> tipoOcorrencia { get; set; }
    }
}
