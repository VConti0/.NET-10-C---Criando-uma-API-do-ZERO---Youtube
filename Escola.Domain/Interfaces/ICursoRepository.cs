using Escola.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Escola.Domain.Interfaces
{
    public interface ICursoRepository
    {
        Task<Curso> GetByIdAsync(int id);
        Task<List<Curso>> GetAllAsync();
        Task <Curso> AddASync(Curso curso);
        Task<Curso> UpdateASync(Curso curso);
        Task<Curso> DeleteASync(int id);
    }
}
