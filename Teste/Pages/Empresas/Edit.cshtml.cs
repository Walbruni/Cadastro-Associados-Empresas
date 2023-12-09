using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Teste.Data;
using Teste.Model;

namespace Teste.Pages.Empresas
{
    public class EditModel : PageModel
    {
        private readonly Teste.Data.AplicationDbContext _context;

        public EditModel(Teste.Data.AplicationDbContext context)
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

            var empresasentity =  await _context.EmpresasEntity.FirstOrDefaultAsync(m => m.Id == id);
            if (empresasentity == null)
            {
                return NotFound();
            }
            EmpresasEntity = empresasentity;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(EmpresasEntity).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmpresasEntityExists(EmpresasEntity.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool EmpresasEntityExists(int id)
        {
            return _context.EmpresasEntity.Any(e => e.Id == id);
        }
    }
}
