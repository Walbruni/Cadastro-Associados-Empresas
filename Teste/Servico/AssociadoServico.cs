using Teste.Data;
using Teste.Model;
using Teste.Servico.Interface;

namespace Teste.Servico
{
    public class AssociadoServico : IAssociadoServico
    {
        private readonly AplicationDbContext _context;

        public AssociadoServico(AplicationDbContext context)
        {
            _context = context;
        }

        public List<AssociadosEntity> GetAssociados(string? nome, string? cpf)
        {

            if (nome != null && cpf != null)
            {
                return _context.AssociadosEntity.Where(x => x.Nome == nome && x.CPF == cpf).ToList();
            }
            if(nome != null)
            {
                return _context.AssociadosEntity.Where(x => x.Nome == nome).ToList();
            }
            if (cpf != null)
            {
                return _context.AssociadosEntity.Where(x => x.CPF == cpf).ToList();
            }
            return _context.AssociadosEntity.ToList();

        }

        public AssociadosEntity BuscarAssociado(int id)
        {
            return _context.AssociadosEntity.Find(id);
        }

        public async Task<AssociadosEntity> CriarAssociados(AssociadosEntity associados)
        {
            var x = await _context.AssociadosEntity.AddAsync(associados);
            await _context.SaveChangesAsync();
            return x.Entity;
        }

        public async Task AlterarAssociados(int id, AssociadosEntity associado)
        {

            var associadoRetorno = _context.AssociadosEntity.Find(id);
            if (associadoRetorno != null)
            {
                associadoRetorno.Nome = associado.Nome;
                associadoRetorno.CPF = associado.CPF;
                associadoRetorno.DataNascimento = associado.DataNascimento;
                _context.AssociadosEntity.Update(associadoRetorno);
                await _context.SaveChangesAsync();
            }

        }

        public async Task DeletarAssociados(int id)
        {
            var associado = _context.AssociadosEntity.Find(id);
            if (associado != null)
            {
                _context.AssociadosEntity.Remove(associado);
                await _context.SaveChangesAsync();
            }

        }
    }
}
