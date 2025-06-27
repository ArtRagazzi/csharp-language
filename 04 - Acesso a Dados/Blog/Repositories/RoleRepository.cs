using Blog.Models;
using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;

namespace Blog.Repositories;

public class RoleRepository{
    private readonly SqlConnection _connection;


    public RoleRepository(SqlConnection connection){
        this._connection = connection;
    }
    
    public List<Role> GetRoles(){
        return _connection.GetAll<Role>().ToList();
    }

    Role GetRole(int id){
        return _connection.Get<Role>(id);
    }

    void InserRole(Role role){
        _connection.Insert(role);
    }

    void UpdateRole(Role role, int id){
        role.Id = id; // Define o ID Corretamente antes de atualizar
        _connection.Update(role);
    }

    void DeleteRole(int id){
        var role = _connection.Get<Role>(id);
        _connection.Delete<Role>(role);
    }
}