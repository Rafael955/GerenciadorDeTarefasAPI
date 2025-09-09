using GerenciadorDeTarefas.Domain.Entities;
using GerenciadorDeTarefas.Domain.Interfaces.Repositories;
using GerenciadorDeTarefas.Infra.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorDeTarefas.Infra.Data.Repositories
{
    public class TarefasRepository : ITarefasRepository
    {
        private readonly DataContext _context;

        public TarefasRepository(DataContext context)
        {
            _context = context;
        }

        public void Add(Tarefa tarefa)
        {
            _context.Add(tarefa);
            _context.SaveChanges();
        }

        public void Update(Tarefa tarefa)
        {
            _context.Update(tarefa);
            _context.SaveChanges();
        }

        public void Delete(Tarefa tarefa)
        {
            _context.Remove(tarefa);
            _context.SaveChanges();
        }

        public Tarefa GetById(int IdTarefa)
        {
            return _context.Set<Tarefa>()
                .SingleOrDefault(x => x.Id == IdTarefa);
        }

        public List<Tarefa> GetAll()
        {
            return _context.Set<Tarefa>()
                .AsNoTracking()
                .ToList();
        }
    }
}
