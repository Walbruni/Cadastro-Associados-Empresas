using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Teste.Model;
using Teste.Servico.Interface;

namespace Teste.Pages.Associados
{
    public class DeleteModel : PageModel
    {
        private readonly IAssociadoServico _associadoServico;
        private readonly IAssociadoEmpresaServico _associadoEmpresaServico;

        public DeleteModel(IAssociadoServico associadoServico, IAssociadoEmpresaServico associadoEmpresaServico)
        {
            _associadoServico = associadoServico;
            _associadoEmpresaServico = associadoEmpresaServico;
        }

        [BindProperty]
        public AssociadosEntity AssociadosEntity { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

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

        public async Task<IActionResult> OnPostAsync(int id)
        {
            if (id != null)
            {

                await _associadoEmpresaServico.DeletarAssociadoEmpresaPorIdAssociado(id);
                await _associadoServico.DeletarAssociados(id);

                return RedirectToPage("./Index");
            }

            return NotFound();
        }
    }
}
