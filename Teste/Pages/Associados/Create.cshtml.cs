using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Teste.Data;
using Teste.Model;

namespace Teste.Pages.Associados
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
            return Page();
        }

        [BindProperty]
        public AssociadosEntity AssociadosEntity { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.AssociadosEntity.Add(AssociadosEntity);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
