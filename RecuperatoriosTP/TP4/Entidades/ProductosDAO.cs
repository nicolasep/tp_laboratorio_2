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
       
        /// <summary>
        /// constructos statico que inicializa la conexion con la BD
        /// </summary>
        static ProductosDAO()
        {
            
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

                SqlCommand sqlCommand = new SqlCommand(command, ConexionDB.SqlConnection);


                ConexionDB.AbrirConexion();
                
                sqlCommand.ExecuteNonQuery();
            }
            catch(Exception ex)
            {
                throw new ProducInexistenteExcepcion();
            }
            finally
            {

                ConexionDB.CerrarConexion();

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

                SqlCommand sqlCommand = new SqlCommand(command, ConexionDB.SqlConnection);
                
                sqlCommand.Parameters.AddWithValue("nombre", producto.Nombre);
                sqlCommand.Parameters.AddWithValue("marca", producto.Marca);
                sqlCommand.Parameters.AddWithValue("precio", producto.Precio);
                sqlCommand.Parameters.AddWithValue("stock", producto.Stock);

                ConexionDB.AbrirConexion();
                if(sqlCommand.ExecuteNonQuery()==0)
                {
                    throw new ProductoDuplicadoExcepcion();
                }
            }
            finally
            {
                ConexionDB.CerrarConexion();
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
                string command = "UPDATE Producto SET precio=@precio, stock=@stock WHERE nombre=@nombre and marca=@marca";

                
                SqlCommand sqlCommand = new SqlCommand(command, ConexionDB.SqlConnection);

                sqlCommand.Parameters.AddWithValue("id", producto.Id);
                sqlCommand.Parameters.AddWithValue("nombre", producto.Nombre);
                sqlCommand.Parameters.AddWithValue("marca", producto.Marca);
                sqlCommand.Parameters.AddWithValue("precio", producto.Precio);
                sqlCommand.Parameters.AddWithValue("stock", producto.Stock);

                ConexionDB.AbrirConexion();
                if(sqlCommand.ExecuteNonQuery()==0)
                {
                    throw new ErrorEnBDExcepcion();
                }

            }
            finally
            {
                ConexionDB.CerrarConexion();
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
                if(producto.Stock >= cantidad)
                {
                    string command = "UPDATE Producto SET stock = @stock WHERE id = @id";

                    SqlCommand sqlCommand = new SqlCommand(command, ConexionDB.SqlConnection);


                    sqlCommand.Parameters.AddWithValue("id", producto.Id);

                    sqlCommand.Parameters.AddWithValue("stock", (producto.Stock - cantidad));

                    ConexionDB.AbrirConexion();
                    sqlCommand.ExecuteNonQuery();
                }
                else
                {
                    throw new CantidadNoDisponibleExcepcion();
                }
               
            }
            finally
            {
                ConexionDB.CerrarConexion();
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
               
                string command = "UPDATE Producto SET stock = @stock WHERE id = @id";

                SqlCommand sqlCommand = new SqlCommand(command, ConexionDB.SqlConnection);


                sqlCommand.Parameters.AddWithValue("id", producto.Id);

                sqlCommand.Parameters.AddWithValue("stock", (producto.Stock + cantidad));

                ConexionDB.AbrirConexion();
                if(sqlCommand.ExecuteNonQuery()==0)
                {
                    throw new ProducInexistenteExcepcion("No existe el producto");
                }
                
            }
            finally
            {
                ConexionDB.CerrarConexion();
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
                ConexionDB.AbrirConexion();
                SqlCommand sqlCommand = new SqlCommand(command, ConexionDB.SqlConnection);
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
            finally
            {
                ConexionDB.CerrarConexion();
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
                SqlCommand sqlCommand = new SqlCommand(command, ConexionDB.SqlConnection);
                ConexionDB.AbrirConexion();
                SqlDataReader reader = sqlCommand.ExecuteReader();

                Producto producto = null;
                
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
            finally
            {
                ConexionDB.CerrarConexion();
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
                SqlCommand sqlCommand = new SqlCommand(command, ConexionDB.SqlConnection);
                sqlCommand.Parameters.AddWithValue("nombre", producto.Nombre);
                sqlCommand.Parameters.AddWithValue("marca", producto.Marca);
                ConexionDB.AbrirConexion();
                SqlDataReader reader = sqlCommand.ExecuteReader();

                
                while (reader.Read())
                {
                    return true;

                }

                return false;
            }
            finally
            {
                ConexionDB.CerrarConexion();
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
                ConexionDB.AbrirConexion();
                SqlCommand sqlCommand = new SqlCommand(command, ConexionDB.SqlConnection);
                SqlDataReader reader = sqlCommand.ExecuteReader();
                DataTable dataTable = new DataTable();
                dataTable.Load(reader);
               

                return dataTable;

            }
            finally
            {
                ConexionDB.CerrarConexion();
            }

        }
    }
}
