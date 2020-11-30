using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Compra : ITipoOperacion<Compra,Cliente,Producto>
    {
        private CarritoCompras<Producto, int> carritoCompras;
        private Cliente aCliente;
        private Productos productosDisponibles;

        /// <summary>
        /// constructor de compra
        /// </summary>
        /// <param name="cliente">cliente quien va a realizar la compra</param>
        public Compra(Cliente cliente)
        {
            this.carritoCompras = new CarritoCompras<Producto, int>();
            this.ACliente = cliente;
            this.productosDisponibles = new Productos();

        }
        /// <summary>
        /// asigna y retorna el cliente
        /// </summary>
        public Cliente ACliente
        {
            get
            {
                return this.aCliente;
            }
            set
            {
                this.aCliente = value;
            }
        }
        /// <summary>
        /// retorna la cantidad de productos y cantidades
        /// </summary>
        public int CantidadProductos
        {
            get
            {
                return this.carritoCompras.CantidadDeProductos() * this.ListaDeProductos.Count;
            }
        }
        /// <summary>
        /// retorna la lista de productos del carrito
        /// </summary>
        public List<Producto> ListaDeProductos
        {
            get
            {
                return this.carritoCompras.RetornarProductos();
            }
        }
        /// <summary>
        /// retorna la lista de cantidades de cada producto
        /// </summary>
        private List<int> ListaCantidades
        {
            get
            {
                return this.carritoCompras.RetornarCantidad();
            }
        }
        /// <summary>
        /// calcula el precio a pagar con los articulos del carrito y lo devuelve
        /// </summary>
        public float TotalAPagar
        {
            get
            {

                float acumulador = 0.0f;
                int contador = 0;
                foreach (Producto p in this.ListaDeProductos)
                {
                    float subTotal = p.Precio * (float)this.ListaCantidades[contador];
                    acumulador += subTotal;

                    contador++;
                }
                return acumulador;
            }
        }
        /// <summary>
        /// agrega un producto al carrito de compras
        /// </summary>
        /// <param name="p">producto a agregar</param>
        /// <param name="cantidad">cantidades</param>
        public void AgregarProducto(Producto p, int cantidad)
        {
            foreach (Producto producto in this.productosDisponibles.ListaProductos)
            {
                if (producto == p)
                {
                    this.carritoCompras.AgregarProducto(producto, cantidad);
                }
            }

        }
        /// <summary>
        /// muestra los productos del cliente con sus precios
        /// </summary>
        /// <returns>devuelve un string con los datos del carrito del cliente</returns>
        public string Mostrar()
        {
            int contador = 0;
            float acumnulador = 0.0f;

            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Cliente: {this.ACliente}");
            sb.AppendLine("ID PRODUCTO   MARCA  PRECIO CANTIDAD SUBTOTAL");
            foreach (Producto p in this.ListaDeProductos)
            {
                float subtotal = (p.Precio / 12) * (float)this.ListaCantidades[contador];
                acumnulador += subtotal;
                sb.AppendLine($"{p.MostrarProducto(false)}    {ListaCantidades[contador]}    {subtotal}");
                contador++;
            }
            sb.AppendLine($"Total a pagar: {acumnulador}");
            

            return sb.ToString();
        }
        /// <summary>
        /// finaliza la compra de los producto, descuenta del stock de la base
        /// </summary>
        public void ConcretarOperacion()
        {
            try
            {
                float acumulador = 0.0f;
                for (int i = 0; i < this.ListaDeProductos.Count; i++)
                {
                    acumulador += (this.ListaDeProductos[i].Precio * this.ListaCantidades[i]);
                    this.productosDisponibles.SalidaStock(this.ListaDeProductos[i], this.ListaCantidades[i]);
                    MovimientosDAO.Insertar("Compra", this.ACliente, this.ListaDeProductos[i], this.ListaCantidades[i], acumulador);
                    Facturacion.GuardarFactura(this.Mostrar());
                }
            }
            catch (CantidadNoDisponibleExcepcion ex)
            {
                throw new CantidadNoDisponibleExcepcion(ex.Message);
            }

        }
        /// <summary>
        /// recupera de la base de datos la lista de movimientos
        /// </summary>
        /// <returns>devuelve una lista de string de moviemientos</returns>
        public List<string> Movimientos()
        {
            List<string> retorno = MovimientosDAO.RecuperarDatos();
            return retorno;
        }

    }
}
