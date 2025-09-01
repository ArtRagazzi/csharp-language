using OllamaSharp;

var url = new Uri("http://localhost:11434/");
var client = new OllamaApiClient(url);

var  models = await client.ListLocalModelsAsync();
// foreach (var model in models)
// {
//     Console.WriteLine(model.Name);
// }

client.SelectedModel = "llama3.2:latest";
var chat = new Chat(client);

Console.WriteLine("Qual a sua pergunta/duvida?");
var pergunta = Console.ReadLine() ?? string.Empty;

Console.WriteLine("Que tipo de humor você quer que eu responda? EX. Engraçado, Triste, Nervoso....");
var humor = Console.ReadLine() ?? "Normal";

var prompt = $"Responda a pergunta {pergunta} de forma/humor {humor}, quero que reforce o humor nas respostas, não quero que mostre a mensagem de confirmação, va direto para a resposta";
Console.Clear();
await foreach (var awnser in chat.SendAsync(prompt))
{
    Console.Write(awnser);
}
