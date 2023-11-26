using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sistema_cvihm.Models;
using Sistema_cvihm.Repositorios.Interface;

namespace Sistema_cvihm.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase  
    {

        private readonly IUsuarioRepositorio _usuarioRepositorio;


        public UserController(IUsuarioRepositorio usuarioRepositorio)
        {
            _usuarioRepositorio =  usuarioRepositorio;
        }

        [HttpGet]

        public async Task<ActionResult<List<UsersModel>>> BuscarTodosUsuarios() 
        {
            List<UsersModel> usuario = await _usuarioRepositorio.BuscarTodosUsuarios();
            return Ok(usuario);
        
        }

        [HttpGet("{id}")]

        public async Task<ActionResult<List<UsersModel>>> BuscarPorId(int id)
        {
            UsersModel usuario = await _usuarioRepositorio.BuscarPorId(id);
            return Ok(usuario);

        }

        [HttpPost]

        public async Task<ActionResult<UsersModel>> Cadastrar([FromBody] UsersModel usersModel)
        {
            UsersModel usuario = await _usuarioRepositorio.Adicionar(usersModel);

            return Ok(usuario);
        }

        [HttpPut("{id}")]

        public async Task<ActionResult<UsersModel>> Atualizar([FromBody] UsersModel usersModel, int id  )
        {
            usersModel.Id = id;
            UsersModel usuario = await _usuarioRepositorio.Atualizar(usersModel, id);

            return Ok(usuario);
        }

        [HttpDelete("{id}")]

        public async Task<ActionResult<UsersModel>> Apagar(int id)
        {
            
            bool apagando = await _usuarioRepositorio.Apagar(id);

            return Ok(apagando);
        }
    }
}
