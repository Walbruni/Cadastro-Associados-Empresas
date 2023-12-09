
using Microsoft.EntityFrameworkCore;
using Teste.Model;

namespace Data
{
    public class AssociadoContext : DbContext
    {
        public AssociadoContext(DbContextOptions<AssociadoContext> options) : base(options)
        {

        }

        public DbSet<AssociadosEntity> Associados { get; set; }
    }
}
