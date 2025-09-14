using GerenciadorDeTarefas.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorDeTarefas.Application.Extensions
{
    public static class StatusTarefaExtension
    {
        public static string GetDescription(this StatusTarefa status)
        {
            //Obtém o campo do enum correspondente ao valor atual.
            var field = status.GetType().GetField(status.ToString());

            //Busca o atributo [Description] aplicado ao campo.
            var attr = field?.GetCustomAttribute<DescriptionAttribute>();

            //Se o atributo existir, retorna sua descrição; caso contrário, retorna o nome do enum.
            return attr?.Description ?? status.ToString();
        }
    }
}
