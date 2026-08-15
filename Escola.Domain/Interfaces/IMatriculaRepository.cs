using Escola.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Escola.Domain.Interfaces
{
    public interface IMatriculaRepository
    {
        Task<Matricula> GetByIdAsync(int id);
        Task<List<Matricula>> GetAllAsync();
        Task<Matricula> AddASync(Matricula matricula);
        Task<Matricula> UpdateASync(Matricula matricula);
        Task<Matricula> DeleteASync(int id);
    }
}
