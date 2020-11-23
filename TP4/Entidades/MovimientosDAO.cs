using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public static class MovimientosDAO
    {
        private static SqlConnection sqlConnection;

        static MovimientosDAO()
        {
            string connectionString = "Server=.;Database=Comercio;Trusted_Connection=True;";
            sqlConnection = new SqlConnection(connectionString);
        }

        private static void AbrirConexion()
        {
            if (sqlConnection.State != System.Data.ConnectionState.Open)
            {
                sqlConnection.Open();//abre la coneccion
            }
        }
        private static void CerrarConexion()
        {
            if (sqlConnection != null && sqlConnection.State == System.Data.ConnectionState.Open)
            {
                sqlConnection.Close();
            }
        }

        /// <summary>
        /// insterta un nuevo registro de movimiento en la BD
        /// </summary>
        /// <param name="tipoOperacion">tipo de operacion realizada(venta o alquiler)</param>
        /// <param name="cliente">cliente que realizo la compra</param>
        /// <param name="producto">producto comprado</param>
        /// <param name="cantidad">cantidad del producto</param>
        /// <param name="totalPago">total abonado</param>
        public static void Insertar(string tipoOperacion,Cliente cliente,Producto producto,int cantidad, float totalPago)
        {
            try
            {
                string command = "INSERT INTO Movimiento(comprador,producto,cantidad, totalPago,fecha,operacion) VALUES(@comprador,@producto,@cantidad, @totalPago,@fecha,@operacion)";

                SqlCommand sqlCommand = new SqlCommand(command, sqlConnection);

                sqlCommand.Parameters.AddWithValue("comprador", cliente.Dni);
                sqlCommand.Parameters.AddWithValue("producto", producto.Nombre);
                sqlCommand.Parameters.AddWithValue("cantidad", cantidad);
                sqlCommand.Parameters.AddWithValue("totalPago", totalPago);
                sqlCommand.Parameters.AddWithValue("fecha", DateTime.Today);
                sqlCommand.Parameters.AddWithValue("operacion", tipoOperacion);
                

                AbrirConexion();
                sqlCommand.ExecuteNonQuery();
            }
            finally
            {
                CerrarConexion();
            }
        }

        /// <summary>
        /// buscar los datos de la tabla y los devuelve
        /// </summary>
        /// <returns>devuelve una lista de string con los movimientos</returns>
        public static List<string> RecuperarDatos()
        {
            try
            {
                string command = "SELECT * FROM Movimiento";
                AbrirConexion();
                SqlCommand sqlCommand = new SqlCommand(command, sqlConnection);
                SqlDataReader reader = sqlCommand.ExecuteReader();

                List<string> listaMovimientos = new List<string>();
                StringBuilder movimiento;


                while (reader.Read())
                {
                    movimiento = new StringBuilder();
                    movimiento.Append($"{(int)reader["id"]} {(string)reader["comprador"]} {(int)reader["cantidad"]} {(float)((double)reader["totalPago"])} {((DateTime)reader["fecha"]).ToString("yyyy/MM/dd")} {(string)reader["operacion"]}");

                    listaMovimientos.Add(movimiento.ToString());

                }

                return listaMovimientos;

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
