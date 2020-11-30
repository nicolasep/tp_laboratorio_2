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
        
        public bool AgregarProducto(T prod, U cantidad)
        {
            try
            {
                this.carritoDelCliente.Add(prod, cantidad);
            }
            catch(ProductoDuplicadoExcepcion ex)
            {
                return false;
            }
            return true;

        }
        public int IndiceProducto(T prod)
        {
            List<T> aux = this.RetornarProductos();

            for (int i=0; i<aux.Count;i++)
            {
                if(aux[i] == prod)
                {
                    return i;
                }
            }
            return 0;
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
