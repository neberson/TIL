using Dapper.Contrib.Extensions;
using ApiTarefasComDapper.Data;
using static ApiTarefasComDapper.Data.TarefaContext;

namespace ApiTarefasComDapper.Endpoints
{
    public static class TarefasEndpoints
    {
        public static void MapTarefasEndpoints(this WebApplication app)
        {
            app.MapGet("/", () => $"Bem vindo a API Tarefas - {DateTime.Now}");

            app.MapGet("/Tarefas", async(GetConnection connectionGetter) => {
                using var con = await connectionGetter();
                var tarefas = con.GetAll<Tarefa>().ToList();

                if (tarefas is null) 
                    return Results.NotFound();

                return Results.Ok(tarefas);
            });

            app.MapGet("/Tarefas/{id}", async (GetConnection connectionGetter, int id) => {
                using var con = await connectionGetter();

                return con.Get<Tarefa>(id) is Tarefa tarefa ? Results.Ok(tarefa) : Results.NotFound();
            });

            app.MapPost("/Tarefas", async (GetConnection connectionGetter, Tarefa tarefa) =>
            {
                using var con = await connectionGetter();
                var id = con.Insert(tarefa);
                return Results.Created($"/Tarefas/{id}", tarefa);
            });

            app.MapPut("/Tarefas", async (GetConnection connectionGetter, Tarefa tarefa) =>
            {
                using var con = await connectionGetter();
                var id = con.Update(tarefa);
                return Results.Created($"/Tarefas/{id}", tarefa);
            });

            app.MapDelete("/tarefas/{id}", async (GetConnection connectionGetter, int id) => 
            { 
                using var con = await connectionGetter();

                var deleted = con.Get<Tarefa>(id);

                if(deleted is null)
                    return Results.NotFound();

                con.Delete(deleted);

                return Results.Ok(deleted);
            });
        }
    }
}
