using Microsoft.EntityFrameworkCore;
using TGBackend.Models;

namespace TGBackend.Contexts
{
    public class AlunoContext : DbContext
    {
        public AlunoContext(DbContextOptions<AlunoContext> options) : base(options)
        {
        }

        public DbSet<Aluno> aluno { get; set; }
    }
}
