
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Teste.Model;
using Teste.Servico.Interface;

namespace Teste.Pages.Associados
{
    public class CreateModel : PageModel
    {
        private readonly IAssociadoServico _associadoServico;
        private readonly IEmpresaServico _empresaServico;
        private readonly IAssociadoEmpresaServico _associadoEmpresaServico;

        public CreateModel(IAssociadoServico associadoServico, IEmpresaServico empresaServico, IAssociadoEmpresaServico associadoEmpresaServico)
        {   
            _associadoServico = associadoServico;
            _empresaServico = empresaServico;
            _associadoEmpresaServico = associadoEmpresaServico;
        }

        public IActionResult OnGet()
        {
            var lista = _empresaServico.GetEmpresas(null, null);
            if(lista != null){
                Empresas = new SelectList(lista.AsEnumerable(), "Id", "Nome");
            }
            
            return Page();
        }

        [BindProperty]
        public AssociadosEntity AssociadosEntity { get; set; } = default!;

        [BindProperty]
        public List<int> SelectedEmpresa { get; set; }

        public SelectList Empresas { get; set; }


        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                Empresas = new SelectList(_empresaServico.GetEmpresas(null, null).AsEnumerable(), "Id", "Nome");
                return Page();
            }
            
            var Associado = await _associadoServico.CriarAssociados(AssociadosEntity);

            if (SelectedEmpresa != null && SelectedEmpresa.Any())
            {
                foreach (var id in SelectedEmpresa)
                {
                    var AssociadoEmpresa = new AssociadoEmpresaEntity {
                        CdAssociado = Associado.Id,
                        CdEmpresa = id,
                    };
                    _associadoEmpresaServico.CriarAssociadoEmpresa(AssociadoEmpresa);
                    
                }

            }

            return RedirectToPage("./Index");
        }

       
    }
}
