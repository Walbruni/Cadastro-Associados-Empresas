
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Teste.Model;

namespace Teste.Pages.Empresas
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
        public EmpresasEntity EmpresasEntity { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.EmpresasEntity.Add(EmpresasEntity);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
