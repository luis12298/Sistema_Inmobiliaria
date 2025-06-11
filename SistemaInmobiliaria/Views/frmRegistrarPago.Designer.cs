namespace SistemaInmobiliaria.Views
{
    partial class frmRegistrarPago
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
            this.components = new System.ComponentModel.Container();
            this.lblCliente = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvDatos = new System.Windows.Forms.DataGridView();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.txtNoCuota = new System.Windows.Forms.TextBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.txtMontoPagar = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.ckModificar = new System.Windows.Forms.CheckBox();
            this.btnRegistrar = new FontAwesome.Sharp.IconButton();
            this.btnEliminarPago = new FontAwesome.Sharp.IconButton();
            this.btnImprimirFactura = new FontAwesome.Sharp.IconButton();
            this.btnVolver = new FontAwesome.Sharp.IconButton();
            this.btnVerPagos = new FontAwesome.Sharp.IconButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtCuotaPendiente = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtCuotaPagada = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.TotalRestante = new System.Windows.Forms.TextBox();
            this.TotalPagado = new System.Windows.Forms.TextBox();
            this.btnPlan = new FontAwesome.Sharp.IconButton();
            this.btnVerPago = new FontAwesome.Sharp.IconButton();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatos)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblCliente
            // 
            this.lblCliente.AutoSize = true;
            this.lblCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCliente.Location = new System.Drawing.Point(12, 80);
            this.lblCliente.Name = "lblCliente";
            this.lblCliente.Size = new System.Drawing.Size(95, 36);
            this.lblCliente.TabIndex = 0;
            this.lblCliente.Text = "label1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(313, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(226, 36);
            this.label1.TabIndex = 1;
            this.label1.Text = "Registrar pagos";
            // 
            // dgvDatos
            // 
            this.dgvDatos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvDatos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDatos.Location = new System.Drawing.Point(12, 275);
            this.dgvDatos.Name = "dgvDatos";
            this.dgvDatos.RowHeadersWidth = 51;
            this.dgvDatos.RowTemplate.Height = 24;
            this.dgvDatos.Size = new System.Drawing.Size(890, 268);
            this.dgvDatos.TabIndex = 2;
            this.dgvDatos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDatos_CellClick);
            // 
            // txtNoCuota
            // 
            this.txtNoCuota.Location = new System.Drawing.Point(18, 158);
            this.txtNoCuota.Name = "txtNoCuota";
            this.txtNoCuota.ReadOnly = true;
            this.txtNoCuota.Size = new System.Drawing.Size(167, 22);
            this.txtNoCuota.TabIndex = 3;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Enabled = false;
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(421, 171);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(167, 22);
            this.dateTimePicker1.TabIndex = 4;
            // 
            // txtMontoPagar
            // 
            this.txtMontoPagar.Location = new System.Drawing.Point(201, 158);
            this.txtMontoPagar.Name = "txtMontoPagar";
            this.txtMontoPagar.ReadOnly = true;
            this.txtMontoPagar.Size = new System.Drawing.Size(214, 22);
            this.txtMontoPagar.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(422, 152);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 16);
            this.label2.TabIndex = 10;
            this.label2.Text = "Fecha de cuota";
            // 
            // ckModificar
            // 
            this.ckModificar.AutoSize = true;
            this.ckModificar.Location = new System.Drawing.Point(201, 204);
            this.ckModificar.Name = "ckModificar";
            this.ckModificar.Size = new System.Drawing.Size(117, 20);
            this.ckModificar.TabIndex = 11;
            this.ckModificar.Text = "Modifcar cuota";
            this.ckModificar.UseVisualStyleBackColor = true;
            this.ckModificar.CheckedChanged += new System.EventHandler(this.ckModificar_CheckedChanged);
            // 
            // btnRegistrar
            // 
            this.btnRegistrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRegistrar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(191)))), ((int)(((byte)(108)))));
            this.btnRegistrar.FlatAppearance.BorderSize = 0;
            this.btnRegistrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRegistrar.IconChar = FontAwesome.Sharp.IconChar.MoneyBill1Wave;
            this.btnRegistrar.IconColor = System.Drawing.Color.DimGray;
            this.btnRegistrar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnRegistrar.IconSize = 30;
            this.btnRegistrar.Location = new System.Drawing.Point(729, 234);
            this.btnRegistrar.Name = "btnRegistrar";
            this.btnRegistrar.Size = new System.Drawing.Size(173, 35);
            this.btnRegistrar.TabIndex = 12;
            this.btnRegistrar.Text = "Registrar pago";
            this.btnRegistrar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnRegistrar.UseVisualStyleBackColor = false;
            this.btnRegistrar.Click += new System.EventHandler(this.btnRegistrar_Click);
            // 
            // btnEliminarPago
            // 
            this.btnEliminarPago.BackColor = System.Drawing.Color.Red;
            this.btnEliminarPago.FlatAppearance.BorderSize = 0;
            this.btnEliminarPago.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminarPago.IconChar = FontAwesome.Sharp.IconChar.FileCircleXmark;
            this.btnEliminarPago.IconColor = System.Drawing.Color.White;
            this.btnEliminarPago.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnEliminarPago.IconSize = 30;
            this.btnEliminarPago.Location = new System.Drawing.Point(159, 234);
            this.btnEliminarPago.Name = "btnEliminarPago";
            this.btnEliminarPago.Size = new System.Drawing.Size(72, 35);
            this.btnEliminarPago.TabIndex = 9;
            this.btnEliminarPago.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnEliminarPago.UseVisualStyleBackColor = false;
            this.btnEliminarPago.Click += new System.EventHandler(this.btnEliminarPago_Click);
            // 
            // btnImprimirFactura
            // 
            this.btnImprimirFactura.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(162)))), ((int)(((byte)(239)))));
            this.btnImprimirFactura.FlatAppearance.BorderSize = 0;
            this.btnImprimirFactura.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnImprimirFactura.IconChar = FontAwesome.Sharp.IconChar.FileInvoice;
            this.btnImprimirFactura.IconColor = System.Drawing.Color.White;
            this.btnImprimirFactura.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnImprimirFactura.IconSize = 30;
            this.btnImprimirFactura.Location = new System.Drawing.Point(85, 234);
            this.btnImprimirFactura.Name = "btnImprimirFactura";
            this.btnImprimirFactura.Size = new System.Drawing.Size(72, 35);
            this.btnImprimirFactura.TabIndex = 8;
            this.btnImprimirFactura.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnImprimirFactura.UseVisualStyleBackColor = false;
            this.btnImprimirFactura.Click += new System.EventHandler(this.btnImprimirFactura_Click);
            // 
            // btnVolver
            // 
            this.btnVolver.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnVolver.BackColor = System.Drawing.Color.Transparent;
            this.btnVolver.FlatAppearance.BorderSize = 0;
            this.btnVolver.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnVolver.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnVolver.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVolver.IconChar = FontAwesome.Sharp.IconChar.CircleXmark;
            this.btnVolver.IconColor = System.Drawing.Color.Black;
            this.btnVolver.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnVolver.IconSize = 40;
            this.btnVolver.Location = new System.Drawing.Point(862, 12);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(40, 40);
            this.btnVolver.TabIndex = 7;
            this.btnVolver.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnVolver.UseVisualStyleBackColor = false;
            this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click);
            // 
            // btnVerPagos
            // 
            this.btnVerPagos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(191)))), ((int)(((byte)(108)))));
            this.btnVerPagos.FlatAppearance.BorderSize = 0;
            this.btnVerPagos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVerPagos.IconChar = FontAwesome.Sharp.IconChar.List;
            this.btnVerPagos.IconColor = System.Drawing.Color.White;
            this.btnVerPagos.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnVerPagos.IconSize = 30;
            this.btnVerPagos.Location = new System.Drawing.Point(12, 234);
            this.btnVerPagos.Name = "btnVerPagos";
            this.btnVerPagos.Size = new System.Drawing.Size(72, 35);
            this.btnVerPagos.TabIndex = 6;
            this.btnVerPagos.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnVerPagos.UseVisualStyleBackColor = false;
            this.btnVerPagos.Click += new System.EventHandler(this.btnVerPagos_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtCuotaPendiente);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtCuotaPagada);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.TotalRestante);
            this.groupBox1.Controls.Add(this.TotalPagado);
            this.groupBox1.Location = new System.Drawing.Point(18, 563);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(884, 100);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Detalle";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(634, 38);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(119, 16);
            this.label6.TabIndex = 7;
            this.label6.Text = "Cuotas pendientes";
            // 
            // txtCuotaPendiente
            // 
            this.txtCuotaPendiente.Location = new System.Drawing.Point(634, 60);
            this.txtCuotaPendiente.Name = "txtCuotaPendiente";
            this.txtCuotaPendiente.ReadOnly = true;
            this.txtCuotaPendiente.Size = new System.Drawing.Size(133, 22);
            this.txtCuotaPendiente.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(495, 38);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(107, 16);
            this.label5.TabIndex = 5;
            this.label5.Text = "Cuotas pagadas";
            // 
            // txtCuotaPagada
            // 
            this.txtCuotaPagada.Location = new System.Drawing.Point(495, 60);
            this.txtCuotaPagada.Name = "txtCuotaPagada";
            this.txtCuotaPagada.ReadOnly = true;
            this.txtCuotaPagada.Size = new System.Drawing.Size(133, 22);
            this.txtCuotaPagada.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(255, 38);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(95, 16);
            this.label4.TabIndex = 3;
            this.label4.Text = "Monto restante";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 38);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "Monto Pagado";
            // 
            // TotalRestante
            // 
            this.TotalRestante.Location = new System.Drawing.Point(255, 60);
            this.TotalRestante.Name = "TotalRestante";
            this.TotalRestante.ReadOnly = true;
            this.TotalRestante.Size = new System.Drawing.Size(234, 22);
            this.TotalRestante.TabIndex = 1;
            // 
            // TotalPagado
            // 
            this.TotalPagado.Location = new System.Drawing.Point(15, 60);
            this.TotalPagado.Name = "TotalPagado";
            this.TotalPagado.ReadOnly = true;
            this.TotalPagado.Size = new System.Drawing.Size(234, 22);
            this.TotalPagado.TabIndex = 0;
            // 
            // btnPlan
            // 
            this.btnPlan.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(162)))), ((int)(((byte)(239)))));
            this.btnPlan.FlatAppearance.BorderSize = 0;
            this.btnPlan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPlan.IconChar = FontAwesome.Sharp.IconChar.FileContract;
            this.btnPlan.IconColor = System.Drawing.Color.White;
            this.btnPlan.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnPlan.IconSize = 30;
            this.btnPlan.Location = new System.Drawing.Point(233, 234);
            this.btnPlan.Name = "btnPlan";
            this.btnPlan.Size = new System.Drawing.Size(72, 35);
            this.btnPlan.TabIndex = 14;
            this.btnPlan.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnPlan.UseVisualStyleBackColor = false;
            this.btnPlan.Click += new System.EventHandler(this.btnPlan_Click);
            // 
            // btnVerPago
            // 
            this.btnVerPago.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(162)))), ((int)(((byte)(239)))));
            this.btnVerPago.FlatAppearance.BorderSize = 0;
            this.btnVerPago.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVerPago.IconChar = FontAwesome.Sharp.IconChar.FileInvoice;
            this.btnVerPago.IconColor = System.Drawing.Color.White;
            this.btnVerPago.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnVerPago.IconSize = 30;
            this.btnVerPago.Location = new System.Drawing.Point(308, 234);
            this.btnVerPago.Name = "btnVerPago";
            this.btnVerPago.Size = new System.Drawing.Size(72, 35);
            this.btnVerPago.TabIndex = 15;
            this.btnVerPago.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnVerPago.UseVisualStyleBackColor = false;
            this.btnVerPago.Click += new System.EventHandler(this.btnVerPago_Click);
            // 
            // frmRegistrarPago
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(914, 669);
            this.Controls.Add(this.btnVerPago);
            this.Controls.Add(this.btnPlan);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnRegistrar);
            this.Controls.Add(this.ckModificar);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnEliminarPago);
            this.Controls.Add(this.btnImprimirFactura);
            this.Controls.Add(this.btnVolver);
            this.Controls.Add(this.btnVerPagos);
            this.Controls.Add(this.txtMontoPagar);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.txtNoCuota);
            this.Controls.Add(this.dgvDatos);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblCliente);
            this.Name = "frmRegistrarPago";
            this.Text = "Registrar pago";
            this.Load += new System.EventHandler(this.frmRegistrarPago_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatos)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblCliente;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvDatos;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.TextBox txtNoCuota;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.TextBox txtMontoPagar;
        private FontAwesome.Sharp.IconButton btnVerPagos;
        private FontAwesome.Sharp.IconButton btnVolver;
        private FontAwesome.Sharp.IconButton btnImprimirFactura;
        private FontAwesome.Sharp.IconButton btnEliminarPago;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox ckModificar;
        private FontAwesome.Sharp.IconButton btnRegistrar;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TotalRestante;
        private System.Windows.Forms.TextBox TotalPagado;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtCuotaPendiente;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtCuotaPagada;
        private FontAwesome.Sharp.IconButton btnPlan;
        private FontAwesome.Sharp.IconButton btnVerPago;
    }
}