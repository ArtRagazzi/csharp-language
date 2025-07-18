using Blog.Data;
using Blog.Extensions;
using Blog.Models;
using Blog.Services;
using Blog.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using SecureIdentity.Password;

namespace Blog.Controllers;



[ApiController]
public class AccountController:ControllerBase{
    //Posso usar a Injeção de dependencia assim 
    // private readonly TokenService _tokenService;
    // public AccountController(TokenService tokenService){
    //     _tokenService = tokenService;
    //     
    // } OUUU

    
    [HttpPost("v1/accounts/login")]
    //ASSIM
    public async Task<IActionResult>  Login([FromServices] TokenService tokenService, [FromBody] LoginViewModel loginViewModel, [FromServices]BlogDataContext dataContext ){

        if (!ModelState.IsValid){
            return BadRequest(new ResultViewModel<string>(ModelState.GetErrors()));
        }
        
        var user = await dataContext.Users
            .AsNoTracking()
            .Include(x=> x.Roles)
            .FirstOrDefaultAsync(x => x.Email == loginViewModel.Email);

        if (user == null){
            return StatusCode(401, new ResultViewModel<string>("Usuario ou senha invalidos"));
        }

        if (!PasswordHasher.Verify(user.PasswordHash, loginViewModel.Password)){
            return StatusCode(401, new ResultViewModel<string>("Usuario ou senha invalidos"));
        }
       
        
        //Password
        try{
            var token = tokenService.GenerateToken(user);
            return Ok(new ResultViewModel<string>(token, null));
        }
        catch (Exception e){
            return StatusCode(500, new ResultViewModel<string>(e.Message));
        }
    }

    [HttpPost("v1/accounts")]
    public async Task<IActionResult> Post([FromBody] RegisterViewModel model, [FromServices] BlogDataContext context){
        if (!ModelState.IsValid){
            return BadRequest(new ResultViewModel<string>(ModelState.GetErrors()));
        }

        var user = new User{
            Name = model.Name,
            Email = model.Email,
            Slug = model.Email.Replace("@", "-").Replace(".", "-")
        };

        var password = PasswordGenerator.Generate(25, true, false);
        user.PasswordHash = PasswordHasher.Hash(password);

        try{
            await context.Users.AddAsync(user);
            await context.SaveChangesAsync();
            return Ok(new ResultViewModel<dynamic>(new{
                user = user.Email, password
            }));
        }
        catch (DbUpdateException e){
            return StatusCode(400, new ResultViewModel<string>(e.Message));
        }
        catch (Exception e){
            return StatusCode(500, new ResultViewModel<string>(e.Message));
        }
    }
    
    

    // [Authorize(Roles = "user")]
    // [HttpGet("v1/user")]
    // public IActionResult GetUser(){
    //     return Ok(User.Identity.Name);
    // }
    //
    // [Authorize(Roles = "author")]
    // [Authorize(Roles = "admin")]
    // [HttpGet("v1/author")]
    // public IActionResult GetAuthor(){
    //     return Ok(User.Identity.Name);
    // }
    //
    // [Authorize(Roles = "admin")]
    // [HttpGet("v1/admin")]
    // public IActionResult GetAdmin(){
    //     return Ok(User.Identity.Name);
    // }
    //
    
    
}