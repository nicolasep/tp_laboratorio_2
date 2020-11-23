using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public static class ClientesDAO
    {
        private static SqlConnection sqlConnection;

        /// <summary>
        /// constructor estatico se encarga de generar la coneccion
        /// </summary>
        static ClientesDAO()
        {
            string connectionString = "Server=.;Database=Comercio;Trusted_Connection=True;";
            sqlConnection = new SqlConnection(connectionString);
        }
        /// <summary>
        /// abre la conexion con la base de datos para realizar modificaciones
        /// </summary>
        private static void AbrirConexion()
        {
            if (sqlConnection.State != System.Data.ConnectionState.Open)
            {
                sqlConnection.Open();//abre la coneccion
            }
        }
        /// <summary>
        /// realiza el cierre de la conexion con la base de datos
        /// </summary>
        private static void CerrarConexion()
        {
            if (sqlConnection != null && sqlConnection.State == System.Data.ConnectionState.Open)
            {
                sqlConnection.Close();
            }
        }
        /// <summary>
        /// elimina un cliente de la base de datos
        /// </summary>
        /// <param name="cliente">cliente a eliminar</param>
        public static void Eliminar(Cliente cliente)
        {
            try
            {
                string command = "DELETE FROM Cliente WHERE id=" + cliente.Id;

                SqlCommand sqlCommand = new SqlCommand(command, sqlConnection);


                AbrirConexion();

                sqlCommand.ExecuteNonQuery();
            }
            catch(Exception ex)
            {
                throw new ErrorEnBDExcepcion(ex.Message);
            }
            finally
            {
                
                CerrarConexion();

            }
        }
        /// <summary>
        /// inserta un nuevo cliente en la base de datos
        /// </summary>
        /// <param name="cliente">cliente a instertar</param>
        /// <returns>devuelve true si lo pudo instertarm, false si no</returns>
        public static bool Insertar(Cliente cliente)
        {
            try
            {
                string command = "INSERT INTO Cliente(nombre,apellido, dni) VALUES(@nombre,@apellido, @dni)";

                SqlCommand sqlCommand = new SqlCommand(command, sqlConnection);

                sqlCommand.Parameters.AddWithValue("nombre", cliente.Nombre);
                sqlCommand.Parameters.AddWithValue("apellido", cliente.Apellido);
                sqlCommand.Parameters.AddWithValue("dni", cliente.Dni);
                

                AbrirConexion();
                sqlCommand.ExecuteNonQuery();
                return true;
            }
            catch(Exception ex)
            {
                throw new ErrorEnBDExcepcion(ex.Message);
            }
            finally
            {
                CerrarConexion();
            }
        }
        /// <summary>
        /// busca el cliente cargado y retorna el id
        /// </summary>
        /// <param name="cliente">cliente a buscar</param>
        /// <returns>devuelve el id del cliente</returns>
        public static int RetornarIdCliente(Cliente cliente)
        {
            try
            {
                string command = "SELECT * FROM Cliente WHERE nombre="+cliente.Nombre ;
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand(command, sqlConnection);

                SqlDataReader reader = sqlCommand.ExecuteReader();

               // sqlCommand.Parameters.AddWithValue("nombre", cliente.Nombre);
                //sqlCommand.Parameters.AddWithValue("apellido", cliente.Apellido);
                AbrirConexion();
                
                int id=0;
                while (reader.Read())
                {
                    id = (int)reader["id"];
                   
                }

                return id;
            }
            catch (Exception ex)
            {
                throw new ErrorEnBDExcepcion(ex.Message);
            }
            finally
            {
                CerrarConexion();
            }
        }
    }
}
