using System.Configuration;
using System.Data.SqlClient;

namespace ProyectoGrupo4.Modelos.DAO
{
    public class Conexion
    {
        protected SqlConnection MiConexion = new SqlConnection(ConfigurationManager.ConnectionStrings["AerolineaConexion"].ConnectionString);
    }
}