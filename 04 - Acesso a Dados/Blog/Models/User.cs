using Dapper.Contrib.Extensions;

namespace Blog.Models;

[Table("[User]")]
public class User : BaseModel{
    
    public string Name{ get; set; }
    public string Email{ get; set; }
    public string PasswordHash{ get; set; }
    public string Bio{ get; set; }
    public string Image{ get; set; }
    public string Slug{ get; set; }
    
    //Não utiliza o Role no Insert
    [Write(false)]
    public List<Role> Roles{ get; set; }


    public User(){
        this.Roles = new List<Role>();
    }
    public User( string name, string email, string passwordHash, string bio, string image, string slug){
        this.Name = name;
        this.Email = email;
        this.PasswordHash = passwordHash;
        this.Bio = bio;
        this.Image = image;
        this.Slug = slug;
        this.Roles = new List<Role>();
    }

    public override string ToString(){
        return $"Id: {Id}, Name: {Name}, Email: {Email}, PasswordHash: {PasswordHash}, Bio: {Bio}";
    }
}