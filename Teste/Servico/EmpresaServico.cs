using Teste.Data;
using Teste.Model;
using Teste.Servico.Interface;

namespace Teste.Servico
{
    public class EmpresaServico : IEmpresaServico
    {

        private readonly AplicationDbContext _context;

        public EmpresaServico(AplicationDbContext context)
        {
            _context = context;
        }

        public List<EmpresasEntity> GetEmpresas(string? nome, string? cnpj)
        {

            if (nome != null && cnpj != null)
            {
                return _context.EmpresasEntity.Where(x => x.Nome == nome && x.CNPJ == cnpj).ToList();
            }
            if (nome != null)
            {
                return _context.EmpresasEntity.Where(x => x.Nome == nome).ToList();
            }
            if (cnpj != null)
            {
                return _context.EmpresasEntity.Where(x => x.CNPJ == cnpj).ToList();
            }
            return _context.EmpresasEntity.ToList();

        }

        public EmpresasEntity BuscarEmpresa(int id)
        {
            return _context.EmpresasEntity.Find(id);
        }

        public async Task<EmpresasEntity> CriarEmpresas(EmpresasEntity empresa)
        {
            var x = await _context.EmpresasEntity.AddAsync(empresa);
            await _context.SaveChangesAsync();
            return x.Entity;
        }

        public async Task AlterarEmpresas(int id, EmpresasEntity empresa)
        {

            var empresaRetorno = _context.EmpresasEntity.Find(id);
            if (empresaRetorno != null)
            {
                empresaRetorno.Nome = empresa.Nome;
                empresaRetorno.CNPJ = empresa.CNPJ;
                _context.EmpresasEntity.Update(empresaRetorno);
                await _context.SaveChangesAsync();
            }

        }

        public async Task DeletarEmpresas(int id)
        {
            var empresa = _context.EmpresasEntity.Find(id);
            if (empresa != null)
            {
                _context.EmpresasEntity.Remove(empresa);
                await _context.SaveChangesAsync();
            }
            
        }

    }
}
