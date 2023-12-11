using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Teste.Model;
using Teste.Servico.Interface;

namespace Teste.Pages.Empresas
{
    public class EditModel : PageModel
    {
        private readonly IEmpresaServico _empresaServico;

        public EditModel(IEmpresaServico empresaServico)
        {
            _empresaServico = empresaServico;
        }

        [BindProperty]
        public EmpresasEntity EmpresasEntity { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var empresaentity = _empresaServico.BuscarEmpresa(id);
            if (empresaentity == null)
            {
                return NotFound();
            }
            EmpresasEntity = empresaentity;
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            try
            {
                _empresaServico.AlterarEmpresas(EmpresasEntity.Id, EmpresasEntity);
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
            var empresasentity = _empresaServico.BuscarEmpresa(id);
            if (empresasentity != null)
            {
                return true;
            }
            return false;
        }
    }
}
