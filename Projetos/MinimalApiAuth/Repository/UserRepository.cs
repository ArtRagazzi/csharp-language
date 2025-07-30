using MinimalApiAuth.Models;

namespace MinimalApiAuth.Repository;

public static class UserRepository
{
    public static User Get(string username, string password){
        var users = new List<User>{
            new User(){Id = 1, Username = "batman", Role = "manager"},
            new User(){Id = 2, Username = "superman", Role = "employee"}
        };
        return users.Where(x=> x.Username.ToLower() == username && x.Password == password).FirstOrDefault();
    }
}
