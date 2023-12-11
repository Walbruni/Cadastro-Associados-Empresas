using Microsoft.EntityFrameworkCore;
using Teste.Data;
using Teste.Model;
using Teste.Servico.Interface;

namespace Teste.Servico
{
    public class AssociadoEmpresaServico : IAssociadoEmpresaServico
    {
        private readonly AplicationDbContext _context;

        public AssociadoEmpresaServico(AplicationDbContext context)
        {
            _context = context;
        }

        public AssociadoEmpresaEntity CriarAssociadoEmpresa(AssociadoEmpresaEntity associadosempresas)
        {
            var x = _context.AssociadoEmpresaEntity.Add(associadosempresas);
            _context.SaveChangesAsync();
            return x.Entity;
        }

        public async Task DeletarAssociadoEmpresaPorIdAssociado(int codigoAssociado)
        {
            var ListaAssociadosEmpresas = await _context.AssociadoEmpresaEntity.Where(a => a.CdAssociado == codigoAssociado).ToListAsync();
            if(ListaAssociadosEmpresas != null)
            {
                foreach(var associadoEmpresa in ListaAssociadosEmpresas)
                {
                    _context.AssociadoEmpresaEntity.Remove(associadoEmpresa);
                    await _context.SaveChangesAsync();
                }
            }
            
        }
    }
}
