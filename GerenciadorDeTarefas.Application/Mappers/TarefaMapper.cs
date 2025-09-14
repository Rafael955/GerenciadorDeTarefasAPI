using GerenciadorDeTarefas.Application.Dtos.Response;
using GerenciadorDeTarefas.Application.Extensions;
using GerenciadorDeTarefas.Domain.Entities;

namespace GerenciadorDeTarefas.Application.Mappers
{
    public class TarefaMapper
    {
        public static TarefaResponseDto ToResponse(Tarefa tarefa)
        {
            return new TarefaResponseDto
            {
                Id = tarefa.Id,
                Titulo = tarefa.Titulo,
                Descricao = tarefa.Descricao,
                DataCriacao = tarefa.DataCriacao,
                DataConclusao = tarefa.DataConclusao,
                Status = new StatusTarefaResponseDto
                {
                    Codigo = (int)tarefa.Status,
                    Descricao = tarefa.Status.GetDescription()

                    //Descricao = 
                    //    tarefa.Status == StatusTarefa.Pendente ? "Pendente" :
                    //    tarefa.Status == StatusTarefa.Em_Progresso ? "Em Progresso" :
                    //    tarefa.Status == StatusTarefa.Concluida ? "Concluída" : 
                    //    string.Empty 
                    //Isto viola o OCP do SOLID pois ao modificar o Enum iria precisar modificar também este método para incluir o novo enum
                }
            };
        }
    }
}
