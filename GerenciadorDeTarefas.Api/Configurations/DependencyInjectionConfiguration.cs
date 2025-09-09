using GerenciadorDeTarefas.Domain.Interfaces.Repositories;
using GerenciadorDeTarefas.Domain.Interfaces.Services;
using GerenciadorDeTarefas.Domain.Services;
using GerenciadorDeTarefas.Infra.Data.Repositories;

namespace GerenciadorDeTarefas.Api.Configurations
{
    public static class DependencyInjectionConfiguration
    {
        public static void AddDependencyInjection(this IServiceCollection service)
        {
            service.AddTransient<ITarefasRepository, TarefasRepository>();
            service.AddTransient<ITarefasDomainService, TarefasDomainService>();
        }
    }
}
