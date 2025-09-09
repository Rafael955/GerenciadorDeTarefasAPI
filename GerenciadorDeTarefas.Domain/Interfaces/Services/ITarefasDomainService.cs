using GerenciadorDeTarefas.Domain.Dtos.Requests;
using GerenciadorDeTarefas.Domain.Dtos.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorDeTarefas.Domain.Interfaces.Services
{
    public interface ITarefasDomainService
    {
        TarefaResponseDto CriarTarefa(TarefaRequestDto request);

        TarefaResponseDto AlterarTarefa(int IdTarefa, TarefaRequestDto request);

        TarefaResponseDto ExcluirTarefa(int IdTarefa);

        TarefaResponseDto ObterTarefaPorId(int IdTarefa);

        List<TarefaResponseDto>? ListarTarefas();
    }
}
