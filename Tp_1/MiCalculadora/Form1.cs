using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;

namespace MiCalculadora
{
    public partial class FormCalculadora : Form
    {
        public FormCalculadora()
        {
            InitializeComponent();
            cmbOperador.SelectedIndex = 0;
            
        }
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            FormCalculadora.ActiveForm.Close();
        }
        private void btnConvertirABinario_Click(object sender, EventArgs e)
        {
            string a;
            double b;
            double.TryParse(lblResultado.Text, out b);
            a = Numero.DecimalBinario(b);

            lblResultado.Text = a;
        }
        private void btnConvertirADecimal_Click(object sender, EventArgs e)
        {
            string a;

            a = Numero.BinarioDecimal(lblResultado.Text);

            lblResultado.Text = a;
        }
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void btnOperar_Click(object sender, EventArgs e)
        {
            double a;
            a = Operar(textNumero1.Text.Trim(), textNumero2.Text.Trim(), cmbOperador.Text.Trim());
           

            lblResultado.Text = a.ToString();
            

        }
        public void LaCalculadora()
        {

        }
        private void Limpiar()
        {
            textNumero1.Clear();
            textNumero2.Clear();
            lblResultado.Text = " ";
            cmbOperador.Text = " ";
            textNumero1.Focus();
        }
        private double Operar(string numero1, string numero2, string operador)
        {
            Numero n1 = new Numero();
            Numero n2 = new Numero();
            n1.SetNumero(numero1);
            n2.SetNumero(numero2);
            
            return Calculadora.Operar(n1, n2, operador);
        }

        private void FormCalculadora_Load(object sender, EventArgs e)
        {

        }

        private void textNumero2_TextChanged(object sender, EventArgs e)
        {
            
        }
    }
}
