using Data;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Teste.Model;

namespace Teste.Servico
{
    public class EmpresaServico
    {

        private readonly EmpresaContext _context;

        public EmpresaServico(EmpresaContext context)
        {
            _context = context;
        }

        public async Task<ActionResult<IEnumerable<EmpresasEntity>>> GetEmpresas(string? nome, string? cnpj)
        {
            return await _context.Empresas.Where(x => x.Nome == nome && x.CNPJ == cnpj).ToListAsync();
        }

        public async Task<ActionResult<EmpresasEntity>> GetEmpresa(int id)
        {
            return await _context.Empresas.FindAsync(id);
        }

        public EntityEntry<EmpresasEntity> PostEmpresas(EmpresasEntity empresa)
        {
            var x = _context.Empresas.Add(empresa);
            _context.SaveChangesAsync();
            return x;
        }

        public async void PutEmpresas(int id, EmpresasEntity empresa)
        {

            var empresaRetorno = await _context.Empresas.FindAsync(id);
            if (empresaRetorno != null)
            {
                _context.Empresas.Update(empresa);
                await _context.SaveChangesAsync();
            }
            
        }

        public async void DeleteEmpresas(int id)
        {
            var empresa = await _context.Empresas.FindAsync(id);
            if (empresa != null)
            {
                _context.Empresas.Remove(empresa);
                await _context.SaveChangesAsync();
            }
            
        }

    }
}
