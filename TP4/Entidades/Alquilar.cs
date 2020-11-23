using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Entidades 
{

    public delegate void Operacion();
    public class Alquilar : ITipoOperacion<Alquilar,Cliente,Producto>
    {
        

        public event Operacion OperacionTerminada;

        private CarritoCompras<Producto,int> carritoCompras;
        private Cliente aCliente;
        private Productos productosDisponibles;

        /// <summary>
        /// constructor de alquiler
        /// </summary>
        /// <param name="cliente">cliente que realiza el alquiler</param>
        public Alquilar(Cliente cliente)
        {
            this.carritoCompras = new CarritoCompras<Producto, int>();
            this.ACliente = cliente;
            this.productosDisponibles = new Productos();
            OperacionTerminada += this.GenerarFactura;

        }
        /// <summary>
        /// asigna y devuelve el cliente
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
        /// devuelve la cantidad total de productos iguales y distintos del cliente
        /// </summary>
        public int CantidadProductos
        {
            get
            {
                return this.carritoCompras.CantidadDeProductos()*this.ListaDeProductos.Count;
            }
        }
        /// <summary>
        /// devuelve la lista de productos del carrito
        /// </summary>
        public List<Producto> ListaDeProductos
        {
            get
            {
                return  this.carritoCompras.RetornarProductos();
            }
        }
        /// <summary>
        /// devuelve una lista con las cantidades de los productos
        /// </summary>
        private List<int> ListaCantidades
        {
            get
            {
                return this.carritoCompras.RetornarCantidad();
            }
        }
        /// <summary>
        /// devuelve el total a pagar por el cliente por mes
        /// </summary>
        public float TotalAPagar
        {
            get
            {
                
                float acumulador = 0.0f;
                int contador = 0;
                foreach (Producto p in this.ListaDeProductos)
                {
                    float subTotal = (p.Precio / 12) * (float)this.ListaCantidades[contador];
                    acumulador += subTotal;
                    
                    contador++;
                }
                return acumulador;
            }
        }
        /// <summary>
        /// agrega un prooducto al carrito de compras
        /// </summary>
        /// <param name="p">producto a agregar</param>
        /// <param name="cantidad">cantidad del producto</param>
        public void AgregarProducto(Producto p, int cantidad)
        {
            try
            {
                foreach (Producto producto in this.productosDisponibles.ListaProductos)
                {
                    if (producto == p)
                    {
                        this.carritoCompras.AgregarProducto(producto, cantidad);
                    }
                }
            }
            catch(CantidadNoDisponibleExcepcion ex)
            {
                throw new CantidadNoDisponibleExcepcion(ex.Message);
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
            sb.AppendLine("ID--PRODUCTO--MARCA--PRECIO--CANTIDAD--SUBTOTAL");
            foreach (Producto p in this.ListaDeProductos)
            {
                float subtotal = (p.Precio / 12) * (float)this.ListaCantidades[contador];
                acumnulador += subtotal;
                sb.AppendLine($"{p.MostrarProducto(false)}----{ListaCantidades[contador]}----{subtotal}");
                contador++;
            }
            sb.AppendLine($"Total a pagar por mes: {acumnulador}");

            

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
                    MovimientosDAO.Insertar("Alquiler", this.ACliente, this.ListaDeProductos[i], this.ListaCantidades[i], acumulador);
                    OperacionTerminada.Invoke();

                }
            }
            catch(CantidadNoDisponibleExcepcion ex)
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
        private void GenerarFactura()
        {
            Facturacion.GuardarFactura(this.Mostrar());
        }


    }
}
