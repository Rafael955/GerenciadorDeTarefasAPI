using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorDeTarefas.Application.Dtos.Request
{
    public class TarefaRequestDto
    {
        [Required(ErrorMessage = "Por favor, informe um titulo para a tarefa!")]
        [MinLength(10, ErrorMessage = "O título da tarefa deverá ter no mínimo {1} caracteres")]
        [MaxLength(100, ErrorMessage = "O título da tarefa deverá ter no máximo {1} caracteres")]
        public string Titulo { get; set; }

        [Required(ErrorMessage = "Por favor, informe uma descrição para a tarefa!")]
        [MinLength(15, ErrorMessage = "A descrição da tarefa deverá ter no mínimo {1} caracteres")]
        [MaxLength(200, ErrorMessage = "A descrição da tarefa deverá ter no máximo {1} caracteres")]
        public string Descricao { get; set; }

        public DateTime DataCriacao { get; set; }

        public DateTime? DataConclusao { get; set; }

        [Required(ErrorMessage = "Por favor, informe um status para a tarefa!")]
        public int Status { get; set; }
    }
}
