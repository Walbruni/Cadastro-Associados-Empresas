using Microsoft.AspNetCore.Mvc.RazorPages;
using Teste.Model;
using Teste.Servico.Interface;

namespace Teste.Pages.Associados
{
    public class IndexModel : PageModel
    {
        private readonly IAssociadoServico _associadoServico;

        public IndexModel(IAssociadoServico associadoServico)
        {
            _associadoServico = associadoServico;
        }

        public IList<AssociadosEntity> AssociadosEntity { get;set; } = default!;

        public async Task OnGetAsync()
        {
            AssociadosEntity = _associadoServico.GetAssociados(null, null);
        }
    }
}
