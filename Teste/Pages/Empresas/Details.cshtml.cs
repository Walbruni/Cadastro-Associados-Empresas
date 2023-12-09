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
    public class DetailsModel : PageModel
    {
        private readonly Teste.Data.AplicationDbContext _context;

        public DetailsModel(Teste.Data.AplicationDbContext context)
        {
            _context = context;
        }

        public EmpresasEntity EmpresasEntity { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var empresasentity = await _context.EmpresasEntity.FirstOrDefaultAsync(m => m.Id == id);
            if (empresasentity == null)
            {
                return NotFound();
            }
            else
            {
                EmpresasEntity = empresasentity;
            }
            return Page();
        }
    }
}
