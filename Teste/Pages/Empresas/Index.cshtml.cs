using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Teste.Data;
using Teste.Model;

namespace Teste.Pages.Empresas
{
    public class IndexModel : PageModel
    {
        private readonly Teste.Data.AplicationDbContext _context;

        public IndexModel(Teste.Data.AplicationDbContext context)
        {
            _context = context;
        }

        public IList<EmpresasEntity> EmpresasEntity { get;set; } = default!;

        public async Task OnGetAsync()
        {
            EmpresasEntity = await _context.EmpresasEntity.ToListAsync();
        }
    }
}
