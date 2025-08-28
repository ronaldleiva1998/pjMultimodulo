using pjMultimodulo.Entities;

namespace pjMultimodulo.Services.Interfaces
{
    public interface IUsuarioService
    {
        Task<int> RegistrarAsync(Usuario usuario, string password);
        Task<Usuario?> LoginAsync(string email, string password);
    }
}
