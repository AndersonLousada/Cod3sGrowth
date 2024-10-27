using LinqToDB;
using LinqToDB.Data;
using System.Configuration;

namespace Cod3rsGrowth.INFRA.Repositorio
{
    public class RepositorioBase
    {
        internal DataConnection Conexao()
        {
            string constring = ConfigurationManager.ConnectionStrings["CONNECTION_STRING"].ConnectionString;

            return new DataConnection(new DataOptions().UseSqlServer(constring));
        }
    }
}