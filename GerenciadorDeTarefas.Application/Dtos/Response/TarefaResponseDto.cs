using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorDeTarefas.Application.Dtos.Response
{
    public class TarefaResponseDto
    {
        public required int Id { get; set; }

        public required string Titulo { get; set; }

        public required string Descricao { get; set; }

        public required DateTime DataCriacao { get; set; }

        public DateTime? DataConclusao { get; set; }

        public required StatusTarefaResponseDto Status { get; set; }
    }
}
