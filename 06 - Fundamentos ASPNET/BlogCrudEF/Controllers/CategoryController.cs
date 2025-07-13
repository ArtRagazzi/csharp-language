using BlogCrudEF.Data;
using BlogCrudEF.Extensions;
using BlogCrudEF.Models;
using BlogCrudEF.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlogCrudEF.Controllers;

[ApiController]
[Route("")]
public class CategoryController : ControllerBase{
    
    [HttpGet("v1/categories")]
    public async Task<IActionResult> GetAsync([FromServices]BlogDataContext context){

        try{

            var categories = await context.Categories.ToListAsync();
            return Ok(new ResultViewModel<List<Category>>(categories));
        }
        catch{
            return StatusCode(500, new ResultViewModel<List<Category>>("05X04 - Falha interna do servidor"));
        }
        
    }
    
    
    [HttpGet("v1/categories/{id:int}")]
    public async Task<IActionResult> GetByIdAsync([FromServices]BlogDataContext context, [FromRoute] int id){
        try{
            
            var category = await context.Categories.FirstOrDefaultAsync(x=> x.Id == id);
            if (category == null){
                return NotFound(new ResultViewModel<Category>("Conteudo não encontrado"));
            }
            return Ok(new ResultViewModel<Category>(category));
        }catch (DbUpdateException e){
            return StatusCode(500, new ResultViewModel<Category>("Falha no Banco de dados"));
        }
        catch (Exception e){
            return StatusCode(500, new ResultViewModel<Category>("Falha interna no servidor"));
        }
        
    }
    
    
    [HttpPost("v1/categories")]
    public async Task<IActionResult> InsertAsync([FromServices]BlogDataContext context, [FromBody] EditorCategoryViewModel model){
        
        //Somente se desabilitar a validação do ASPNET
        if (!ModelState.IsValid){
            return BadRequest(new ResultViewModel<Category>(ModelState.GetErrors()));
        }
        
        try{
            var category = new Category{
                Id = 0,
                Name = model.Name,
                Slug = model.Slug.ToLower()
            };
            await context.Categories.AddAsync(category);
            await context.SaveChangesAsync();
            return Created($"v1/categories/{category.Id}", category);
        }
        catch (DbUpdateException e){
            return StatusCode(500, e.Message);
        }
        catch (Exception e){
            return StatusCode(500, "Internal server error");
        }
        
    }
    
    [HttpPut("v1/categories/{id:int}")]
    public async Task<IActionResult> UpdateAsync([FromServices]BlogDataContext context, [FromBody] EditorCategoryViewModel category, [FromRoute] int id){

        try{
            
            var categoryToUpdate = await context.Categories.FirstOrDefaultAsync(x=> x.Id == id);
            if (categoryToUpdate == null){
                return NotFound();
            }
            
            categoryToUpdate.Name = category.Name;
            categoryToUpdate.Slug = category.Slug;
            
            context.Categories.Update(categoryToUpdate);
            await context.SaveChangesAsync();
            
            return Ok(categoryToUpdate);
        }catch (DbUpdateException e){
            return StatusCode(500, e.Message);
        }
        catch (Exception e){
            return StatusCode(500, "Internal server error");
        }
        
    }
    
    [HttpDelete("v1/categories/{id:int}")]
    public async Task<IActionResult> DeleteAsync([FromServices]BlogDataContext context, [FromRoute] int id){
        try{
            var categoryToDelete = await context.Categories.FirstOrDefaultAsync(x=> x.Id == id);
            if (categoryToDelete == null){
                return NotFound();
            }
            
            context.Categories.Remove(categoryToDelete);
            await context.SaveChangesAsync();
            return Ok(categoryToDelete);
            
        }catch (DbUpdateException e){
            return StatusCode(500, e.Message);
        }
        catch (Exception e){
            return StatusCode(500, "Internal server error");
        }
        
    }
}