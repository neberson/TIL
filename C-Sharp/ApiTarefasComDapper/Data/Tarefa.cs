﻿using System.ComponentModel.DataAnnotations.Schema;

namespace ApiTarefasComDapper.Data
{
    [Table("Tarefas")]
    public record Tarefa(int Id, string Atividade, string status);
}
