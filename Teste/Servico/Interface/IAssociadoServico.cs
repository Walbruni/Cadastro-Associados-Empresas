using Teste.Model;

namespace Teste.Servico.Interface
{
    public interface IAssociadoServico
    {
        public List<AssociadosEntity> GetAssociados(string? nome, string? cpf);

        public AssociadosEntity BuscarAssociado(int id);

        public Task<AssociadosEntity> CriarAssociados(AssociadosEntity associados);

        public Task AlterarAssociados(int id, AssociadosEntity associado);

        public Task DeletarAssociados(int id);
    }
}
