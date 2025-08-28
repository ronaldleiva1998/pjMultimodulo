using Dapper;
using System.Data;
using pjMultimodulo.Entities;
using pjMultimodulo.Repositories.Interfaces;

namespace pjMultimodulo.Repositories.Implementations
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly IDbConnection _db;

        public UsuarioRepository(IDbConnection db) => _db = db;

        public async Task<int> RegistrarAsync(Usuario usuario)
        {
            var sql = @"INSERT INTO Usuario (Nombre, Email, PasswordHash) 
                        VALUES (@Nombre, @Email, @PasswordHash);
                        SELECT CAST(SCOPE_IDENTITY() as int)";
            return await _db.ExecuteScalarAsync<int>(sql, usuario);
        }

        public async Task<Usuario?> LoginAsync(string email)
        {
            var sql = "SELECT * FROM Usuario WHERE Email = @Email";
            return await _db.QueryFirstOrDefaultAsync<Usuario>(sql, new { Email = email });
        }
    }
}
