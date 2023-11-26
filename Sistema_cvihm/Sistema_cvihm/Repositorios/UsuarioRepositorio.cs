using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sistema_cvihm.Data;
using Sistema_cvihm.Models;
using Sistema_cvihm.Repositorios.Interface;

namespace Sistema_cvihm.Repositorios
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private readonly SistemasTarefasContext _dbContext;
        public UsuarioRepositorio(SistemasTarefasContext sistemasTarefasContext )
        {
            _dbContext = sistemasTarefasContext;
        }

        public async Task<UsersModel> BuscarPorId(int id)
        {
            return await _dbContext.Usuarios.FirstOrDefaultAsync( x => x.Id == id );  
        }

        public async Task<List<UsersModel>> BuscarTodosUsuarios()
        {
            return await _dbContext.Usuarios.ToListAsync();
        }
        public async Task<UsersModel> Adicionar(UsersModel usuario)
        {
            await _dbContext.Usuarios.AddAsync(usuario);
            await _dbContext.SaveChangesAsync();

            return  usuario;    
        }

        public async Task<UsersModel> Atualizar(UsersModel usuario, int id)
        {
            UsersModel usuarioPorId = await BuscarPorId(id);

            if (usuarioPorId == null)
            {
                throw new Exception($"Usuário para ID:{id} não foi enontrado no banco de dados.");
            }
            usuarioPorId.Nome = usuario.Nome;
            usuarioPorId.Email =  usuario.Email;

            _dbContext.Usuarios.Update(usuarioPorId);
            await _dbContext.SaveChangesAsync();   

            return usuarioPorId;    

        }

        public async Task<bool> Apagar(int id)
        {

            UsersModel usuarioPorId = await BuscarPorId(id);

            if (usuarioPorId == null)
            {
                throw new Exception($"Usuário para ID:{id} não foi enontrado no banco de dados.");
            }
            _dbContext.Usuarios.Remove(usuarioPorId);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Deletar(int id)
        {
            UsersModel usuarioPorId = await BuscarPorId(id);

            if (usuarioPorId == null)
            {
                throw new Exception($"Usuário para ID:{id} não foi enontrado no banco de dados.");
            }
            _dbContext.Usuarios.Remove(usuarioPorId);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
