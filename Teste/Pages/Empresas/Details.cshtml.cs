using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Teste.Model;
using Teste.Servico.Interface;

namespace Teste.Pages.Empresas
{
    public class DetailsModel : PageModel
    {
        private readonly IEmpresaServico _empresaServico;

        public DetailsModel(IEmpresaServico empresaServico)
        {
            _empresaServico = empresaServico;
        }

        public EmpresasEntity EmpresasEntity { get; set; } = default!;
        public async Task<IActionResult> OnGetAsync(int id)
        {
            if (id != null)
            {
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

            return NotFound();
        }
    }
}
