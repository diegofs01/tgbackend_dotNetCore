using Microsoft.EntityFrameworkCore;
using TGBackend.Models;

namespace TGBackend.Contexts
{
    public class VeiculoContext : DbContext
    {
        public VeiculoContext(DbContextOptions<VeiculoContext> options) : base(options)
        {
        }

        public DbSet<Veiculo> veiculo { get; set; }
    }
}
