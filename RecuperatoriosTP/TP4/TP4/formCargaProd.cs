using Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TP4
{
    public partial class formCargaProd : Form
    {
        private Productos aux;
       
        
        public formCargaProd(Productos prod)
        {
            InitializeComponent();
           
            this.aux = prod;
           
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string nombre = this.txtNombreProd.Text;
            string marca = this.txtMarcaProd.Text;
            float precio = 0.0f;
            int stock = 0;

            if (!string.IsNullOrWhiteSpace(nombre) && !string.IsNullOrWhiteSpace(marca) &&
                float.TryParse(this.txtPrecioProd.Text, out precio) && int.TryParse(this.txtStockProd.Text, out stock))
            {
                Producto producto = new Producto(nombre, marca, precio, stock);
                this.aux += producto;
                MessageBox.Show("PRODUCTO INGRESADO CON EXITO");
                this.DialogResult = DialogResult.OK;
                
                
                this.Close();
            }
            else
            {
                MessageBox.Show("ALGUNO DE LOS DATOS NO FUE INGRESADO O ES INCORRECTO, VUELVA A INTENTARLO");
            }
                

            
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
