namespace SistemaInmobiliaria.Views
{
    partial class frmPagoComision
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
            this.dgvDatos = new System.Windows.Forms.DataGridView();
            this.btnCargar = new FontAwesome.Sharp.IconButton();
            this.txtVendedor = new System.Windows.Forms.TextBox();
            this.txtMonto = new System.Windows.Forms.TextBox();
            this.txtMontoAnterior = new System.Windows.Forms.TextBox();
            this.txtSaldoNuevo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatos)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvDatos
            // 
            this.dgvDatos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvDatos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDatos.Location = new System.Drawing.Point(29, 418);
            this.dgvDatos.Name = "dgvDatos";
            this.dgvDatos.Size = new System.Drawing.Size(724, 185);
            this.dgvDatos.TabIndex = 0;
            this.dgvDatos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDatos_CellClick);
            // 
            // btnCargar
            // 
            this.btnCargar.IconChar = FontAwesome.Sharp.IconChar.None;
            this.btnCargar.IconColor = System.Drawing.Color.Black;
            this.btnCargar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnCargar.Location = new System.Drawing.Point(348, 110);
            this.btnCargar.Name = "btnCargar";
            this.btnCargar.Size = new System.Drawing.Size(139, 30);
            this.btnCargar.TabIndex = 3;
            this.btnCargar.Text = "Cargar vendedor";
            this.btnCargar.UseVisualStyleBackColor = true;
            this.btnCargar.Click += new System.EventHandler(this.btnCargar_Click);
            // 
            // txtVendedor
            // 
            this.txtVendedor.Location = new System.Drawing.Point(29, 110);
            this.txtVendedor.Multiline = true;
            this.txtVendedor.Name = "txtVendedor";
            this.txtVendedor.ReadOnly = true;
            this.txtVendedor.Size = new System.Drawing.Size(313, 30);
            this.txtVendedor.TabIndex = 2;
            // 
            // txtMonto
            // 
            this.txtMonto.Location = new System.Drawing.Point(29, 221);
            this.txtMonto.Multiline = true;
            this.txtMonto.Name = "txtMonto";
            this.txtMonto.Size = new System.Drawing.Size(313, 38);
            this.txtMonto.TabIndex = 7;
            this.txtMonto.TextChanged += new System.EventHandler(this.txtMonto_TextChanged);
            // 
            // txtMontoAnterior
            // 
            this.txtMontoAnterior.Location = new System.Drawing.Point(29, 167);
            this.txtMontoAnterior.Multiline = true;
            this.txtMontoAnterior.Name = "txtMontoAnterior";
            this.txtMontoAnterior.ReadOnly = true;
            this.txtMontoAnterior.Size = new System.Drawing.Size(313, 30);
            this.txtMontoAnterior.TabIndex = 8;
            // 
            // txtSaldoNuevo
            // 
            this.txtSaldoNuevo.Location = new System.Drawing.Point(29, 283);
            this.txtSaldoNuevo.Multiline = true;
            this.txtSaldoNuevo.Name = "txtSaldoNuevo";
            this.txtSaldoNuevo.ReadOnly = true;
            this.txtSaldoNuevo.Size = new System.Drawing.Size(313, 30);
            this.txtSaldoNuevo.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(345, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Pagos de comisiones";
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(29, 374);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(171, 36);
            this.btnGuardar.TabIndex = 11;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(206, 374);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(171, 36);
            this.btnCancelar.TabIndex = 12;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // frmPagoComision
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 615);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtSaldoNuevo);
            this.Controls.Add(this.txtMontoAnterior);
            this.Controls.Add(this.txtMonto);
            this.Controls.Add(this.btnCargar);
            this.Controls.Add(this.txtVendedor);
            this.Controls.Add(this.dgvDatos);
            this.Name = "frmPagoComision";
            this.Text = "frmPagoComision";
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvDatos;
        private FontAwesome.Sharp.IconButton btnCargar;
        private System.Windows.Forms.TextBox txtVendedor;
        private System.Windows.Forms.TextBox txtMonto;
        private System.Windows.Forms.TextBox txtMontoAnterior;
        private System.Windows.Forms.TextBox txtSaldoNuevo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnCancelar;
    }
}