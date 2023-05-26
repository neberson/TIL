using Microsoft.EntityFrameworkCore;
using MinimalAPICatalogo.Context;
using MinimalAPICatalogo.Models;

namespace MinimalAPICatalogo.ApiEndpoints
{
    public static class CategoriasEndpoints
    {
        public static void MapCategoriasEndpoints(this WebApplication app)
        {
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

        }
    }
}
