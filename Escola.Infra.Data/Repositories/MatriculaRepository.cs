using Escola.Domain.Entities;
using Escola.Domain.Interfaces;
using Escola.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Escola.Infra.Data.Repositories
{
    public class MatriculaRepository : IMatriculaRepository
    {
        private readonly ApplicationDbContext _context;
        public MatriculaRepository(ApplicationDbContext context)
        {
            _context = context;
        }


        public async Task<Matricula> AddASync(Matricula matricula)
        {
            _context.Matricula.Add(matricula);
            await _context.SaveChangesAsync();
            return matricula;
        }

        public async Task<Matricula> DeleteASync(int id)
        {
            var matricula = await _context.Matricula.Where(m => m.Excluido == false && m.Id == id).FirstOrDefaultAsync();
            if (matricula == null)
            {
                return null;

            }
            matricula.Excluido = true;
            _context.Matricula.Update(matricula);
            await _context.SaveChangesAsync();
            return matricula;
        }

        public async Task<List<Matricula>> GetAllAsync()
        {
            return await _context.Matricula.Where(m => m.Excluido == false).ToListAsync();
        }

        public async Task<Matricula> GetByIdAsync(int id)
        {
            return await _context.Matricula.Where(m => m.Excluido == false && m.Id == id).FirstOrDefaultAsync();
        }

        public async Task<Matricula> UpdateASync(Matricula matricula)
        {
            _context.Matricula.Update(matricula);
            await _context.SaveChangesAsync();
            return matricula;
        }
    }
}
