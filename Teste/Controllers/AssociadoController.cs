using Microsoft.AspNetCore.Mvc;
using Teste.Model;
using Teste.Servico;

namespace Teste.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssociadoController : ControllerBase
    {
        private readonly AssociadoServico _associadoServico;

        public AssociadoController(AssociadoServico associadoServico)
        {
            _associadoServico = associadoServico;
        }

        [HttpGet("{nome}/{cpf}")]
        public async Task<ActionResult<IEnumerable<Associados>>> GetAssociados(string? nome, string? cpf)
        {
            return await _associadoServico.GetAssociados(nome, cpf);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Associados>> GetAssociados(int id)
        {
            var associado = await _associadoServico.GetAssociados(id);

            if (associado == null) 
            {
                return NotFound();
            }

            return Ok(associado);
        }

        [HttpPost]
        public async Task<ActionResult<Associados>> PostAssociados(Associados associado)
        {
            return Ok(_associadoServico.PostAssociados(associado));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAssociados(int id, Associados associado)
        {

            if (associado.Id != id)
            {
                return BadRequest();
            }
            _associadoServico.PutAssociados(id, associado);
            return NoContent();

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAssociados(int id)
        {
            _associadoServico.DeleteAssociados(id);
            return NoContent();
        }
           
    }
}
