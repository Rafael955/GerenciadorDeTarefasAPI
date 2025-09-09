using GerenciadorDeTarefas.Domain.Dtos.Requests;
using GerenciadorDeTarefas.Domain.Dtos.Responses;
using GerenciadorDeTarefas.Domain.Entities;
using GerenciadorDeTarefas.Domain.Enums;
using GerenciadorDeTarefas.Domain.Extensions;
using GerenciadorDeTarefas.Domain.Interfaces.Repositories;
using GerenciadorDeTarefas.Domain.Interfaces.Services;
using GerenciadorDeTarefas.Domain.Mappers;
using GerenciadorDeTarefas.Domain.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorDeTarefas.Domain.Services
{
    public class TarefasDomainService (ITarefasRepository tarefasRepository) : ITarefasDomainService
    {
        public TarefaResponseDto CriarTarefa(TarefaRequestDto request)
        {
            TarefaValidator.Validar(request);

            var tarefa = new Tarefa
            {
                Titulo = request.Titulo,
                Descricao = request.Descricao,
                DataCriacao = request.DataCriacao,
                DataConclusao = request.DataConclusao,
                Status = (StatusTarefa)request.Status
            };

            tarefasRepository.Add(tarefa);

            return TarefaMapper.ToResponse(tarefa);
        }

        public TarefaResponseDto AlterarTarefa(int IdTarefa, TarefaRequestDto request)
        {
            var tarefa = tarefasRepository.GetById(IdTarefa);

            TarefaValidator.Validar(request);

            tarefa.Titulo = request.Titulo;
            tarefa.Descricao = request.Descricao;
            tarefa.DataCriacao = request.DataCriacao;
            tarefa.DataConclusao = request.DataConclusao;
            tarefa.Status = (StatusTarefa)request.Status;
            
            tarefasRepository.Update(tarefa);

            return TarefaMapper.ToResponse(tarefa);
        }

        public TarefaResponseDto ExcluirTarefa(int IdTarefa)
        {
            var tarefa = tarefasRepository.GetById(IdTarefa);

            if (tarefa == null)
                throw new ApplicationException("Tarefa não encontrada!");

            tarefasRepository.Delete(tarefa);

            return TarefaMapper.ToResponse(tarefa);
        }

        public TarefaResponseDto ObterTarefaPorId(int IdTarefa)
        {
            var tarefa = tarefasRepository.GetById(IdTarefa);

            if (tarefa == null)
                throw new ApplicationException("Tarefa não encontrada!");

            return TarefaMapper.ToResponse(tarefa);
        }

        public List<TarefaResponseDto>? ListarTarefas()
        {
            var tarefas = tarefasRepository.GetAll();

            if(tarefas != null && tarefas.Count == 0)
                throw new ApplicationException("Nenhuma tarefa foi encontrada!");

            List<TarefaResponseDto> tarefasDto = new List<TarefaResponseDto>();

            foreach (var tarefa in tarefas)
            {
                tarefasDto.Add(TarefaMapper.ToResponse(tarefa));
            }

            return tarefasDto;
        }
    }
}
