using Sistema_cvihm.Enums;

namespace Sistema_cvihm.Models
{
    public class TarefaModel
    {

        public int Id { get; set; } 

        public string? Nome { get; set; }

        public string? Descrição { get; set; }

        public StatusTarefas Status { get; set; }

        public int? UsuarioId { get; set; }  
        
        public virtual UsersModel? Usuario { get; set; }
    }
}
