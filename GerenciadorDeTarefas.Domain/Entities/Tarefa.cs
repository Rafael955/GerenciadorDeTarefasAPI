using GerenciadorDeTarefas.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace GerenciadorDeTarefas.Domain.Entities
{
    public class Tarefa
    {
        [Key]
        public int Id { get; private set; }

        public string Titulo { get; private set; }

        public string Descricao { get; private set; }

        public DateTime DataCriacao { get; private set; }

        public DateTime? DataConclusao { get; private set; }

        public StatusTarefa Status { get; private set; }

        // ✅ Construtor usado pelo EF
        private Tarefa(int id, string titulo, string descricao, DateTime dataCriacao, DateTime? dataConclusao, StatusTarefa status)
        {
            Id = id;
            Titulo = titulo;
            Descricao = descricao;
            DataCriacao = dataCriacao;
            DataConclusao = dataConclusao;
            Status = status;
        }

        // ✅ Construtor usado pela aplicação (DTO → Entidade)
        public Tarefa(string titulo, string descricao, DateTime dataCriacao, DateTime? dataConclusao, int status)
        {
            ValidarTarefa(titulo, descricao, dataCriacao, dataConclusao, status);

            Titulo = titulo;
            Descricao = descricao;
            DataCriacao = dataCriacao;
            DataConclusao = dataConclusao;
            Status = (StatusTarefa)status;
        }

        public void AlterarTarefa(string titulo, string descricao, DateTime dataCriacao, DateTime? dataConclusao, int status)
        {
            ValidarTarefa(titulo, descricao, dataCriacao, dataConclusao, status);

            Titulo = titulo;
            Descricao = descricao;
            DataCriacao = dataCriacao;
            DataConclusao = dataConclusao;
            Status = (StatusTarefa)status;
        }

        private void ValidarTarefa(string titulo, string descricao, DateTime dataCriacao, DateTime? dataConclusao, int status)
        {
            if (!Enum.IsDefined(typeof(StatusTarefa), status))
                throw new ApplicationException("Status da Tarefa informado é inválido!");

            if (string.IsNullOrWhiteSpace(titulo) || titulo.Length < 10)
                throw new ApplicationException("O título deverá ter no mínimo 10 caracteres!");

            if (titulo.Length > 100)
                throw new ApplicationException("O título deverá ter no máximo 100 caracteres!");
         
            if (string.IsNullOrWhiteSpace(descricao) || descricao.Length < 15)
                throw new ApplicationException("O descrição da tarefa deverá ter no mínimo 15 caracteres!");

            if (descricao.Length > 200)
                throw new ApplicationException("A descrição da tarefa deverá ter no máximo 200 caracteres!");

            if (dataConclusao.HasValue && dataConclusao.Value < dataCriacao)
                throw new ApplicationException("A Data de Conclusão da Tarefa deverá ser maior do que a Data de Criação da Tarefa.");
        }
    }
}
