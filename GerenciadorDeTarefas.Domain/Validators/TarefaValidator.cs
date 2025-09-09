using GerenciadorDeTarefas.Domain.Dtos.Requests;
using GerenciadorDeTarefas.Domain.Enums;

namespace GerenciadorDeTarefas.Domain.Validators
{
    public static class TarefaValidator
    {
        public static void Validar(TarefaRequestDto request)
        {
            if (!Enum.IsDefined(typeof(StatusTarefa), request.Status))
                throw new ApplicationException("Status da Tarefa informado � inv�lido!");

            #region Regra de Neg�cio: O campo t�tulo dever� ter no m�ximo 100 caracteres

            if (request.Titulo.Length > 100)
                throw new ApplicationException("O campo t�tulo dever� ter no m�ximo 100 caracteres!");

            #endregion

            #region Regra de Neg�cio: A Data de Conclus�o da Tarefa deve ser maior do que a Data de Cria��o

            if (request.DataConclusao != null && request.DataConclusao < request.DataCriacao)
                throw new ApplicationException("A Data de Conclus�o da Tarefa dever� ser maior do que a Data de Cria��o da Tarefa.");

            #endregion
        }
    }
}