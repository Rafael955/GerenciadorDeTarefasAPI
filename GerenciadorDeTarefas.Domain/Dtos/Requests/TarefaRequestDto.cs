using GerenciadorDeTarefas.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorDeTarefas.Domain.Dtos.Requests
{
    public class TarefaRequestDto
    {
        [Required(ErrorMessage = "Por favor, informe um titulo para a tarefa!")]
        public string Titulo { get; set; }

        [Required(ErrorMessage = "Por favor, informe um descrição para a tarefa!")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "Por favor, informe uma data de criação para a tarefa!")]
        public DateTime DataCriacao { get; set; }

        public DateTime? DataConclusao { get; set; }

        [Required(ErrorMessage = "Por favor, informe um status para a tarefa!")]
        public int Status { get; set; }
    }
}
