using Api_Event.Domains;

namespace Api_Event.Repositories
{
    public interface EventoRepository
    {
            void Cadastrar(Evento novoEvento);
            List<Evento> Listar();
            void Atualizar(Guid id, Evento evento);
            void Deletar(Guid id);
            Evento BuscarPorId(Guid id);
            //Listar os filmes pelo seu genero - filtro
            List<Evento> ListarPorGenero(Guid IdGenero);

    }
}
