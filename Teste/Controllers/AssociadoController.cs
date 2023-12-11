using Microsoft.AspNetCore.Mvc;
using Teste.Model;
using Teste.Servico.Interface;

namespace Teste.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssociadoController : ControllerBase
    {
        private readonly IAssociadoServico _associadoServico;

        public AssociadoController(IAssociadoServico associadoServico)
        {
            _associadoServico = associadoServico;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AssociadosEntity>>> GetAssociados(string? nome, string? cpf)
        {
            return _associadoServico.GetAssociados(nome, cpf);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AssociadosEntity>> BuscarAssociado(int id)
        {
            var associado = _associadoServico.BuscarAssociado(id);

            if (associado == null) 
            {
                return NotFound();
            }

            return Ok(associado);
        }

        [HttpPost]
        public async Task<ActionResult<AssociadosEntity>> CriarAssociados(AssociadosEntity associado)
        {
            return Ok(_associadoServico.CriarAssociados(associado));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> AlterarAssociados(int id, AssociadosEntity associado)
        {

            if (associado.Id != id)
            {
                return BadRequest();
            }
            _associadoServico.AlterarAssociados(id, associado);
            return NoContent();

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletarAssociados(int id)
        {
            _associadoServico.DeletarAssociados(id);
            return NoContent();
        }
           
    }
}
