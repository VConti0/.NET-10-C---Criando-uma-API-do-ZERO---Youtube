using Escola.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Escola.Domain.Interfaces
{
    public interface ITurmaRepository
    {
        Task<Turma> GetByIdAsync(int id);
        Task<List<Turma>> GetAllAsync();
        Task<Turma> AddASync(Turma turma);
        Task<Turma> UpdateASync(Turma turma);
        Task<Turma> DeleteASync(int id);
    }
}
