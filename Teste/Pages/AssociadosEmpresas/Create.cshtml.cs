using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Teste.Data;
using Teste.Model;

namespace Teste.Pages.AssociadosEmpresas
{
    public class CreateModel : PageModel
    {
        private readonly Teste.Data.AplicationDbContext _context;

        public CreateModel(Teste.Data.AplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["CD_associado"] = new SelectList(_context.AssociadosEntity, "Id", "CPF");
        ViewData["CD_empresa"] = new SelectList(_context.EmpresasEntity, "Id", "CNPJ");
            return Page();
        }

        [BindProperty]
        public AssociadoEmpresaEntity AssociadoEmpresaEntity { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.AssociadoEmpresaEntity.Add(AssociadoEmpresaEntity);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
