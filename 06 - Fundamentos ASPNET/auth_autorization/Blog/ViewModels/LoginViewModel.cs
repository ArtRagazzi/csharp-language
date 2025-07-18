using System.ComponentModel.DataAnnotations;

namespace Blog.ViewModels;

public class LoginViewModel{
    [Required(ErrorMessage = "A senha é obrigatorio")]
    public string Password{ get; set; }
    [Required(ErrorMessage = "O Email é obrigatorio")]
    [EmailAddress(ErrorMessage = "O Email é invalido")]
    public string Email{ get; set; }
}