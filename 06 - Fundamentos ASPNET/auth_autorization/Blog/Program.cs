using Blog.Data;
using Blog.Services;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

builder
    .Services
    .AddControllers()
    .ConfigureApiBehaviorOptions(options =>
    {
        options.SuppressModelStateInvalidFilter = true;
    });

//Servico DataContext
builder.Services.AddDbContext<BlogDataContext>();
builder.Services.AddTransient<TokenService>();

//Tipos de Injeções de Dependencias (SERVICOS)
//builder.Services.AddTransient(); // Sempre Cria uma nova Instancia
//builder.Services.AddScoped(); // A cada requisicao gera uma nova Instancia
//builder.Services.AddSingleton();// Gera somente um na memoria e utiliza somente ele (CASO REINICIE A APLICACAO ELE GERA UM NOVO)

var app = builder.Build();
app.MapControllers();

app.Run();