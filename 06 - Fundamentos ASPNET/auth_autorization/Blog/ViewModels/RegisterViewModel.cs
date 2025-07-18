using System.ComponentModel.DataAnnotations;

namespace Blog.ViewModels;

public class RegisterViewModel{

    [Required(ErrorMessage = "O Nome é obrigatorio")]
    public string Name{ get; set; }
    [Required(ErrorMessage = "O Email é obrigatorio")]
    [EmailAddress(ErrorMessage = "O Email é invalido")]
    public string Email{ get; set; }
}