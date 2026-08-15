using Escola.Domain.Entities;
using Escola.Domain.Interfaces;
using Escola.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Escola.Infra.Data.Repositories
{
    public class NotaRepository : INotaRepository
    {
        private readonly ApplicationDbContext _context;
        public NotaRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Nota> AddASync(Nota nota)
        {
            _context.Nota.Add(nota);
            await _context.SaveChangesAsync();
            return nota;
        }

        public async Task<Nota> DeleteASync(int id)
        {
            var nota = await _context.Nota.Where(n => n.Excluido == false && n.Id == id).FirstOrDefaultAsync();
            if (nota == null)
            {
                return null;
            }
            nota.Excluido = true;
            _context.Nota.Update(nota);
            await _context.SaveChangesAsync();
            return nota;
        }

        public async Task<List<Nota>> GetAllAsync()
        {
            return await _context.Nota.Where(n => n.Excluido == false).ToListAsync();
        }

        public async Task<Nota> GetByIdAsync(int id)
        {
            return await _context.Nota.Where(n => n.Excluido == false && n.Id == id).FirstOrDefaultAsync();
        }

        public async Task<Nota> UpdateASync(Nota nota)
        {
            _context.Nota.Update(nota);
            await _context.SaveChangesAsync();
            return nota;
        }
    }
}
