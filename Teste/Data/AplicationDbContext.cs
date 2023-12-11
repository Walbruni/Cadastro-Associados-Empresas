using Microsoft.EntityFrameworkCore;
using Teste.Model;


namespace Teste.Data
{
    public class AplicationDbContext : DbContext
    {
        public AplicationDbContext (DbContextOptions<AplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Teste.Model.AssociadosEntity> AssociadosEntity { get; set; } = default!;
        public DbSet<Teste.Model.EmpresasEntity> EmpresasEntity { get; set; } = default!;
        public DbSet<Teste.Model.AssociadoEmpresaEntity> AssociadoEmpresaEntity { get; set; } = default!;
        
    }


}
