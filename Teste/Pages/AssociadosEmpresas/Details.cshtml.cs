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
    public class DetailsModel : PageModel
    {
        private readonly Teste.Data.AplicationDbContext _context;

        public DetailsModel(Teste.Data.AplicationDbContext context)
        {
            _context = context;
        }

        public AssociadoEmpresaEntity AssociadoEmpresaEntity { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var associadoempresaentity = await _context.AssociadoEmpresaEntity.FirstOrDefaultAsync(m => m.Id == id);
            if (associadoempresaentity == null)
            {
                return NotFound();
            }
            else
            {
                AssociadoEmpresaEntity = associadoempresaentity;
            }
            return Page();
        }
    }
}
