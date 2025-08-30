using Catalog.API.Data;
using Catalog.API.Repositories;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
ConfigurationDI(builder);

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();
app.MapControllers();
app.Run();


void ConfigurationDI(WebApplicationBuilder builder)
{
    builder.Services.AddScoped<ICatalogContext, CatalogContext>();
    builder.Services.AddScoped<IProductRepository, ProductRepository>();

    builder.Services.AddControllers();
}