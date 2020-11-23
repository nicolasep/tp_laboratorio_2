using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Producto
    {
        private int id;
        private string nombre;
        private string marca;
        private float precio;
        private int stock;

        /// <summary>
        /// constructor de producto sin id definido, es para cargar el producto manual
        /// </summary>
        /// <param name="nombre">nombre del producto</param>
        /// <param name="marca">marca del producto</param>
        /// <param name="precio">precio del producto</param>
        /// <param name="stock">stock del producto</param>
        public Producto(string nombre, string marca, float precio,int stock)
            :this(0,nombre,marca,precio,stock)
        {
           
            
        }
        /// <summary>
        /// constructor completo del producto, se usa para cargar los datos desde la base
        /// </summary>
        /// <param name="id">id del producto</param>
        /// <param name="nombre">nombre del producto</param>
        /// <param name="marca">marca del producto</param>
        /// <param name="precio">precio del producto</param>
        /// <param name="stock">stock del producto</param>
        public Producto(int id,string nombre, string marca, float precio, int stock)
        {
            this.Id = id;
            this.Nombre = nombre;
            this.Marca = marca;
            this.precio = precio;
            this.Stock = stock;
        }
        /// <summary>
        /// asigna y retorna el id
        /// </summary>
        public int Id
        {
            get
            {
                return this.id;
            }
            set
            {
                this.id = value;
            }
        }
        /// <summary>
        /// asigna y retorna el nombre del producto
        /// </summary>
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
        /// <summary>
        /// asigna y retorna la marca del producto
        /// </summary>
        public string Marca
        {
            get
            {
                return this.marca;
            }
            set
            {
                this.marca = value;
            }
        }
        /// <summary>
        /// asigna y retorna el precio del producto
        /// </summary>
        public float Precio
        {
            get
            {
                return this.precio;
            }
            set
            {
                this.precio = value;
            }
        }
        /// <summary>
        /// asigna y retorna el stock del producto
        /// </summary>
        public int Stock
        {
            get
            {
                return this.stock;
            }
            set
            {
                this.stock = value;
            }
        }
        /// <summary>
        /// dos productos son iguales si coinciden en nombre y marca
        /// </summary>
        /// <param name="p1">producto a comparar</param>
        /// <param name="p2"></producto a compararparam>
        /// <returns>devuelve true si son iguales, false si no los son</returns>
        public static bool operator ==(Producto p1, Producto p2)
        {
            return (p1.Nombre == p2.Nombre && p1.Marca == p2.Marca);
        }
        /// <summary>
        /// dos productos son distinto si su nombre o marca son distintos
        /// </summary>
        /// <param name="p1">producto a comparar</param>
        /// <param name="p2">producto a comparar</param>
        /// <returns>devuelve true si son distintos, false si son iguales</returns>
        public static bool operator !=(Producto p1, Producto p2)
        {
            return !(p1 == p2);
        }
        /// <summary>
        /// muestra los datos del producto
        /// </summary>
        /// <param name="mostrarStock">condicion para mostrar stock o no</param>
        /// <returns>devuelve un string con los datos del producto</returns>
        public string MostrarProducto(bool mostrarStock)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"{this.Id}----{this.Nombre}----{this.Marca}----{this.Precio}");
            if (mostrarStock)
            {
                sb.Append($"Stock: {this.Stock}");
            }
            

            return sb.ToString();
        }
        /// <summary>
        /// hace publicos los datos del producto
        /// </summary>
        /// <returns>devuelve un string con los datos del producto</returns>
        public override string ToString()
        {
            return this.MostrarProducto(false);
        }
        /// <summary>
        /// sobrecarga que compara el objeto de entrada y evalua si es del mismo tipo
        /// </summary>
        /// <param name="obj">objeto a evaluar</param>
        /// <returns>devuelve true si el objeto es un producto, false si no lo es</returns>
        public override bool Equals(object obj)
        {
            return obj is Producto;
        }
    }
}
