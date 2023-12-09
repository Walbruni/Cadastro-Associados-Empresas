using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Teste.Data;
using Teste.Model;

namespace Teste.Pages.Associados
{
    public class DeleteModel : PageModel
    {
        private readonly Teste.Data.AplicationDbContext _context;

        public DeleteModel(Teste.Data.AplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public AssociadosEntity AssociadosEntity { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var associadosentity = await _context.AssociadosEntity.FirstOrDefaultAsync(m => m.Id == id);

            if (associadosentity == null)
            {
                return NotFound();
            }
            else
            {
                AssociadosEntity = associadosentity;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var associadosentity = await _context.AssociadosEntity.FindAsync(id);
            if (associadosentity != null)
            {
                AssociadosEntity = associadosentity;
                _context.AssociadosEntity.Remove(AssociadosEntity);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
