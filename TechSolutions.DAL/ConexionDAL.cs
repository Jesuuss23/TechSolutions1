
using Microsoft.Data.SqlClient;
using System.Configuration;

namespace TechSolutions.DAL
{

    public class ConexionDAL
    {

        private static readonly ConexionDAL _instancia = new ConexionDAL();

        private readonly string _cadenaConexion;

        private ConexionDAL()
        {
            _cadenaConexion = ConfigurationManager.ConnectionStrings["TechSolutionsConnection"].ConnectionString;
        }

        public static ConexionDAL Instancia
        {
            get { return _instancia; }
        }

        public SqlConnection GetConexion()
        {
            return new SqlConnection(_cadenaConexion);
        }
    }
}