using GerenciadorDeTarefas.Application.Dtos.Request;
using GerenciadorDeTarefas.Application.Dtos.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorDeTarefas.Application.Interfaces.Services
{
    public interface ITarefasAppService
    {
        TarefaResponseDto CriarTarefa(TarefaRequestDto request);

        TarefaResponseDto AlterarTarefa(int IdTarefa, TarefaRequestDto request);

        TarefaResponseDto ExcluirTarefa(int IdTarefa);

        TarefaResponseDto ObterTarefaPorId(int IdTarefa);

        List<TarefaResponseDto>? ListarTarefas();
    }
}
