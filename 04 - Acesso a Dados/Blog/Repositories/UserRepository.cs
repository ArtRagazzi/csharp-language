using Blog.Models;
using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;

namespace Blog.Repositories;

public class UserRepository{

    private readonly SqlConnection _connection;


    public UserRepository(SqlConnection connection){
        this._connection = connection;
    }
    
    public List<User> GetUsers(){
        return _connection.GetAll<User>().ToList();
    }

    User GetUser(int id){
        return _connection.Get<User>(id);
    }

    void InsertUser(User user){
        _connection.Insert(user);
    }

    void UpdateUser(User user, int id){
        user.Id = id; // Define o ID Corretamente antes de atualizar
        _connection.Update(user);
    }

    void DeleteUser(int id){
        var user = _connection.Get<User>(id);
        _connection.Delete<User>(user);
    }
    //Overload (Sobrecarga)
    void DeleteUser(User user){
        if (user.Id != 0){
            DeleteUser(user.Id);
        }
    }
}