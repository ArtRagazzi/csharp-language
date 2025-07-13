using BlogCrudEF.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers().ConfigureApiBehaviorOptions(options => {
    options.SuppressModelStateInvalidFilter = true;
});//Desabilita o retorno padrao do ASPNET de Validation

builder.Services.AddDbContext<BlogDataContext>();


var app = builder.Build();
app.MapControllers();

app.Run();
