using Escola.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Escola.Domain.Interfaces
{
    public interface IUsuarioRepository
    {
        Task<Usuario> GetByIdAsync(int id);
        Task<List<Usuario>> GetAllAsync();
        Task<Usuario> AddASync(Usuario usuario);
        Task<Usuario> UpdateASync(Usuario usuario);
        Task<Usuario> DeleteASync(int id);
    }
}
