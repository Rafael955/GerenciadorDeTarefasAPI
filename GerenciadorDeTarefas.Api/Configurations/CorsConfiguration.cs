namespace GerenciadorDeTarefas.Api.Configurations
{
    public static class CorsConfiguration
    {
        private const string PolicyName = "AllowAngularClient";

        // Método de extensão para registrar a política de CORS
        public static IServiceCollection AddCorsConfiguration(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(PolicyName, builder =>
                {
                    builder
                        .WithOrigins(
                            "http://localhost:4200" //desenvolvimento
                            ) // origem da aplicação Angular
                        .AllowAnyMethod()   // permite todos os métodos HTTP
                        .AllowAnyHeader();   // permite todos os cabeçalhos
                        //.AllowCredentials(); // permite envio de cookies/autenticação
                });
            });

            return services;
        }

        // Método de extensão para usar a política de CORS na pipeline da aplicação
        public static IApplicationBuilder UseCorsConfiguration(this IApplicationBuilder app)
        {
            app.UseCors(PolicyName);
            return app;
        }
    }
}
