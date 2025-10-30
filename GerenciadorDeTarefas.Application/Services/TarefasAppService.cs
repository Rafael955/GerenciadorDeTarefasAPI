using GerenciadorDeTarefas.Application.Dtos.Request;
using GerenciadorDeTarefas.Application.Dtos.Response;
using GerenciadorDeTarefas.Application.Interfaces.Services;
using GerenciadorDeTarefas.Application.Mappers;
using GerenciadorDeTarefas.Domain.Entities;
using GerenciadorDeTarefas.Domain.Interfaces.Repositories;

namespace GerenciadorDeTarefas.Application.Services
{
    public class TarefasAppService(ITarefasRepository tarefasRepository) : ITarefasAppService
    {
        public TarefaResponseDto CriarTarefa(TarefaRequestDto request)
        {
            var tarefa = new Tarefa(request.Titulo, request.Descricao, DateTime.UtcNow, request.DataConclusao, request.Status);
     
            tarefasRepository.Add(tarefa);

            return tarefa.ToResponse();
        }

        public TarefaResponseDto AlterarTarefa(int IdTarefa, TarefaRequestDto request)
        {
            var tarefa = tarefasRepository.GetById(IdTarefa);

            tarefa.AlterarTarefa(request.Titulo, request.Descricao, tarefa.DataCriacao, request.DataConclusao, request.Status);

            tarefasRepository.Update(tarefa);

            return tarefa.ToResponse();
        }

        public TarefaResponseDto ExcluirTarefa(int IdTarefa)
        {
            var tarefa = tarefasRepository.GetById(IdTarefa);

            if (tarefa == null)
                throw new ApplicationException("Tarefa não encontrada!");

            tarefasRepository.Delete(tarefa);

            return tarefa.ToResponse();
        }

        public TarefaResponseDto ObterTarefaPorId(int IdTarefa)
        {
            var tarefa = tarefasRepository.GetById(IdTarefa);

            if (tarefa == null)
                throw new ApplicationException("Tarefa não encontrada!");

            return tarefa.ToResponse();
        }

        public List<TarefaResponseDto>? ListarTarefas()
        {
            var tarefas = tarefasRepository.GetAll();

            if (tarefas == null || tarefas.Count == 0)
                throw new ApplicationException("Nenhuma tarefa foi encontrada!");

            List<TarefaResponseDto> tarefasDto = new List<TarefaResponseDto>();

            foreach (var tarefa in tarefas)
            {
                tarefasDto.Add(tarefa.ToResponse());
            }

            return tarefasDto;
        }
    }

    /*O que é o TarefasAppService?

        Ele é um Application Service, ou seja, uma classe que orquestra os casos de uso relacionados a Tarefa.

        👉 Função principal:

        Receber dados vindos da API (DTOs).

        Validar a entrada (quando não for só responsabilidade do DTO/Validator).

        Chamar o Domínio para criar/manipular a entidade (ex.: new Tarefa(...), tarefa.Alterar(...)).

        Usar os Repositórios (interfaces do Domain) para persistir ou buscar dados.

        Retornar DTOs de resposta para a camada Presentation (API).*/
}
