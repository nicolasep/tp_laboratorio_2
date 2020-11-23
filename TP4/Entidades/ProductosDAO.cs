using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public static class ProductosDAO 
    {
        private static SqlConnection sqlConnection;

        /// <summary>
        /// constructos statico que inicializa la conexion con la BD
        /// </summary>
        static ProductosDAO()
        {
            string connectionString = "Server=.;Database=Comercio;Trusted_Connection=True;";
            sqlConnection = new SqlConnection(connectionString);
        }
        /// <summary>
        /// abre la conexion con la DB
        /// </summary>
        private static void AbrirConexion()
        {
            if (sqlConnection.State != System.Data.ConnectionState.Open)
            {
                sqlConnection.Open();//abre la coneccion
            }
        }
        /// <summary>
        /// cierra la conexion con la DB
        /// </summary>
        private static void CerrarConexion()
        {
            if (sqlConnection != null && sqlConnection.State == System.Data.ConnectionState.Open)
            {
                sqlConnection.Close();
            }
        }
        /// <summary>
        /// elimina un producto de la base de datos
        /// </summary>
        /// <param name="producto">producto a eliminar</param>
        public static void Eliminar(Producto producto)
        {
            try
            {
                string command = "DELETE FROM Producto WHERE id=" + producto.Id;

                SqlCommand sqlCommand = new SqlCommand(command,sqlConnection);


                AbrirConexion();
                
                sqlCommand.ExecuteNonQuery();
            }
            catch(Exception ex)
            {
                throw new ProducInexistenteExcepcion();
            }
            finally
            {
               
                CerrarConexion();

            }
        }
        /// <summary>
        /// inserta un nuevo producto en la BD
        /// </summary>
        /// <param name="producto">producto a insertar</param>
        public static void Insertar(Producto producto)
        {
            try
            {
                string command = "INSERT INTO Producto(nombre,marca, precio,stock) VALUES(@nombre,@marca, @precio,@stock)";

                SqlCommand sqlCommand = new SqlCommand(command,sqlConnection);
                
                sqlCommand.Parameters.AddWithValue("nombre", producto.Nombre);
                sqlCommand.Parameters.AddWithValue("marca", producto.Marca);
                sqlCommand.Parameters.AddWithValue("precio", producto.Precio);
                sqlCommand.Parameters.AddWithValue("stock", producto.Stock);

                AbrirConexion();
                sqlCommand.ExecuteNonQuery();
            }
            catch(Exception ex)
            {
                throw new ProductoDuplicadoExcepcion();
            }
            finally
            {
                CerrarConexion();
            }
        }
        /// <summary>
        /// modifica un producto en la BD
        /// </summary>
        /// <param name="producto">producto modificado</param>
        public static void Modificar(Producto producto)
        {
            try
            {
                string command = "UPDATE Producto SET nombre = @nombre, precio = @precio, stock = @stock WHERE id = @id";

                SqlCommand sqlCommand = new SqlCommand(command,sqlConnection);

                sqlCommand.Parameters.AddWithValue("id", producto.Id);
                sqlCommand.Parameters.AddWithValue("nombre", producto.Nombre);
                sqlCommand.Parameters.AddWithValue("marca", producto.Marca);
                sqlCommand.Parameters.AddWithValue("precio", producto.Precio);
                sqlCommand.Parameters.AddWithValue("stock", producto.Stock);

                AbrirConexion();
                sqlCommand.ExecuteNonQuery();
            }
            catch(Exception ex)
            {
                throw new ProducInexistenteExcepcion();
            }
            finally
            {
                CerrarConexion();
            }
        }
        /// <summary>
        /// descuenta el stock de un producto
        /// </summary>
        /// <param name="producto">producto a manipular</param>
        /// <param name="cantidad">cantidad a descontar</param>
        public static void DescontarDeStock(Producto producto,int cantidad)
        {

            try
            {
                if(producto.Stock > cantidad)
                {
                    string command = "UPDATE Producto SET stock = @stock WHERE id = @id";

                    SqlCommand sqlCommand = new SqlCommand(command, sqlConnection);


                    sqlCommand.Parameters.AddWithValue("id", producto.Id);

                    sqlCommand.Parameters.AddWithValue("stock", (producto.Stock - cantidad));

                    AbrirConexion();
                    sqlCommand.ExecuteNonQuery();
                }
                
                else
                {
                    throw new CantidadNoDisponibleExcepcion();
                }
               
            }
            catch(CantidadNoDisponibleExcepcion ex)
            {
                throw new CantidadNoDisponibleExcepcion();
            }


            finally
            {
                CerrarConexion();
            }
        }
        /// <summary>
        /// agrega stock de un producto
        /// </summary>
        /// <param name="producto">producto a manipular</param>
        /// <param name="cantidad">cantidad a agregar</param>
        public static void AgregarStock(Producto producto, int cantidad)
        {
            try
            {
                if(producto.Stock > cantidad)
                {
                    string command = "UPDATE Producto SET stock = @stock WHERE id = @id";

                    SqlCommand sqlCommand = new SqlCommand(command, sqlConnection);


                    sqlCommand.Parameters.AddWithValue("id", producto.Id);

                    sqlCommand.Parameters.AddWithValue("stock", (producto.Stock + cantidad));

                    AbrirConexion();
                    sqlCommand.ExecuteNonQuery();
                }
                else
                {
                    throw new CantidadNoDisponibleExcepcion("No hay stock suficiente");
                }
                
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
        /// recupera los datos de la BD
        /// </summary>
        /// <returns>decvuelve una lista de productos</returns>
        public static List<Producto> RecuperarDatos()
        {
            try
            {
                string command = "SELECT * FROM Producto";
                AbrirConexion();
                SqlCommand sqlCommand = new SqlCommand(command, sqlConnection);
                SqlDataReader reader = sqlCommand.ExecuteReader();

                List<Producto> productos = new List<Producto>();
                

                while (reader.Read())
                {
                    int id = (int)reader["id"];
                    string nombre = (string)reader["nombre"];
                    string marca = (string)reader["marca"];
                    int stock = (int)reader["stock"];
                    float precio = (float)((double)reader["precio"]);

                    Producto producto = new Producto(id,nombre,marca, precio, stock);
                    productos.Add(producto);

                }

                return productos;

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
        /// busca un producto por el id pasado por parametro
        /// </summary>
        /// <param name="idProducto">is a buscar</param>
        /// <returns>devuelve el producto buscado</returns>
        public static Producto ListarProductosPorId(int idProducto)
        {
            try
            {
                string command = "SELECT * FROM Producto WHERE id=" + idProducto;
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand(command, sqlConnection);
                
                SqlDataReader reader = sqlCommand.ExecuteReader();

                Producto producto = null;
                AbrirConexion();
                while (reader.Read())
                {
                    int id = (int)reader["id"];
                    string nombre = (string)reader["nombre"];
                    string marca = (string)reader["marca"];
                    int stock = (int)reader["stock"];
                    float precio = (float)((double)reader["precio"]);

                    producto = new Producto(id, nombre, marca, precio, stock);

                }
                
                return producto;
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
        /// verifica si un producto se encuentra en la BD
        /// </summary>
        /// <param name="producto">producto a buscar en la BD</param>
        /// <returns>devuelve true si existe, false si no</returns>
        public static bool BuscarProductos(Producto producto)
        {
            try
            {
                string a1 = producto.Nombre;

                string command ="SELECT * FROM Producto WHERE nombre=@nombre and marca=@marca";
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand(command, sqlConnection);
                sqlCommand.Parameters.AddWithValue("nombre", producto.Nombre);
                sqlCommand.Parameters.AddWithValue("marca", producto.Marca);
                AbrirConexion();
                SqlDataReader reader = sqlCommand.ExecuteReader();

                
                while (reader.Read())
                {
                    return true;

                }

                return false;
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
        /// muestra todos los datos en forma de tabla
        /// </summary>
        /// <returns>retorna una tabla con los datos</returns>
        public static DataTable MostrarDatosEnTabla()
        {
            try
            {
                string command = "SELECT * FROM Producto";
                AbrirConexion();
                SqlCommand sqlCommand = new SqlCommand(command, sqlConnection);
                SqlDataReader reader = sqlCommand.ExecuteReader();
                DataTable dataTable = new DataTable();
                dataTable.Load(reader);
               

                return dataTable;

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
    }
}
