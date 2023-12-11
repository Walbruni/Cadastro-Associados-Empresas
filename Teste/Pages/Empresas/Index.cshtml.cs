
using Microsoft.AspNetCore.Mvc.RazorPages;
using Teste.Model;
using Teste.Servico.Interface;

namespace Teste.Pages.Empresas
{
    public class IndexModel : PageModel
    {
        private readonly IEmpresaServico _empresaServico;

        public IndexModel(IEmpresaServico empresaServico)
        {
            _empresaServico = empresaServico;
        }

        public IList<EmpresasEntity> EmpresasEntity { get; set; } = default!;

        public async Task OnGetAsync()
        {
            EmpresasEntity = _empresaServico.GetEmpresas(null, null);
        }
    }
}
