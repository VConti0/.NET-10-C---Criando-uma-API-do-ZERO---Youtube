using Escola.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Escola.Domain.Interfaces
{
    public interface INotaRepository
    {
        Task<Nota> GetByIdAsync(int id);
        Task<List<Nota>> GetAllAsync();
        Task<Nota> AddASync(Nota nota);
        Task<Nota> UpdateASync(Nota nota);
        Task<Nota> DeleteASync(int id);
    }
}
