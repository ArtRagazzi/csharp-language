using Todo.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers(); // Adiciona Controllers
builder.Services.AddDbContext<AppDbContext>();// Uso como servico, aspnet ira gerenciar automaticamente a conexao

var app = builder.Build();

app.MapControllers(); // Mapeia os controllers

app.Run();
