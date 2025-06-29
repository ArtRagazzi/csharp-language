using Dapper;
using Microsoft.Data.SqlClient;

namespace Blog.Repositories;

public class UserRoleRepository{
    private readonly SqlConnection _connection;

    public UserRoleRepository(SqlConnection connection){
        this._connection = connection;
    }

    public void UnionUserRole(int userId, int roleId){
        var query = @"
                    INSERT INTO UserRole
                    VALUES(
                        @uid,@rid
                    )";
        
        var rows = _connection.Execute(query, new{
            uid = userId, rid = roleId
        });
    }
    
    
}