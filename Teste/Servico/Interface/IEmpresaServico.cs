using Teste.Model;

namespace Teste.Servico.Interface
{
    public interface IEmpresaServico
    {
        public List<EmpresasEntity> GetEmpresas(string? nome, string? cnpj);

        public EmpresasEntity BuscarEmpresa(int id);

        public Task<EmpresasEntity> CriarEmpresas(EmpresasEntity empresas);

        public Task AlterarEmpresas(int id, EmpresasEntity empresas);

        public Task DeletarEmpresas(int id);
    }
}