using GerenciadorDeTarefas.Application.Interfaces.Services;
using GerenciadorDeTarefas.Application.Services;
using GerenciadorDeTarefas.Domain.Interfaces.Repositories;
using GerenciadorDeTarefas.Infra.Data.Repositories;

namespace GerenciadorDeTarefas.Api.Configurations
{
    public static class DependencyInjectionConfiguration
    {
        public static void AddDependencyInjection(this IServiceCollection service)
        {
            service.AddTransient<ITarefasRepository, TarefasRepository>();
            service.AddTransient<ITarefasAppService, TarefasAppService>();
        }
    }
}
