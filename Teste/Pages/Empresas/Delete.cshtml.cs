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
    public class DeleteModel : PageModel
    {
        private readonly Teste.Data.AplicationDbContext _context;

        public DeleteModel(Teste.Data.AplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var empresasentity = await _context.EmpresasEntity.FindAsync(id);
            if (empresasentity != null)
            {
                EmpresasEntity = empresasentity;
                _context.EmpresasEntity.Remove(EmpresasEntity);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
