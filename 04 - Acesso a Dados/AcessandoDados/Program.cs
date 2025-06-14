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
            using (var conn = new SqlConnection(databaseConnection)){
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
            }

        }
    }
}