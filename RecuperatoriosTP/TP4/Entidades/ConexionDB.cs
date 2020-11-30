using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public static class ConexionDB
    {
        private static SqlConnection sqlConnection;

        /// <summary>
        /// constructor estatico se encarga de generar la conexion
        /// </summary>
        static ConexionDB()
        {
            string connectionString = "Server=.;Database=Comercio;Trusted_Connection=True;";
            sqlConnection = new SqlConnection(connectionString);
        }
        public static SqlConnection SqlConnection
        {
            get
            {
                return sqlConnection;
            }
        }
        /// <summary>
        /// abre la conexion con la base de datos para realizar modificaciones
        /// </summary>
        public static void AbrirConexion()
        {
            if (sqlConnection.State != System.Data.ConnectionState.Open)
            {
                sqlConnection.Open();
            }
        }
        /// <summary>
        /// realiza el cierre de la conexion con la base de datos
        /// </summary>
        public static void CerrarConexion()
        {
            if (sqlConnection != null && sqlConnection.State == System.Data.ConnectionState.Open)
            {
                sqlConnection.Close();
            }
        }

    }
}
