using GerenciadorDeTarefas.Domain.Dtos.Requests;
using GerenciadorDeTarefas.Domain.Enums;

namespace GerenciadorDeTarefas.Domain.Validators
{
    public static class TarefaValidator
    {
        public static void Validar(TarefaRequestDto request)
        {
            if (!Enum.IsDefined(typeof(StatusTarefa), request.Status))
                throw new ApplicationException("Status da Tarefa informado é inválido!");

            #region Regra de Negócio: O campo título deverá ter no máximo 100 caracteres

            if (request.Titulo.Length > 100)
                throw new ApplicationException("O campo título deverá ter no máximo 100 caracteres!");

            #endregion

            #region Regra de Negócio: A Data de Conclusão da Tarefa deve ser maior do que a Data de Criação

            if (request.DataConclusao != null && request.DataConclusao < request.DataCriacao)
                throw new ApplicationException("A Data de Conclusão da Tarefa deverá ser maior do que a Data de Criação da Tarefa.");

            #endregion
        }
    }
}