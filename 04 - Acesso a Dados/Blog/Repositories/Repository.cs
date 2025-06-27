using Blog.Models;
using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;

namespace Blog.Repositories;


//Dessa forma eu nao preciso criar um Repository para cada Entidade

//Só vou aceitar se o T for herdade de BaseModel
public class Repository<T> where T:BaseModel{
    
    private readonly SqlConnection _connection;

    public Repository(SqlConnection connection){
        this._connection = connection;
    }
    
    
    public List<T> GetAll(){
        return _connection.GetAll<T>().ToList();
    }
    
    
    public T Get(int id){
        return _connection.Get<T>(id);
    }

    public void Insert(T model){
        _connection.Insert(model);
    }

    public void Update(T model, int id){
        model.Id = id; // Define o ID Corretamente antes de atualizar
        _connection.Update(model);
    }

    public void Delete(int id){
        var model = _connection.Get<T>(id);
        _connection.Delete<T>(model);
    }
    //Overload (Sobrecarga)
    public void Delete(T model){
        if (model.Id != 0){
            _connection.Delete<T>(model);
        }
    }
}

