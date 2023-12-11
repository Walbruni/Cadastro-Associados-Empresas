using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Teste.Data;
using Teste.Model;

namespace Teste.Pages.AssociadosEmpresas
{
    public class IndexModel : PageModel
    {
        private readonly Teste.Data.AplicationDbContext _context;

        public IndexModel(Teste.Data.AplicationDbContext context)
        {
            _context = context;
        }

        public IList<AssociadoEmpresaEntity> AssociadoEmpresaEntity { get;set; } = default!;

        public async Task OnGetAsync()
        {
            AssociadoEmpresaEntity = await _context.AssociadoEmpresaEntity
                .Include(a => a.associados)
                .Include(a => a.empresa).ToListAsync();
        }
    }
}
