using System.ComponentModel;

namespace Sistema_cvihm.Enums
{
    public enum StatusTarefas
    {
        [Description("A Fazer")]
            
        AFazer = 1,
        [Description("Em Andamento")]
        EmAndamento = 2,
        [Description("Concluir")]
        Concluido  = 3

    }
}
