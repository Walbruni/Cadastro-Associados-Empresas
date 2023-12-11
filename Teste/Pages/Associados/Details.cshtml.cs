using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Teste.Model;
using Teste.Servico.Interface;

namespace Teste.Pages.Associados
{
    public class DetailsModel : PageModel
    {
        private readonly IAssociadoServico _associadoServico;

        public DetailsModel(IAssociadoServico associadoServico)
        {
            _associadoServico = associadoServico;   
        }

        public AssociadosEntity AssociadosEntity { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int id)
        {
            if (id != null)
            {
                var associadosentity = _associadoServico.BuscarAssociado(id);
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

            return NotFound();
        }
    }
}
