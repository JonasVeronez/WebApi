using Sistema_cvihm.Data;
using Sistema_cvihm.Models;

namespace Sistema_cvihm.Repositorios.Interface
{
    public interface ITarefasRepositorio
    {

        Task<List<TarefaModel>> BuscarTodasTarefas();
        Task<TarefaModel> BuscarPorId(int id);   
        Task<TarefaModel> Adicionar(TarefaModel tarefa);
        Task<TarefaModel> Atualizar(TarefaModel tarefa, int id);
        Task<bool> Apagar(int id);
        Task<bool> Deletar(int id);
    }
}
