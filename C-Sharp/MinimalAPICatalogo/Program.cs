using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using MinimalAPICatalogo.Context;
using MinimalAPICatalogo.Models;
using MinimalAPICatalogo.Services;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var mysqlConnection = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<AppDbContext>(options => options.UseMySql(mysqlConnection, ServerVersion.AutoDetect(mysqlConnection)));

builder.Services.AddSingleton<ITokenService>(new TokenService());

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
        .AddJwtBearer(options =>
        {
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = builder.Configuration["Jwt:Issuer"],
                ValidAudience = builder.Configuration["Jwt:Audience"],
                IssuerSigningKey = new SymmetricSecurityKey
                (Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
            };
        });

builder.Services.AddAuthorization();

var app = builder.Build();

//endpoint para login
app.MapPost("/login", [AllowAnonymous](UserModel userModel, ITokenService tokenService) =>
{
    if (userModel == null)
    {
        return Results.BadRequest("Login Inválido");
    }
    if (userModel.UserName == "teste" && userModel.Password == "123")
    {
        var tokenString = tokenService.GerarToken(app.Configuration["Jwt:Key"],
            app.Configuration["Jwt:Issuer"],
            app.Configuration["Jwt:Audience"],
            userModel);
        return Results.Ok(new { token = tokenString });
    }
    else
    {
        return Results.BadRequest("Login Inválido");
    }
}).Produces(StatusCodes.Status400BadRequest)
           .Produces(StatusCodes.Status200OK)
           .WithName("Login")
           .WithTags("Autenticacao");

//Definição dos endpoints

app.MapGet("/", () => "Catalogo de Produtos 2023");

app.MapGet("/categorias", async (AppDbContext context) => await context.Categorias.ToListAsync());

app.MapGet("/categorias/{id:int}", async (int id, AppDbContext context) => {
   return await context.Categorias.FindAsync(id)
                       is Categoria categoria
                       ? Results.Ok(categoria)
                       : Results.NotFound();
});

app.MapPost("/categorias", async (Categoria categoria, AppDbContext context) => {
    context.Categorias.Add(categoria);
    await context.SaveChangesAsync();

    return Results.Created($"/categorias/{categoria.CategoriaId}", categoria);
});

app.MapPut("/categorias/{id:int}", async (int id, Categoria categoria, AppDbContext context) => 
{ 
    if (categoria.CategoriaId != id)
    {
        return Results.BadRequest();
    }

    context.Update(categoria);
    await context.SaveChangesAsync();

    return Results.Ok();
});

app.MapDelete("/categorias/{id:int}", async (int id, AppDbContext context) => {
    var categoria = await context.Categorias.FindAsync(id);

    if (categoria is null)
    {
        return Results.NotFound();
    }

    context.Categorias.Remove(categoria);
    await context.SaveChangesAsync();

    return Results.NoContent();
});

app.MapGet("/produtos", async (AppDbContext context) => {
    return await context.Produtos.ToListAsync();
}).RequireAuthorization();

app.MapGet("/produtos/{id:int}", async (int id, AppDbContext context) => 
{
    return await context.Produtos.FindAsync(id)
           is Produto produto 
           ? Results.Ok(produto) 
           : Results.NotFound();
});

app.MapPost("/produtos", async (Produto produto, AppDbContext context) => 
{
    context.Produtos.Add(produto);
    await context.SaveChangesAsync();

    return Results.Created($"/produtos/{produto.ProdutoId}", produto);
});

app.MapPut("/produtos", async (Produto produto, AppDbContext context) => 
{

    if (produto == null) return Results.BadRequest();

    var produtoDb = await context.Produtos.AsNoTracking().FirstOrDefaultAsync(p => p.ProdutoId == produto.ProdutoId);

    if (produtoDb == null) return Results.BadRequest();

    context.Update(produto);
    await context.SaveChangesAsync();

    return Results.Ok();
});

app.MapDelete("/produtos/{id:int}", async (int id, AppDbContext context) => {

    var produto = await context.Produtos.AsNoTracking().FirstOrDefaultAsync(p => p.ProdutoId == id);

    if (produto is null)
    {
        return Results.NotFound();
    }

    context.Produtos.Remove(produto);
    await context.SaveChangesAsync();

    return Results.NoContent();
});

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.Run();