using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorDeTarefas.Domain.Enums
{
    public enum StatusTarefa
    {
        [Description("Pendente")]
        Pendente = 1,
        [Description("Em Progresso")]
        Em_Progresso = 2,
        [Description("Concluída")]
        Concluida = 3
    }
}
