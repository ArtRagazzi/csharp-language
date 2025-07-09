using Microsoft.AspNetCore.Mvc;
using Todo.Data;
using Todo.Models;

namespace Todo.Controllers;

[ApiController]
public class HomeController : ControllerBase{
    
    [HttpGet("/")] // Funciona direto tbm
    //[Route("/")]
    public IActionResult Get([FromServices] AppDbContext context){
        return Ok(context.Todos.ToList());
    }

    [HttpGet("/{id:int}")]
    public IActionResult GetById([FromRoute] int id, [FromServices] AppDbContext context){
        var todos = context.Todos.FirstOrDefault(x=> x.Id==id);
        if (todos == null){
            return NotFound();
        }
        return Ok(todos);
    }
    
    [HttpPost("/")]
    public IActionResult Save(
        [FromBody] TodoModel model,
        [FromServices] AppDbContext context
    ){
        context.Todos.Add(model);
        context.SaveChanges();
        return Created($"/{model.Id}",model);
    }

    [HttpPut("/{id:int}")]
    public IActionResult Put([FromServices] AppDbContext context, [FromRoute] int id, [FromBody] TodoModel model){
        var modelToUpdate = context.Todos.FirstOrDefault(x=> x.Id==id);
        if (modelToUpdate == null){
            return NotFound();
        }
        modelToUpdate.Title = model.Title;
        modelToUpdate.IsCompleted = model.IsCompleted;
        context.Todos.Update(modelToUpdate);
        context.SaveChanges();
        return Ok(modelToUpdate);
    }

    [HttpDelete("/{id:int}")]
    public IActionResult Delete([FromServices] AppDbContext context, [FromRoute] int id){
        var modelToDelete = context.Todos.FirstOrDefault(x=> x.Id==id);
        if (modelToDelete == null){
            return NotFound();
        }
        context.Todos.Remove(modelToDelete);
        context.SaveChanges();
        return Ok(modelToDelete);
    }
    
}