using Api_Event.Domains;

namespace Api_Event.Interface
{
    public interface IUsuarioRepository
    {
        void Cadastrar(Usuario NovoUsuario);
        Usuario BuscarPorId (Guid Id);
        Usuario BuscarPorEmailESenha (string Email, string Senha);
    }
}
