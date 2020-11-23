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
        Thread hiloListaProductos;
        List<Thread> listaHilos;
        public formPrincipal()
        {
            InitializeComponent();
            this.productos = new Productos();
            this.listaHilos = new List<Thread>();
            LimpiarMemoria += this.LimpiarDatos;
            LimpiarMemoria += this.ActualizarListaDeProductosDisponibles;
        }

        private void Principal_Load(object sender, EventArgs e)
        {
            this.hiloListaProductos = new Thread(this.ActualizarListaDeProductosDisponibles);
            this.hiloListaProductos.Start();
            
            
        }

        private void ProductoSeleccionado(object sender, DataGridViewCellEventArgs e)
        {

            
            
        }

        private void btnAceptarCliente_Click(object sender, EventArgs e)
        {
            try
            {
                string nombre = this.textNombre.Text.Trim();
                string apellido = this.textApellido.Text.Trim();
                string dni = this.textDni.Text.Trim();
                Cliente cliente = new Cliente(dni, nombre, apellido);
                if (this.rdbAlquiler.Checked)
                {
                    this.TipoOperacion = "Alquiler";
                    this.alquilar = new Alquilar(cliente);
                    if (cliente.IngresarCliente(cliente))
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
                    if (cliente.IngresarCliente(cliente))
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
            catch(Exception ex)
            {
                MessageBox.Show(string.Format("Ocurrio un error ", ex.Message));
            }
            
            
            
        }

        private void btnAgregarACarrito_Click(object sender, EventArgs e)
        {
            try
            {
                int cantidad;
                int.TryParse(this.textCantidad.Text, out cantidad);
                int id;
                int stock;
                int.TryParse(this.dataGProductosDisponibles.CurrentRow.Cells[0].Value.ToString(), out id);
                int.TryParse(this.dataGProductosDisponibles.CurrentRow.Cells[4].Value.ToString(), out stock);

                if (this.TipoOperacion == "Alquiler")
                {
                    if (cantidad != 0 && cantidad < stock)
                    {

                        alquilar.AgregarProducto(ProductosDAO.ListarProductosPorId(id), cantidad);
                        MessageBox.Show("Producto agragado con exito");
                        this.textCantidadEnCarrito.Text = alquilar.CantidadProductos.ToString();
                        this.textTotalAPagar.Text = this.alquilar.TotalAPagar.ToString();
                    }
                }
                else if (this.TipoOperacion == "Compra")
                {
                    if (cantidad != 0 && cantidad < stock)
                    {

                        compra.AgregarProducto(ProductosDAO.ListarProductosPorId(id), cantidad);
                        MessageBox.Show("Producto agragado con exito");
                        this.textCantidadEnCarrito.Text = compra.CantidadProductos.ToString();
                        this.textTotalAPagar.Text = this.compra.TotalAPagar.ToString();
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(string.Format("Ocurrio un error ",ex.Message));
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
                    this.BeginInvoke(delegadoHilo);
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
               // this.compra.ConcretarOperacion();
                
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
    }
}
