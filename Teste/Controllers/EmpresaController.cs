using Microsoft.AspNetCore.Mvc;
using Teste.Model;
using Teste.Servico.Interface;

namespace Teste.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpresaController : ControllerBase
    {

        private readonly IEmpresaServico _empresaServico;

        public EmpresaController(IEmpresaServico empresaServico)
        {
            _empresaServico = empresaServico;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmpresasEntity>>> GetEmpresas(string? nome, string? cnpj)
        {
            return _empresaServico.GetEmpresas(nome, cnpj);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EmpresasEntity>> GetEmpresas(int id)
        {
            var empresa = _empresaServico.BuscarEmpresa(id);

            if (empresa == null)
            {
                return NotFound();
            }

            return Ok(empresa);
        }

        [HttpPost]
        public async Task<ActionResult<EmpresasEntity>> CriarEmpresas(EmpresasEntity empresa)
        {
            return Ok(_empresaServico.CriarEmpresas(empresa));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> AlterarEmpresas(int id, EmpresasEntity empresa)
        {

            if(empresa.Id != id)
            {
                return BadRequest();
            }
            _empresaServico.AlterarEmpresas(id, empresa);
            return NoContent();

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletarEmpresas(int id)
        {
            _empresaServico.DeletarEmpresas(id);
            return NoContent();
        }


    }
}
