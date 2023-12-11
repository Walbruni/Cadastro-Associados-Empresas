using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Teste.Data;
using Teste.Model;

namespace Teste.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        private AplicationDbContext _context;

        public IList<EmpresasEntity> Empresas;

        public IList<AssociadosEntity> Associados;

        public IList<AssociadoEmpresaEntity> AssociadoEmpresas;

        public IndexModel(ILogger<IndexModel> logger, AplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public void OnGet()
        {
                Empresas = _context.EmpresasEntity.ToList<EmpresasEntity>();
                Associados = _context.AssociadosEntity.ToList<AssociadosEntity>();
                AssociadoEmpresas = _context.AssociadoEmpresaEntity.ToList<AssociadoEmpresaEntity>();  

        }
    }
}
