using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Blog.Attributes;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
public class ApiKeyAttribute : Attribute, IAsyncActionFilter{
    public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next){
        if (!context.HttpContext.Request.Query.TryGetValue(Configuration.API_KEY_NAME, out var extractedApiKey)){
            context.Result = new ContentResult(){
                StatusCode = 401,
                ContentType = "ApiKey nao encontrada",
            };
            return;
        }

        if (!Configuration.API_KEY.Equals(extractedApiKey)){
            context.Result = new ContentResult(){
                StatusCode = 403,
                Content = "Acesso nao autorizado"
            };
            return;
        }
        
        await next();
    }
}