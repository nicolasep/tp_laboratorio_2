using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;

namespace TP4
{
    public partial class formPrincipal : Form
    {
        public delegate void DelegadoHiloPrincipal();
        public delegate void Limpiar();
        

        public event Limpiar LimpiarMemoria;
       
        private Productos productos;
        private Alquilar alquilar;
        private Compra compra;
        private string TipoOperacion;
        private Clientes clientes;
        private Thread hiloListaProductos;
        private List<Thread> listaHilos;
        public formPrincipal()
        {
            InitializeComponent();
            
            this.productos = new Productos();
            this.listaHilos = new List<Thread>();
            this.clientes = new Clientes();
            this.AgregarProductosIniciales();
            LimpiarMemoria += this.LimpiarDatos;
            LimpiarMemoria += this.ActualizarListaDeProductosDisponibles;
        }

        private void Principal_Load(object sender, EventArgs e)
        {
            this.hiloListaProductos = new Thread(this.ActualizarListaDeProductosDisponibles);
            this.hiloListaProductos.Start();  
        }

        private void btnAceptarCliente_Click(object sender, EventArgs e)
        {
            try
            {
                string nombre = this.textNombre.Text.Trim();
                string apellido = this.textApellido.Text.Trim();
                string dni = this.textDni.Text.Trim();
                if(nombre.EsNombreOApellidoValido() && 
                    apellido.EsNombreOApellidoValido() &&
                    dni.EsDniValido())
                {
                    Cliente aux = new Cliente(dni, nombre, apellido);
                    Cliente cliente = this.clientes.AgregarCliente(aux);
                    if (this.rdbAlquiler.Checked)
                    {
                        this.TipoOperacion = "Alquiler";
                        this.alquilar = new Alquilar(cliente);
                        if (cliente != null)
                        {
                            MessageBox.Show("El cliente fue ingresado con exito");
                        }
                        else
                        {
                            MessageBox.Show("ERROR AL INGRESAR EL CLIENTE", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                    }
                    else if (this.rdbCompra.Checked)
                    {
                        this.TipoOperacion = "Compra";
                        this.compra = new Compra(cliente);
                        if (cliente != null)
                        {
                            MessageBox.Show("El cliente fue ingresado con exito");
                        }
                        else
                        {
                            MessageBox.Show("ERROR AL INGRESAR EL CLIENTE", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("DEBE SELECCIONAR TIPO DE OPERACION", "VERIFICAR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Alguno de los datos ingresados es incorrecto");
                    this.LimpiarDatos();
                }
                
            }
            catch(Exception ex)
            {
                MessageBox.Show(string.Format("Ocurrio un error en cliente {0}", ex.Message));
            }
            
            
            
        }

        private void btnAgregarACarrito_Click(object sender, EventArgs e)
        {
            try
            {
                if(this.alquilar != null || this.compra != null)
                {
                    if (this.productos.ListaProductos.Count > 0)
                    {
                        int cantidad;
                        int.TryParse(this.textCantidad.Text, out cantidad);
                        int id;
                        int stock;
                        int.TryParse(this.dataGProductosDisponibles.CurrentRow.Cells[0].Value.ToString(), out id);
                        int.TryParse(this.dataGProductosDisponibles.CurrentRow.Cells[4].Value.ToString(), out stock);

                        if (this.TipoOperacion == "Alquiler")
                        {
                            if (cantidad != 0 && cantidad <= stock)
                            {

                                alquilar.AgregarProducto(ProductosDAO.ListarProductosPorId(id), cantidad);
                                MessageBox.Show("Producto agragado con exito");
                                this.textCantidadEnCarrito.Text = alquilar.CantidadProductos.ToString();
                                this.textTotalAPagar.Text = this.alquilar.TotalAPagar.ToString();
                            }
                            else
                            {
                                MessageBox.Show("La cantidad solisitada no se encuentra en stock");
                            }
                        }
                        else if (this.TipoOperacion == "Compra")
                        {
                            if (cantidad != 0 && cantidad <= stock)
                            {

                                compra.AgregarProducto(ProductosDAO.ListarProductosPorId(id), cantidad);
                                MessageBox.Show("Producto agragado con exito");
                                this.textCantidadEnCarrito.Text = compra.CantidadProductos.ToString();
                                this.textTotalAPagar.Text = this.compra.TotalAPagar.ToString();
                            }
                            else
                            {
                                MessageBox.Show("La cantidad solisitada no se encuentra en stock");
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Primero debe cargar productos");
                    }
                }
                else
                {
                    MessageBox.Show("PRIMERO DEBE INGRESAR EL CLIENTE");
                }
                
                
            }
            catch(Exception ex)
            {
                MessageBox.Show(string.Format("Ocurrio un error {0}",ex.Message));
            }
            

        }
        public void ActualizarListaDeProductosDisponibles()
        {
            
            try
            {
                DataView view = new DataView(ProductosDAO.MostrarDatosEnTabla());
                if (this.dataGProductosDisponibles.InvokeRequired)
                {
                    DelegadoHiloPrincipal delegadoHilo = new DelegadoHiloPrincipal(this.ActualizarListaDeProductosDisponibles);
                    BeginInvoke(delegadoHilo);
                }
                else
                {
                    this.dataGProductosDisponibles.DataSource = view;
                    this.dataGProductosDisponibles.Update();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Ocurrio un error al actualizar la grilla de productos");
            }
            
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnConfirmarPedido_Click(object sender, EventArgs e)
        {
            if (this.TipoOperacion == "Alquiler")
            {
                
                Thread thread = new Thread(this.alquilar.ConcretarOperacion);
                thread.Start();
                this.listaHilos.Add(thread);
               
                DialogResult n = MessageBox.Show("Operacion Terminada decea ver al factura?", "Aviso", MessageBoxButtons.YesNo);
                if (n == DialogResult.Yes)
                {
                    formFactura formFactura = new formFactura(this.alquilar.Mostrar());
                    formFactura.ShowDialog();
                }

            }
            else if (this.TipoOperacion == "Compra")
            {
               
                Thread thread = new Thread(this.compra.ConcretarOperacion);
                thread.Start();
                this.listaHilos.Add(thread);
                DialogResult n = MessageBox.Show("Operacion Terminada decea ver al factura?", "Aviso", MessageBoxButtons.YesNo);
                if (n == DialogResult.Yes)
                {
                    formFactura formFactura = new formFactura(this.compra.Mostrar());
                    formFactura.ShowDialog();
                }
            }
            this.LimpiarMemoria.Invoke();
        }

        private void Principal_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(this.hiloListaProductos.IsAlive)
            {
                this.hiloListaProductos.Abort();
            }
            foreach(Thread thread in this.listaHilos)
            {
                if (thread.IsAlive)
                {
                    thread.Abort();
                }
            }
        }
        public void LimpiarDatos()
        {
            this.textApellido.Text = "";
            this.textNombre.Text = "";
            this.textDni.Text = "";
            this.textCantidad.Text = "";
            this.textCantidadEnCarrito.Text = "";
            this.textTotalAPagar.Text = "";
            this.alquilar = null;
            this.compra = null;
        }

        private void btnAgregarProducto_Click(object sender, EventArgs e)
        {

            Thread ventanaProd = new Thread(this.AgregarProducto);
            ventanaProd.Start();
            this.listaHilos.Add(ventanaProd);
            
        }
        private void AgregarProducto()
        {
            formCargaProd cargaProd = new formCargaProd(this.productos);
            DialogResult resultado = cargaProd.ShowDialog();
            if (resultado == DialogResult.OK)
            {
                this.ActualizarListaDeProductosDisponibles();
            }
        }
        private void AgregarProductosIniciales()
        {
            if(this.productos.ListaProductos.Count == 0)
            {
                Producto p1 = new Producto("AS01", "AGUAS", 20001, 50);
                Producto p2 = new Producto("AS02", "USHUAIA", 22300, 50);
                Producto p3 = new Producto("AS03", "BACOPE", 16700, 50);
                Producto p4 = new Producto("AS04", "TRIA", 18350, 50);
                Producto p5 = new Producto("AS05", "TERMOPLAST", 15600, 50);
                Producto p6 = new Producto("AS06", "AQUAWORD", 10350, 50);
                this.productos += p1;
                this.productos += p2;
                this.productos += p3;
                this.productos += p4;
                this.productos += p5;
                this.productos += p6;
            }
            
        }
    }
}
