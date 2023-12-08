using Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Teste.Model;

namespace Teste.Servico
{
    public class AssociadoServico
    {
        private readonly AssociadoContext _context;

        public AssociadoServico(AssociadoContext context)
        {
            _context = context;
        }

        public async Task<ActionResult<IEnumerable<Associados>>> GetAssociados(string? nome, string? cpf)
        {
            return await _context.Associados.Where(x => x.Nome == nome && x.CPF == cpf).ToListAsync();
        }

        public async Task<ActionResult<Associados>> GetAssociados(int id)
        {
            return await _context.Associados.FindAsync(id);
        }

        public EntityEntry<Associados> PostAssociados(Associados associados)
        {
            var x = _context.Associados.Add(associados);
            _context.SaveChangesAsync();
            return x;
        }

        public async void PutAssociados(int id, Associados associado)
        {

            var associadoRetorno = await _context.Associados.FindAsync(id);
            if (associadoRetorno != null)
            {
                _context.Associados.Update(associado);
                await _context.SaveChangesAsync();
            }

        }

        public async void DeleteAssociados(int id)
        {
            var associado = await _context.Associados.FindAsync(id);
            if (associado != null)
            {
                _context.Associados.Remove(associado);
                await _context.SaveChangesAsync();
            }

        }
    }
}
