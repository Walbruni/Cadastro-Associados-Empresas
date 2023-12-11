using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Teste.Model;
using Teste.Servico.Interface;

namespace Teste.Pages.Associados
{
    public class EditModel : PageModel
    {
        private readonly IAssociadoServico _associadoServico;

        public EditModel(IAssociadoServico associadoServico)
        {
            _associadoServico = associadoServico;
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
            AssociadosEntity = associadosentity;
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
                _associadoServico.AlterarAssociados(AssociadosEntity.Id, AssociadosEntity);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AssociadosEntityExists(AssociadosEntity.Id))
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

        private bool AssociadosEntityExists(int id)
        {
            var associadosentity = _associadoServico.BuscarAssociado(id);
            if (associadosentity != null)
            {
                return true;
            }
            return false;
        }
    }
}
