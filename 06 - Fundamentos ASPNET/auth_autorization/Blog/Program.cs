using System.Text;
using Blog;
using Blog.Data;
using Blog.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

var key = Encoding.ASCII.GetBytes(Configuration.JWTKEY);
builder.Services.AddAuthentication(options => {
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(x => {
    x.TokenValidationParameters = new TokenValidationParameters{
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(key),
        ValidateIssuer = false,
        ValidateAudience = false
    };
});

builder
    .Services
    .AddControllers()
    .ConfigureApiBehaviorOptions(options =>
    {
        options.SuppressModelStateInvalidFilter = true;
    });

//Servico DataContext
builder.Services.AddDbContext<BlogDataContext>();
builder.Services.AddTransient<TokenService>();

//Tipos de Injeções de Dependencias (SERVICOS)
//builder.Services.AddTransient(); // Sempre Cria uma nova Instancia
//builder.Services.AddScoped(); // A cada requisicao gera uma nova Instancia
//builder.Services.AddSingleton();// Gera somente um na memoria e utiliza somente ele (CASO REINICIE A APLICACAO ELE GERA UM NOVO)

var app = builder.Build();

app.UseAuthentication();//Authentication sempre antes
app.UseAuthorization();

app.MapControllers();

app.Run();