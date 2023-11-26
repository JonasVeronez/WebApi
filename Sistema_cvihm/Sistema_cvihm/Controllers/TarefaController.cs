using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sistema_cvihm.Models;
using Sistema_cvihm.Repositorios.Interface;

namespace Sistema_cvihm.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TarefaController : ControllerBase  
    {

        private readonly ITarefasRepositorio _tarefaRepositorio;


        public TarefaController(ITarefasRepositorio tarefaRepositorio)
        {
            _tarefaRepositorio = tarefaRepositorio;
        }

        [HttpGet]

        public async Task<ActionResult<List<TarefaModel>>> Listartodas() 
        {
            List<TarefaModel> tarefas = await _tarefaRepositorio.BuscarTodasTarefas();
            return Ok(tarefas);
        
        }

        [HttpGet("{id}")]

        public async Task<ActionResult<List<TarefaModel>>> BuscarPorId(int id)
        {
            TarefaModel tarefa = await _tarefaRepositorio.BuscarPorId(id);
            return Ok(tarefa);

        }

        [HttpPost]

        public async Task<ActionResult<TarefaModel>> Cadastrar([FromBody] TarefaModel tarefaModel)
        {
            TarefaModel tarefa = await _tarefaRepositorio.Adicionar(tarefaModel);

            return Ok(tarefa);
        }

        [HttpPut("{id}")]

        public async Task<ActionResult<TarefaModel>> Atualizar([FromBody] TarefaModel tarefaModel, int id  )
        {
            tarefaModel.Id = id;
            TarefaModel usuario = await _tarefaRepositorio.Atualizar(tarefaModel, id);

            return Ok(usuario);
        }

        [HttpDelete("{id}")]

        public async Task<ActionResult<TarefaModel>> Apagar(int id)
        {
            
            bool apagando = await _tarefaRepositorio.Apagar(id);

            return Ok(apagando);
        }
    }
}
