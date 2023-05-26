using Microsoft.EntityFrameworkCore;
using MinimalAPICatalogo.Context;
using MinimalAPICatalogo.Models;

namespace MinimalAPICatalogo.ApiEndpoints
{
    public static class ProdutosEndpoints
    {
        public static void MapProdutosEndpoints(this WebApplication app) 
        {
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
        }
    }
}
