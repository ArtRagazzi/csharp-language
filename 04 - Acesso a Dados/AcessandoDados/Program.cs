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
                Console.Clear();
                //InsertCategory(conn);
                //InsertManyCategory(conn);
                //UpdateCategory(conn);
                //ListCategories(conn);
                //DeleteCategory(conn,new Guid("84614f7e-31ee-4f23-ba76-8273f368c8cf"));
                //ExecuteProcedure(conn);
                //ExecuteReadProcedure(conn);
                //ReadView(conn);
                //OneToOne(conn);
                OneToMany(conn);
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
        
        static void InsertManyCategory(SqlConnection connection){
            var categoryToInsert = new Category("Amazon AWS1", "amazon1", 8, "AWS Cloud1",
                "Categoria destinada a serviços da AWS1",false);
            
            var categoryToInsert2 = new Category("Amazon AWS2", "amazon2", 8, "AWS Cloud2",
                "Categoria destinada a serviços da AWS2",true);

            var insertSQL = "INSERT INTO Category(Id, Title, Url, [Order], Summary, Description, Featured) VALUES (@id, @title, @url, @order, @summary, @description, @featured)";

            var rows = connection.Execute(insertSQL, new[]{
                    new 
                    {
                        id = categoryToInsert.Id,
                        title = categoryToInsert.Title,
                        url = categoryToInsert.Url,
                        order = categoryToInsert.Order,
                        summary = categoryToInsert.Summary,
                        description = categoryToInsert.Description,
                        featured = categoryToInsert.Featured
                    },
                    new 
                    { 
                        id = categoryToInsert2.Id,
                        title = categoryToInsert2.Title,
                        url = categoryToInsert2.Url,
                        order = categoryToInsert2.Order,
                        summary = categoryToInsert2.Summary,
                        description = categoryToInsert2.Description,
                        featured = categoryToInsert2.Featured
                    }
                });
        }

        static void UpdateCategory(SqlConnection connection){
            var updateQuery = "UPDATE Category SET Title=@title WHERE Id=@id";
            var rows = connection.Execute(updateQuery,
                new{ id = "84614f7e-31ee-4f23-ba76-8273f368c8cf", title = "AWS 2025" });
            Console.WriteLine("Linhas Atualizadas: "+ rows);
        }
        
        static void DeleteCategory(SqlConnection connection, Guid id){
            var deleteQuery = "DELETE FROM Category WHERE Id = @id";
            var rows = connection.Execute(deleteQuery, new{ id });
            Console.WriteLine("Linhas excludias "+rows);
        }

        static void ExecuteProcedure(SqlConnection connection){
            var procedure = "spDeleteStudent";
            var par = new{ StudentId = "5404e368-1084-4289-b371-4a4851529863" };
            
            var rows =connection.Execute(procedure , par, commandType: System.Data.CommandType.StoredProcedure);
            Console.WriteLine("Linhas afetadas: "+rows);
        }
        
        static void ExecuteReadProcedure(SqlConnection connection){
            var procedure = "spGetCourseByCategory";
            var parm = new{ CategoryId = "09ce0b7b-cfca-497b-92c0-3290ad9d5142" };
            
            var courses = connection.Query(
                procedure, 
                parm,
                commandType: System.Data.CommandType.StoredProcedure);

            foreach (var item in courses){
                Console.WriteLine($"{item.Id} - {item.Title}");
            }
        }

        static void ReadView(SqlConnection connection){
            var sql = "SELECT * FROM vwCourse";
         
            var courses = connection.Query(sql);
            foreach (var item in courses){
                Console.WriteLine($"{item.Id} - {item.Title}");
            }
        }


        static void OneToOne(SqlConnection connection){
            var sql = "SELECT * FROM CareerItem INNER JOIN Course ON CareerItem.CourseId = Course.Id";
            var items = connection.Query<CareerItem, Course, CareerItem>(sql, (careerItem, course) => {
                careerItem.Course = course;
                return careerItem;
            }, splitOn:"Id");
            foreach (var item in items ){
                Console.WriteLine($"{item.Title} - {item.Course.Title}");
            }
        }

        static void OneToMany(SqlConnection connection){
            var sql = @"SELECT 
                            Career.Id,
                            Career.Title,
                            CareerItem.CareerId,
                            CareerItem.Title
                        FROM 
                            Career
                        INNER JOIN
                            CareerItem ON CareerItem.CareerId = Career.Id
                        ORDER BY
                            Career.Title";
            var careers = new List<Career>();
            var items= connection.Query<Career, CareerItem, Career>(sql,
                (career, careerItem) => {
                    var car = careers.Where(x => x.Id == career.Id).FirstOrDefault();
                    if (car == null){
                        car = career;
                        car.Items.Add(careerItem);
                        careers.Add(car);
                    }
                    else{
                        car.Items.Add(careerItem);
                    }
                    return career;
                }, splitOn: "CareerId");
            foreach (var career in  careers){
                Console.WriteLine($"{career.Title}");
                foreach (var cItems in career.Items){
                    Console.WriteLine($"- {cItems.Title}");
                }
            }
        }
    }
}