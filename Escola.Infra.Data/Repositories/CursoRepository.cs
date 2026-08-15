using Escola.Domain.Entities;
using Escola.Domain.Interfaces;
using Escola.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Escola.Infra.Data.Repositories
{
    public class CursoRepository : ICursoRepository
    {
        private readonly ApplicationDbContext _context;
        public CursoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Curso> AddASync(Curso curso)
        {
            _context.Curso.Add(curso);
            await _context.SaveChangesAsync();
            return curso;
        }

        public async Task<Curso> DeleteASync(int id)
        {
            var curso = await _context.Curso.Where(x => x.Excluido == false && x.Id == id).FirstOrDefaultAsync();

            if (curso == null) 
            {
                return null;
            }
            curso.Excluido = true;
            _context.Curso.Update(curso);
            await _context.SaveChangesAsync();
            return curso;
        }

        public async Task<List<Curso>> GetAllAsync()
        {
            return await _context.Curso.Where(x => x.Excluido == false).ToListAsync();
        }

        public async Task<Curso> GetByIdAsync(int id)
        {
            return await _context.Curso.Where(x => x.Excluido == false && x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<Curso> UpdateASync(Curso curso)
        {
            _context.Curso.Update(curso);
            await _context.SaveChangesAsync();
            return curso;
        }
    }
}
