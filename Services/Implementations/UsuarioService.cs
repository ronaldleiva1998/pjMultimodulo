using System.Security.Cryptography;
using System.Text;
using pjMultimodulo.Entities;
using pjMultimodulo.Repositories.Interfaces;
using pjMultimodulo.Services.Interfaces;

namespace pjMultimodulo.Services.Implementations
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _repo;

        public UsuarioService(IUsuarioRepository repo) => _repo = repo;

        public async Task<int> RegistrarAsync(Usuario usuario, string password)
        {
            usuario.PasswordHash = HashPassword(password);
            return await _repo.RegistrarAsync(usuario);
        }

        public async Task<Usuario?> LoginAsync(string email, string password)
        {
            var user = await _repo.LoginAsync(email);
            if (user == null) return null;

            return user.PasswordHash == HashPassword(password) ? user : null;
        }

        private string HashPassword(string password)
        {
            using var sha = SHA256.Create();
            var bytes = sha.ComputeHash(Encoding.UTF8.GetBytes(password));
            return Convert.ToBase64String(bytes);
        }
    }
}
