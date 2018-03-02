using Microsoft.EntityFrameworkCore;
using TGBackend.Models;

namespace TGBackend.Contexts
{
    public class CursoContext : DbContext
    {
        public CursoContext(DbContextOptions<CursoContext> options) : base(options)
        {
        }

        public DbSet<Curso> curso { get; set; }
    }
}
