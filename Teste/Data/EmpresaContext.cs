
using Microsoft.EntityFrameworkCore;
using Teste.Model;

namespace Data
{
    public class EmpresaContext : DbContext
    {
        public EmpresaContext(DbContextOptions<EmpresaContext> options) : base(options)
        {

        }

        public DbSet<Empresas> Empresas { get; set; }
    }
}