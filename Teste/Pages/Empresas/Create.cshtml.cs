
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Teste.Model;
using Teste.Servico.Interface;

namespace Teste.Pages.Empresas
{
    public class CreateModel : PageModel
    {
        private readonly IEmpresaServico _empresaServico;
        private readonly IAssociadoServico _associadoServico;
        private readonly IAssociadoEmpresaServico _associadoEmpresaServico;

        public CreateModel(IEmpresaServico empresaServico, IAssociadoServico associadoServico, IAssociadoEmpresaServico associadoEmpresaServico)
        {
            _empresaServico = empresaServico;
            _associadoServico = associadoServico;
            _associadoEmpresaServico = associadoEmpresaServico;
        }

        public IActionResult OnGet()
        {
            var lista = _associadoServico.GetAssociados(null, null);
            if (lista != null) {
                Associados = new SelectList(lista.AsEnumerable(), "Id", "Nome");
            }
            return Page();
        }

        [BindProperty]
        public EmpresasEntity EmpresasEntity { get; set; } = default!;

        [BindProperty]
        public List<int> SelectedAssociado { get; set; }

        public SelectList Associados { get; set; }

        [BindProperty]
        public IList<AssociadosEntity> ListaAssociado { get; set; } = default!;

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                Associados = new SelectList(_associadoServico.GetAssociados(null, null).AsEnumerable(), "Id", "Nome");
                return Page();
            }

            var Empresa = await _empresaServico.CriarEmpresas(EmpresasEntity);

            if (SelectedAssociado != null && SelectedAssociado.Any())
            {
                foreach (var id in SelectedAssociado)
                {
                    var EmpresaAssociado = new AssociadoEmpresaEntity { 
                        CdAssociado = Empresa.Id,
                        CdEmpresa = id,
                    };
                    _associadoEmpresaServico.CriarAssociadoEmpresa(EmpresaAssociado);

                }

            }

            return RedirectToPage("./Index");
        }
    }
}
