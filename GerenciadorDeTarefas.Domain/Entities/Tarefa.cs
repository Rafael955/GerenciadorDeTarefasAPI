using GerenciadorDeTarefas.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static GerenciadorDeTarefas.Domain.Dtos.Responses.TarefaResponseDto;

namespace GerenciadorDeTarefas.Domain.Entities
{
    public class Tarefa
    {
        [Key]
        public int Id { get; set; }

        public required string Titulo { get; set; } = string.Empty;

        public required string Descricao { get; set; } = string.Empty;

        public required DateTime DataCriacao { get; set; }

        public DateTime? DataConclusao { get; set; }

        public StatusTarefa Status { get; set; } = StatusTarefa.Pendente;
    }
}
