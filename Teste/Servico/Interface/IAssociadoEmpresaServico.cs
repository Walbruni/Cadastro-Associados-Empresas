using Teste.Model;

namespace Teste.Servico.Interface
{
    public interface IAssociadoEmpresaServico
    {
        public AssociadoEmpresaEntity CriarAssociadoEmpresa(AssociadoEmpresaEntity associadosempresas);
        public Task DeletarAssociadoEmpresaPorIdAssociado(int id);
    }
}
