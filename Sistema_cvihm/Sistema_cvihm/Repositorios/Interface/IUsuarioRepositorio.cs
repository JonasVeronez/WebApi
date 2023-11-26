using Sistema_cvihm.Data;
using Sistema_cvihm.Models;

namespace Sistema_cvihm.Repositorios.Interface
{
    public interface IUsuarioRepositorio
    {

        Task<List<UsersModel>> BuscarTodosUsuarios();
        Task<UsersModel> BuscarPorId(int id);   
        Task<UsersModel> Adicionar(UsersModel usuario);
        Task<UsersModel> Atualizar(UsersModel usuario, int id);
        Task<bool> Apagar(int id);
        Task<bool> Deletar(int id);
    }
}
