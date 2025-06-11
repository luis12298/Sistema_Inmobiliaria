namespace SistemaInmobiliaria.Views
{
    partial class frmCalculadora
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.btnImprimir = new FontAwesome.Sharp.IconButton();
            this.btnEjecutar2 = new FontAwesome.Sharp.IconButton();
            this.txtDia2 = new System.Windows.Forms.NumericUpDown();
            this.label11 = new System.Windows.Forms.Label();
            this.txtPrima = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dtpInicio = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.txtCuota = new System.Windows.Forms.TextBox();
            this.txtMonto = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtInteres = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtMeses = new System.Windows.Forms.TextBox();
            this.txtAnios = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btnImprimir2 = new FontAwesome.Sharp.IconButton();
            this.txtDia = new System.Windows.Forms.NumericUpDown();
            this.label10 = new System.Windows.Forms.Label();
            this.btnEjecutar = new FontAwesome.Sharp.IconButton();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.dtpInicio2 = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.txtCuotaFinal2 = new System.Windows.Forms.TextBox();
            this.txtPrima2 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtInteres2 = new System.Windows.Forms.TextBox();
            this.txtMonto2 = new System.Windows.Forms.TextBox();
            this.txtMeses2 = new System.Windows.Forms.TextBox();
            this.txtAnios2 = new System.Windows.Forms.TextBox();
            this.txtCuota2 = new System.Windows.Forms.TextBox();
            this.dgvAmortizacion = new System.Windows.Forms.DataGridView();
            this.btnCerrar = new FontAwesome.Sharp.IconButton();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtDia2)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtDia)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAmortizacion)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(24, 46);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1302, 308);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.btnImprimir);
            this.tabPage1.Controls.Add(this.btnEjecutar2);
            this.tabPage1.Controls.Add(this.txtDia2);
            this.tabPage1.Controls.Add(this.label11);
            this.tabPage1.Controls.Add(this.txtPrima);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.dtpInicio);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.txtCuota);
            this.tabPage1.Controls.Add(this.txtMonto);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.txtInteres);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.txtMeses);
            this.tabPage1.Controls.Add(this.txtAnios);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1294, 279);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Por amortización";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // btnImprimir
            // 
            this.btnImprimir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnImprimir.IconChar = FontAwesome.Sharp.IconChar.Print;
            this.btnImprimir.IconColor = System.Drawing.Color.Black;
            this.btnImprimir.IconFont = FontAwesome.Sharp.IconFont.Solid;
            this.btnImprimir.IconSize = 30;
            this.btnImprimir.Location = new System.Drawing.Point(1160, 238);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(128, 38);
            this.btnImprimir.TabIndex = 42;
            this.btnImprimir.Text = "Imprimir";
            this.btnImprimir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnImprimir.UseVisualStyleBackColor = true;
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click_1);
            // 
            // btnEjecutar2
            // 
            this.btnEjecutar2.IconChar = FontAwesome.Sharp.IconChar.SquareRootVariable;
            this.btnEjecutar2.IconColor = System.Drawing.Color.Black;
            this.btnEjecutar2.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnEjecutar2.IconSize = 30;
            this.btnEjecutar2.Location = new System.Drawing.Point(350, 236);
            this.btnEjecutar2.Name = "btnEjecutar2";
            this.btnEjecutar2.Size = new System.Drawing.Size(113, 35);
            this.btnEjecutar2.TabIndex = 41;
            this.btnEjecutar2.Text = "Ejecutar";
            this.btnEjecutar2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnEjecutar2.UseVisualStyleBackColor = true;
            this.btnEjecutar2.Click += new System.EventHandler(this.btnEjecutar2_Click);
            // 
            // txtDia2
            // 
            this.txtDia2.Location = new System.Drawing.Point(222, 242);
            this.txtDia2.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.txtDia2.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.txtDia2.Name = "txtDia2";
            this.txtDia2.Size = new System.Drawing.Size(108, 22);
            this.txtDia2.TabIndex = 9;
            this.txtDia2.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(219, 220);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(67, 16);
            this.label11.TabIndex = 39;
            this.label11.Text = "Definir dia";
            // 
            // txtPrima
            // 
            this.txtPrima.Location = new System.Drawing.Point(151, 116);
            this.txtPrima.Name = "txtPrima";
            this.txtPrima.Size = new System.Drawing.Size(241, 22);
            this.txtPrima.TabIndex = 4;
            this.txtPrima.TextChanged += new System.EventHandler(this.txtPrima_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(26, 223);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 16);
            this.label4.TabIndex = 24;
            this.label4.Text = "Fecha inicio";
            // 
            // dtpInicio
            // 
            this.dtpInicio.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpInicio.Location = new System.Drawing.Point(29, 242);
            this.dtpInicio.Name = "dtpInicio";
            this.dtpInicio.Size = new System.Drawing.Size(177, 22);
            this.dtpInicio.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(208, 160);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 16);
            this.label3.TabIndex = 22;
            this.label3.Text = "Cuota final";
            // 
            // txtCuota
            // 
            this.txtCuota.Location = new System.Drawing.Point(207, 182);
            this.txtCuota.Name = "txtCuota";
            this.txtCuota.ReadOnly = true;
            this.txtCuota.Size = new System.Drawing.Size(176, 22);
            this.txtCuota.TabIndex = 6;
            // 
            // txtMonto
            // 
            this.txtMonto.Location = new System.Drawing.Point(127, 54);
            this.txtMonto.Name = "txtMonto";
            this.txtMonto.Size = new System.Drawing.Size(265, 22);
            this.txtMonto.TabIndex = 2;
            this.txtMonto.TextChanged += new System.EventHandler(this.txtMonto_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(124, 119);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(19, 16);
            this.label2.TabIndex = 19;
            this.label2.Text = "%";
            // 
            // txtInteres
            // 
            this.txtInteres.Location = new System.Drawing.Point(29, 116);
            this.txtInteres.Name = "txtInteres";
            this.txtInteres.Size = new System.Drawing.Size(92, 22);
            this.txtInteres.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 160);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(131, 16);
            this.label1.TabIndex = 17;
            this.label1.Text = "Resultado en meses";
            // 
            // txtMeses
            // 
            this.txtMeses.Location = new System.Drawing.Point(25, 182);
            this.txtMeses.Name = "txtMeses";
            this.txtMeses.ReadOnly = true;
            this.txtMeses.Size = new System.Drawing.Size(176, 22);
            this.txtMeses.TabIndex = 5;
            // 
            // txtAnios
            // 
            this.txtAnios.Location = new System.Drawing.Point(25, 54);
            this.txtAnios.Name = "txtAnios";
            this.txtAnios.Size = new System.Drawing.Size(96, 22);
            this.txtAnios.TabIndex = 0;
            this.txtAnios.TextChanged += new System.EventHandler(this.txtAnios_TextChanged);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.btnImprimir2);
            this.tabPage2.Controls.Add(this.txtDia);
            this.tabPage2.Controls.Add(this.label10);
            this.tabPage2.Controls.Add(this.btnEjecutar);
            this.tabPage2.Controls.Add(this.label9);
            this.tabPage2.Controls.Add(this.label8);
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Controls.Add(this.dtpInicio2);
            this.tabPage2.Controls.Add(this.label7);
            this.tabPage2.Controls.Add(this.txtCuotaFinal2);
            this.tabPage2.Controls.Add(this.txtPrima2);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.txtInteres2);
            this.tabPage2.Controls.Add(this.txtMonto2);
            this.tabPage2.Controls.Add(this.txtMeses2);
            this.tabPage2.Controls.Add(this.txtAnios2);
            this.tabPage2.Controls.Add(this.txtCuota2);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1273, 279);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Cuota definida";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // btnImprimir2
            // 
            this.btnImprimir2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnImprimir2.IconChar = FontAwesome.Sharp.IconChar.Print;
            this.btnImprimir2.IconColor = System.Drawing.Color.Black;
            this.btnImprimir2.IconFont = FontAwesome.Sharp.IconFont.Solid;
            this.btnImprimir2.IconSize = 30;
            this.btnImprimir2.Location = new System.Drawing.Point(1139, 238);
            this.btnImprimir2.Name = "btnImprimir2";
            this.btnImprimir2.Size = new System.Drawing.Size(128, 38);
            this.btnImprimir2.TabIndex = 43;
            this.btnImprimir2.Text = "Imprimir";
            this.btnImprimir2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnImprimir2.UseVisualStyleBackColor = true;
            this.btnImprimir2.Click += new System.EventHandler(this.btnImprimir2_Click);
            // 
            // txtDia
            // 
            this.txtDia.Location = new System.Drawing.Point(467, 132);
            this.txtDia.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.txtDia.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.txtDia.Name = "txtDia";
            this.txtDia.Size = new System.Drawing.Size(79, 22);
            this.txtDia.TabIndex = 12;
            this.txtDia.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.txtDia.ValueChanged += new System.EventHandler(this.txtDia_ValueChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(464, 110);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(67, 16);
            this.label10.TabIndex = 37;
            this.label10.Text = "Definir dia";
            // 
            // btnEjecutar
            // 
            this.btnEjecutar.IconChar = FontAwesome.Sharp.IconChar.SquareRootVariable;
            this.btnEjecutar.IconColor = System.Drawing.Color.Black;
            this.btnEjecutar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnEjecutar.IconSize = 30;
            this.btnEjecutar.Location = new System.Drawing.Point(396, 42);
            this.btnEjecutar.Name = "btnEjecutar";
            this.btnEjecutar.Size = new System.Drawing.Size(113, 35);
            this.btnEjecutar.TabIndex = 35;
            this.btnEjecutar.Text = "Ejecutar";
            this.btnEjecutar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnEjecutar.UseVisualStyleBackColor = true;
            this.btnEjecutar.Click += new System.EventHandler(this.btnEjecutar_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(16, 110);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(120, 16);
            this.label9.TabIndex = 34;
            this.label9.Text = "Resultado en años";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(16, 173);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(131, 16);
            this.label8.TabIndex = 33;
            this.label8.Text = "Resultado en meses";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(401, 173);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(79, 16);
            this.label6.TabIndex = 32;
            this.label6.Text = "Fecha inicio";
            // 
            // dtpInicio2
            // 
            this.dtpInicio2.Enabled = false;
            this.dtpInicio2.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpInicio2.Location = new System.Drawing.Point(404, 192);
            this.dtpInicio2.Name = "dtpInicio2";
            this.dtpInicio2.Size = new System.Drawing.Size(177, 22);
            this.dtpInicio2.TabIndex = 16;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(214, 170);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(69, 16);
            this.label7.TabIndex = 30;
            this.label7.Text = "Cuota final";
            // 
            // txtCuotaFinal2
            // 
            this.txtCuotaFinal2.Location = new System.Drawing.Point(213, 192);
            this.txtCuotaFinal2.Name = "txtCuotaFinal2";
            this.txtCuotaFinal2.ReadOnly = true;
            this.txtCuotaFinal2.Size = new System.Drawing.Size(176, 22);
            this.txtCuotaFinal2.TabIndex = 14;
            // 
            // txtPrima2
            // 
            this.txtPrima2.Location = new System.Drawing.Point(329, 129);
            this.txtPrima2.Multiline = true;
            this.txtPrima2.Name = "txtPrima2";
            this.txtPrima2.Size = new System.Drawing.Size(132, 35);
            this.txtPrima2.TabIndex = 11;
            this.txtPrima2.TextChanged += new System.EventHandler(this.txtPrima2_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(304, 132);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(19, 16);
            this.label5.TabIndex = 27;
            this.label5.Text = "%";
            // 
            // txtInteres2
            // 
            this.txtInteres2.Location = new System.Drawing.Point(213, 129);
            this.txtInteres2.Name = "txtInteres2";
            this.txtInteres2.Size = new System.Drawing.Size(85, 22);
            this.txtInteres2.TabIndex = 10;
            // 
            // txtMonto2
            // 
            this.txtMonto2.Location = new System.Drawing.Point(213, 42);
            this.txtMonto2.Name = "txtMonto2";
            this.txtMonto2.Size = new System.Drawing.Size(177, 22);
            this.txtMonto2.TabIndex = 8;
            this.txtMonto2.TextChanged += new System.EventHandler(this.txtMonto2_TextChanged);
            // 
            // txtMeses2
            // 
            this.txtMeses2.Location = new System.Drawing.Point(19, 192);
            this.txtMeses2.Name = "txtMeses2";
            this.txtMeses2.ReadOnly = true;
            this.txtMeses2.Size = new System.Drawing.Size(177, 22);
            this.txtMeses2.TabIndex = 13;
            // 
            // txtAnios2
            // 
            this.txtAnios2.Location = new System.Drawing.Point(19, 129);
            this.txtAnios2.Name = "txtAnios2";
            this.txtAnios2.ReadOnly = true;
            this.txtAnios2.Size = new System.Drawing.Size(177, 22);
            this.txtAnios2.TabIndex = 9;
            // 
            // txtCuota2
            // 
            this.txtCuota2.Location = new System.Drawing.Point(19, 42);
            this.txtCuota2.Name = "txtCuota2";
            this.txtCuota2.Size = new System.Drawing.Size(177, 22);
            this.txtCuota2.TabIndex = 7;
            this.txtCuota2.TextChanged += new System.EventHandler(this.txtCuota2_TextChanged);
            // 
            // dgvAmortizacion
            // 
            this.dgvAmortizacion.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvAmortizacion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAmortizacion.Location = new System.Drawing.Point(28, 375);
            this.dgvAmortizacion.Name = "dgvAmortizacion";
            this.dgvAmortizacion.RowHeadersWidth = 51;
            this.dgvAmortizacion.RowTemplate.Height = 24;
            this.dgvAmortizacion.Size = new System.Drawing.Size(1298, 275);
            this.dgvAmortizacion.TabIndex = 1;
            // 
            // btnCerrar
            // 
            this.btnCerrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCerrar.BackColor = System.Drawing.Color.Transparent;
            this.btnCerrar.FlatAppearance.BorderSize = 0;
            this.btnCerrar.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.InactiveBorder;
            this.btnCerrar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnCerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCerrar.IconChar = FontAwesome.Sharp.IconChar.CircleXmark;
            this.btnCerrar.IconColor = System.Drawing.Color.Black;
            this.btnCerrar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnCerrar.IconSize = 44;
            this.btnCerrar.Location = new System.Drawing.Point(1278, 12);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(48, 48);
            this.btnCerrar.TabIndex = 19;
            this.btnCerrar.UseVisualStyleBackColor = false;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // frmCalculadora
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1338, 655);
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.dgvAmortizacion);
            this.Controls.Add(this.tabControl1);
            this.Name = "frmCalculadora";
            this.Text = "Calculadora";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtDia2)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtDia)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAmortizacion)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TextBox txtPrima;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtpInicio;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtCuota;
        private System.Windows.Forms.TextBox txtMonto;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtInteres;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtMeses;
        private System.Windows.Forms.TextBox txtAnios;
        private System.Windows.Forms.TextBox txtMeses2;
        private System.Windows.Forms.TextBox txtAnios2;
        private System.Windows.Forms.TextBox txtCuota2;
        private System.Windows.Forms.TextBox txtPrima2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtInteres2;
        private System.Windows.Forms.TextBox txtMonto2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dtpInicio2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtCuotaFinal2;
        private FontAwesome.Sharp.IconButton btnEjecutar;
        private System.Windows.Forms.DataGridView dgvAmortizacion;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.NumericUpDown txtDia;
        private System.Windows.Forms.NumericUpDown txtDia2;
        private System.Windows.Forms.Label label11;
        private FontAwesome.Sharp.IconButton btnEjecutar2;
        private FontAwesome.Sharp.IconButton btnImprimir;
        private FontAwesome.Sharp.IconButton btnImprimir2;
        private FontAwesome.Sharp.IconButton btnCerrar;
    }
}