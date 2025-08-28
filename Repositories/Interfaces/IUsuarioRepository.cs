using pjMultimodulo.Entities;

namespace pjMultimodulo.Repositories.Interfaces
{
    public interface IUsuarioRepository
    {
        Task<int> RegistrarAsync(Usuario usuario);
        Task<Usuario?> LoginAsync(string email);
    }
}
