using System.Data;

namespace ApiTarefasComDapper.Data
{
    public class TarefaContext
    {
        public delegate Task<IDbConnection> GetConnection();
    }
}
