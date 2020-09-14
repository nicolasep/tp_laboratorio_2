using Entidades;
using System;
using System.Windows.Forms;

namespace MiCalculadora
{
    public partial class FormCalculadora : Form
    {
        public FormCalculadora()
        {
            InitializeComponent();
            
        }
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            FormCalculadora.ActiveForm.Close();
        }
        private void btnConvertirABinario_Click(object sender, EventArgs e)
        {
            string resultado;
            double.TryParse(this.lblResultado.Text, out double b);
            resultado = Numero.DecimalBinario(b);

            this.lblResultado.Text = resultado;

        }
        private void btnConvertirADecimal_Click(object sender, EventArgs e)
        {
            
            this.lblResultado.Text = Numero.BinarioDecimal(this.lblResultado.Text);
        }
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void btnOperar_Click(object sender, EventArgs e)
        {
            double resultado;

            resultado = Operar(this.textNumero1.Text.Trim(), this.textNumero2.Text.Trim(), this.cmbOperador.Text.Trim());
            this.lblResultado.Text = resultado.ToString();
        }
        
        private void Limpiar()
        {
            this.textNumero1.Clear();
            this.textNumero2.Clear();
            this.lblResultado.Text = " ";
            cmbOperador.SelectedIndex = -1;
            this.textNumero1.Focus();
        }
        private static double Operar(string numero1, string numero2, string operador)
        {
            Numero n1 = new Numero(numero1);
            Numero n2 = new Numero(numero2);
            
            return Calculadora.Operar(n1, n2, operador);
        }

       

        
    }
}
