
using Microsoft.EntityFrameworkCore;
using Teste.Model;

namespace Data
{
    public class AssociadoEmpresaContext : DbContext
    {
        public AssociadoEmpresaContext(DbContextOptions<AssociadoEmpresaContext> options) : base(options)
        {

        }

        public DbSet<AssociadoEmpresaEntity> AssociadoEmpresas { get; set; }
    }
}