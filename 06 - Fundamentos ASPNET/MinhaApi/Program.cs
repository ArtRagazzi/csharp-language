var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

List<Pessoa> pessoas = new List<Pessoa>();

app.MapGet("/", () => {
    
    return Results.Ok(pessoas);
});

app.MapPost("/", (Pessoa pessoa) => {   
    pessoas.Add(pessoa);
    return Results.Ok(pessoa);
});

app.Run();

public class Pessoa
{
    public int Id { get; set; }
    public string Nome { get; set; }
}