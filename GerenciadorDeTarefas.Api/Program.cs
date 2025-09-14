using GerenciadorDeTarefas.Api.Configurations;

var builder = WebApplication.CreateBuilder(args);

builder.AddDbContext();

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi

builder.Services.AddDependencyInjection();
builder.Services.AddCorsConfiguration();

builder.Services.AddRouting(configureOptions =>
{
    configureOptions.LowercaseUrls = true;
});

builder.Services.AddOpenApi();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseSwagger();
app.UseSwaggerUI();

app.UseCorsConfiguration();

app.UseAuthorization();

app.MapControllers();

app.Run();
