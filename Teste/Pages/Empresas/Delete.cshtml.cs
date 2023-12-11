using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Teste.Model;
using Teste.Servico.Interface;

namespace Teste.Pages.Empresas
{
    public class DeleteModel : PageModel
    {
        private readonly IEmpresaServico _empresaServico;
        private readonly IAssociadoEmpresaServico _associadoEmpresaServico;

        public DeleteModel(IEmpresaServico empresaServico, IAssociadoEmpresaServico associadoEmpresaServico)
        {
            _empresaServico = empresaServico;
            _associadoEmpresaServico = associadoEmpresaServico;
        }

        [BindProperty]
        public EmpresasEntity EmpresasEntity { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var empresasentity = _empresaServico.BuscarEmpresa(id);

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

        public async Task<IActionResult> OnPostAsync(int id)
        {
            if (id != null)
            {

                await _associadoEmpresaServico.DeletarAssociadoEmpresaPorIdAssociado(id);
                await _empresaServico.DeletarEmpresas(id);

                return RedirectToPage("./Index");
            }

            return NotFound();
        }
    }
}
