using GerenciadorDeTarefas.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorDeTarefas.Domain.Interfaces.Repositories
{
    public interface ITarefasRepository
    {
        void Add(Tarefa tarefa);

        void Update(Tarefa tarefa);

        void Delete(Tarefa tarefa);

        Tarefa GetById(int IdTarefa);

        List<Tarefa> GetAll();
    }
}
