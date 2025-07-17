using Blog.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace Blog.Controllers;

[ApiController]
public class AccountController:ControllerBase{
    //Posso usar a Injeção de dependencia assim 
    // private readonly TokenService _tokenService;
    // public AccountController(TokenService tokenService){
    //     _tokenService = tokenService;
    //     
    // } OUUU

    [HttpPost("v1/login")]
    //ASSIM
    public IActionResult Login([FromServices] TokenService tokenService){
        var token = tokenService.GenerateToken(null);
        
        return Ok(token);
    }
    
    
}