using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class CarritoCompras<T,U>
        where T:Producto
        ////////LISTA GENERICA
        
    {
        private Dictionary<T,U> carritoDelCliente;
       
        private string nombre;

        public CarritoCompras()
        {
            
            this.carritoDelCliente = new Dictionary<T, U>();
            
        }
        
        public int CantidadCompras
        {
            get
            {
                return this.carritoDelCliente.Count;
            }
        }
        public string Nombre
        {
            get
            {
                return this.nombre;
            }
            set
            {
                this.nombre = value;
            }
        }
        
        public void AgregarProducto(T prod, U cantidad)
        {
            try
            {
                this.carritoDelCliente.Add(prod, cantidad);
            }
            catch(Exception ex)
            {
                throw new ProductoDuplicadoExcepcion(ex.Message);
            }
            

        }
        public List<T> RetornarProductos()
        {
            List<T> aux =this.carritoDelCliente.Select(kvp => kvp.Key).ToList();

            return aux;
        }
        public List<U> RetornarCantidad()
        {
            List<U> aux = this.carritoDelCliente.Select(kvp =>kvp.Value).ToList();


            return aux;
        }
        public int CantidadDeProductos()
        {
            return this.carritoDelCliente.Count();
        }
        
    }
}
