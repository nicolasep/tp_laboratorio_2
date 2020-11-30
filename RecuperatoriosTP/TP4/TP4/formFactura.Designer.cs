namespace TP4
{
    partial class formFactura
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.richFactura = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // richFactura
            // 
            this.richFactura.Location = new System.Drawing.Point(17, 18);
            this.richFactura.Name = "richFactura";
            this.richFactura.Size = new System.Drawing.Size(757, 424);
            this.richFactura.TabIndex = 0;
            this.richFactura.Text = "";
            // 
            // Factura
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.richFactura);
            this.Name = "Factura";
            this.Text = "Factura";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox richFactura;
    }
}