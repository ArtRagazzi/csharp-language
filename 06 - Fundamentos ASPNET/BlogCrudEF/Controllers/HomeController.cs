using Microsoft.AspNetCore.Mvc;

namespace BlogCrudEF.Controllers;

[ApiController]
[Route("")]
public class HomeController : ControllerBase{

    //Usado como Health Check (verifica se a api esta respondendo)
    [HttpGet("")]
    public IActionResult Get(){
        return Ok();
    }
    
    
}