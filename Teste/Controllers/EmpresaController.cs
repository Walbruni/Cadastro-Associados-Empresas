using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Teste.Model;
using Teste.Servico;

namespace Teste.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpresaController : ControllerBase
    {

        private readonly EmpresaServico _empresaServico;

        public EmpresaController(EmpresaServico empresaServico)
        {
            _empresaServico = empresaServico;
        }

        [HttpGet("{nome}/{cnpj}")]
        public async Task<ActionResult<IEnumerable<EmpresasEntity>>> GetEmpresas(string? nome, string? cnpj)
        {
            return await _empresaServico.GetEmpresas(nome, cnpj);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EmpresasEntity>> GetEmpresas(int id)
        {
            var empresa = await _empresaServico.GetEmpresa(id);

            if (empresa == null)
            {
                return NotFound();
            }

            return Ok(empresa);
        }

        [HttpPost]
        public async Task<ActionResult<EmpresasEntity>> PostEmpresas(EmpresasEntity empresa)
        {
            return Ok(_empresaServico.PostEmpresas(empresa));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmpresas(int id, EmpresasEntity empresa)
        {

            if(empresa.Id != id)
            {
                return BadRequest();
            }
            _empresaServico.PutEmpresas(id, empresa);
            return NoContent();

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmpresas(int id)
        {
            _empresaServico.DeleteEmpresas(id);
            return NoContent();
        }


    }
}
