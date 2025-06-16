using AcessandoDados.Models;
using Dapper;
using Microsoft.Data.SqlClient;
namespace AcessandoDados{

    public class Program{
        static void Main(string[] args){
            const string databaseConnection = "Server=localhost,1433;Database=balta;User ID=sa;Password=1q2w3e4r@#$;TrustServerCertificate=True";
            
            //Microsoft.Data.SqlClient (NUGET)

            //var connection = new SqlConnection();
            //connection.Open();
            //Faz oq tem que fazer
            //connection.Close();
            //Ja abre e fecha sozinho
            //Utilizando a forma antiga sem abstração -> ADO.Net
            /*using (var conn = new SqlConnection(databaseConnection)){
                Console.WriteLine("Conectado");
                conn.Open();
                using (var command = new SqlCommand()){
                    command.Connection = conn;
                    command.CommandType = System.Data.CommandType.Text;
                    command.CommandText = "SELECT [Id], [Title] FROM [Category]";
                    
                    var reader = command.ExecuteReader();
                    while (reader.Read()){
                        Console.WriteLine($"{reader.GetGuid(0)} - {reader.GetString(1)}");
                    }
                }
            }*/

            //Usando Dapper
            //Nao ficar gerando codigo dentro da Sessao aberta
            using (var conn = new SqlConnection(databaseConnection)){
                InsertCategory(conn);
                UpdateCategory(conn);
                ListCategories(conn);
            }
            
        }

        static void ListCategories(SqlConnection connection){
            var categories = connection.Query<Category>("SELECT Id, Title FROM Category ORDER BY Id ASC");
            foreach (var item in categories){
                Console.WriteLine($"{item.Id} - {item.Title}");
            }
        }

        static void InsertCategory(SqlConnection connection){
            var categoryToInsert = new Category("Amazon AWS", "amazon", 8, "AWS Cloud",
                "Categoria destinada a serviços da AWS",false);

            var insertSQL = "INSERT INTO Category(Id, Title, Url, [Order], Summary, Description, Featured) VALUES (@id, @title, @url, @order, @summary, @description, @featured)";

            var rows = //Realizando Insert
                connection.Execute(insertSQL, new{
                    id = categoryToInsert.Id,
                    title = categoryToInsert.Title,
                    url = categoryToInsert.Url,
                    order = categoryToInsert.Order,
                    summary = categoryToInsert.Summary,
                    description = categoryToInsert.Description,
                    featured = categoryToInsert.Featured
                });
        }

        static void UpdateCategory(SqlConnection connection){
            var updateQuery = "UPDATE Category SET Title=@title WHERE Id=@id";
            var rows = connection.Execute(updateQuery,
                new{ id = "84614f7e-31ee-4f23-ba76-8273f368c8cf", title = "AWS 2025" });
            Console.WriteLine("Linhas Atualizadas: "+ rows);
        }
    }
}