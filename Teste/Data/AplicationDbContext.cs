using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
    }
}
