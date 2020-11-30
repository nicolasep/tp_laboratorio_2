using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    [Serializable]
    public class Productos
    {
        private List<Producto> listaProductos;

        /// <summary>
        /// constructor por defecto que inicializa la lista y carga los datos desde la base
        /// </summary>
        public Productos()
        {
            this.listaProductos = new List<Producto>();
            this.CargarDesdeBd();
        }
        /// <summary>
        /// propiedad que devuelve la lista de productos
        /// </summary>
        public List<Producto> ListaProductos
        {
            get
            {
                return this.listaProductos;
            }
        }
        /// <summary>
        /// busca un producto en BD por id y lo devuelve
        /// </summary>
        /// <param name="num">id del producto a buscar</param>
        /// <returns>devuelve el producto buscado</returns>
        public Producto BuscarEnBd(int num)
        {
            Producto aux = ProductosDAO.ListarProductosPorId(num);
            return aux;
        }
        /// <summary>
        /// carga la lista de productos desde la base de datos
        /// </summary>
        public void CargarDesdeBd()
        {
            this.listaProductos = ProductosDAO.RecuperarDatos();

        }
        /// <summary>
        /// guarda un producto en la base de datos
        /// </summary>
        /// <param name="datos">producto a guardar</param>
        /// <returns></returns>
        public bool GuardarEnBd(Producto datos)
        {
            if (!ProductosDAO.BuscarProductos(datos))
            {
                ProductosDAO.Insertar(datos);
                this.CargarDesdeBd();
                return true;
            }
            else
            {
                //throw new ProductoDuplicadoExcepcion();
            }
            return false;
        }
        /// <summary>
        /// descuenta la cantidad pasada por parametros del stock del producto
        /// </summary>
        /// <param name="producto">producto a descontarle stock</param>
        /// <param name="cantidad">cantidad a descontar</param>
        public bool SalidaStock(Producto producto,int cantidad)
        {
            try
            {
                ProductosDAO.DescontarDeStock(producto, cantidad);
                this.CargarDesdeBd();

            }
            catch(CantidadNoDisponibleExcepcion ex)
            {
                throw new CantidadNoDisponibleExcepcion();
            }
            return true;
        }
        /// <summary>
        /// aumenta el stock de un producto
        /// </summary>
        /// <param name="producto">producto a modificar</param>
        /// <param name="cantidad">cantidad a agregar</param>
        public void IngresoStock(Producto producto, int cantidad)
        {
            ProductosDAO.AgregarStock(producto, cantidad);
            this.CargarDesdeBd();

        }
        /// <summary>
        /// recorre la lista de producto y verifica si ya se encuantra cargado
        /// </summary>
        /// <param name="productos">producto a comparar</param>
        /// <param name="p">producto a comparar</param>
        /// <returns>devuelve true si se encuentra en la lista, false si no</returns>
        public static bool operator ==(Productos productos, Producto p)
        {
            foreach(Producto l in productos.listaProductos)
            {
                if(p==l)
                {
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// recorre la lista de producto y devuelve si el mismo no esta en la lista
        /// </summary>
        /// <param name="productos">producto a comparar</param>
        /// <param name="p">producto a comparar</param>
        /// <returns>devuelve true si no se encuentra en la lista, false si se encuentra</returns>
        public static bool operator !=(Productos productos, Producto p)
        {
            return !(productos == p);
        }
        /// <summary>
        /// publica los datos de los productos
        /// </summary>
        /// <returns>devuelve un string con los datos de los productos</returns>
        public string Mostrar()
        {
            StringBuilder sb = new StringBuilder();
            List<Producto> aux = new List<Producto>();
            aux = ProductosDAO.RecuperarDatos();
            sb.AppendLine("ID    NOMBRE    MARCA    PRECIO    STOCK");
            foreach(Producto p in aux)
            {
                sb.AppendLine(p.MostrarProducto(true));
            }
            return sb.ToString();
        }
        /// <summary>
        /// hace publicos los datos de los productos
        /// </summary>
        /// <returns>devuelve un string con los datos del producto</returns>
        public override string ToString()
        {
            return Mostrar();
        }
        /// <summary>
        /// agrega un producto a la lista si el mismo no se encuentra
        /// </summary>
        /// <param name="productos">lista de productos</param>
        /// <param name="p">producto a agregar</param>
        /// <returns>devuelve el objeto productos</returns>
        public static Productos operator +(Productos productos, Producto p)
        {
            try
            {
                if (productos == p)
                {
                    ProductosDAO.Modificar(p);
                }
                else
                {
                    productos.GuardarEnBd(p);
                }
                productos.CargarDesdeBd();
            }
            catch(ErrorEnBDExcepcion ex)
            {

            }
            
            return productos;
        }
        /// <summary>
        /// elimina un producto de los productos de la base de datos y actualiza la lista interna
        /// </summary>
        /// <param name="productos">productos a evaluar</param>
        /// <param name="p">producto a quitar</param>
        /// <returns>devuelve true si lo pudo eliminar, false si no existe</returns>
        public static bool operator -(Productos productos, Producto p)
        {
            try
            {
                ProductosDAO.Eliminar(p);
                productos.CargarDesdeBd();
                return true;
            }
            catch(ProducInexistenteExcepcion ex)
            {
                return false;
            }
           
        }

    }
}
