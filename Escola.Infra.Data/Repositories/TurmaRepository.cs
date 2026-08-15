using Escola.Domain.Entities;
using Escola.Domain.Interfaces;
using Escola.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Text;

namespace Escola.Infra.Data.Repositories
{
    public class TurmaRepository : ITurmaRepository
    {
        private readonly ApplicationDbContext _context;
        public TurmaRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Turma> AddASync(Turma turma)
        {
            _context.Turma.Add(turma);
            await _context.SaveChangesAsync();
            return turma;
        }

        public async Task<Turma> DeleteASync(int id)
        {
            var turma = await _context.Turma.Where(t => t.Excluido == false && t.Id == id).FirstOrDefaultAsync();
            if (turma == null)
            {
                return turma;
            }
            turma.Excluido = true;
            _context.Turma.Update(turma);
            await _context.SaveChangesAsync();
            return turma;
        }

        public async Task<List<Turma>> GetAllAsync()
        {
            return await _context.Turma.Where(t => t.Excluido == false).ToListAsync();
        }

        public async Task<Turma> GetByIdAsync(int id)
        {
            return await _context.Turma.Where(t => t.Excluido == false && t.Id == id).FirstOrDefaultAsync();
        }

        public async Task<Turma> UpdateASync(Turma turma)
        {
            _context.Turma.Update(turma);
            await _context.SaveChangesAsync();
            return turma;
        }
    }
}
