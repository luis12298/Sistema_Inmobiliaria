namespace SistemaInmobiliaria.Views
{
    partial class frmReporteGeneral
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.lblTotalMes = new System.Windows.Forms.Label();
            this.lblMontoMes = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblMontoSemanal = new System.Windows.Forms.Label();
            this.lblTotalSemanal = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lblMontoHoy = new System.Windows.Forms.Label();
            this.lblTotalHoy = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.dgvDatos = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatos)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.panel1.Controls.Add(this.lblMontoMes);
            this.panel1.Controls.Add(this.lblTotalMes);
            this.panel1.Location = new System.Drawing.Point(12, 52);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(256, 153);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(185, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Resumen monto pagado mes";
            // 
            // lblTotalMes
            // 
            this.lblTotalMes.AutoSize = true;
            this.lblTotalMes.Location = new System.Drawing.Point(14, 22);
            this.lblTotalMes.Name = "lblTotalMes";
            this.lblTotalMes.Size = new System.Drawing.Size(81, 16);
            this.lblTotalMes.TabIndex = 2;
            this.lblTotalMes.Text = "Total Pagos";
            // 
            // lblMontoMes
            // 
            this.lblMontoMes.AutoSize = true;
            this.lblMontoMes.Location = new System.Drawing.Point(14, 53);
            this.lblMontoMes.Name = "lblMontoMes";
            this.lblMontoMes.Size = new System.Drawing.Size(95, 16);
            this.lblMontoMes.TabIndex = 3;
            this.lblMontoMes.Text = "Monto pagado";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(275, 30);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(211, 16);
            this.label4.TabIndex = 3;
            this.label4.Text = "Resumen monto pagado semanal";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Plum;
            this.panel2.Controls.Add(this.lblMontoSemanal);
            this.panel2.Controls.Add(this.lblTotalSemanal);
            this.panel2.Location = new System.Drawing.Point(274, 52);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(256, 153);
            this.panel2.TabIndex = 2;
            // 
            // lblMontoSemanal
            // 
            this.lblMontoSemanal.AutoSize = true;
            this.lblMontoSemanal.Location = new System.Drawing.Point(14, 53);
            this.lblMontoSemanal.Name = "lblMontoSemanal";
            this.lblMontoSemanal.Size = new System.Drawing.Size(95, 16);
            this.lblMontoSemanal.TabIndex = 3;
            this.lblMontoSemanal.Text = "Monto pagado";
            // 
            // lblTotalSemanal
            // 
            this.lblTotalSemanal.AutoSize = true;
            this.lblTotalSemanal.Location = new System.Drawing.Point(14, 22);
            this.lblTotalSemanal.Name = "lblTotalSemanal";
            this.lblTotalSemanal.Size = new System.Drawing.Size(81, 16);
            this.lblTotalSemanal.TabIndex = 2;
            this.lblTotalSemanal.Text = "Total Pagos";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(541, 30);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(181, 16);
            this.label7.TabIndex = 5;
            this.label7.Text = "Resumen monto pagado hoy";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Aquamarine;
            this.panel3.Controls.Add(this.lblMontoHoy);
            this.panel3.Controls.Add(this.lblTotalHoy);
            this.panel3.Location = new System.Drawing.Point(536, 52);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(256, 153);
            this.panel3.TabIndex = 4;
            // 
            // lblMontoHoy
            // 
            this.lblMontoHoy.AutoSize = true;
            this.lblMontoHoy.Location = new System.Drawing.Point(14, 53);
            this.lblMontoHoy.Name = "lblMontoHoy";
            this.lblMontoHoy.Size = new System.Drawing.Size(95, 16);
            this.lblMontoHoy.TabIndex = 3;
            this.lblMontoHoy.Text = "Monto pagado";
            // 
            // lblTotalHoy
            // 
            this.lblTotalHoy.AutoSize = true;
            this.lblTotalHoy.Location = new System.Drawing.Point(14, 22);
            this.lblTotalHoy.Name = "lblTotalHoy";
            this.lblTotalHoy.Size = new System.Drawing.Size(81, 16);
            this.lblTotalHoy.TabIndex = 2;
            this.lblTotalHoy.Text = "Total Pagos";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(13, 236);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(193, 16);
            this.label10.TabIndex = 6;
            this.label10.Text = "Pagos realizados dias del mes";
            // 
            // dgvDatos
            // 
            this.dgvDatos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDatos.Location = new System.Drawing.Point(16, 270);
            this.dgvDatos.Name = "dgvDatos";
            this.dgvDatos.RowHeadersWidth = 51;
            this.dgvDatos.RowTemplate.Height = 24;
            this.dgvDatos.Size = new System.Drawing.Size(780, 175);
            this.dgvDatos.TabIndex = 7;
            // 
            // frmReporteGeneral
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(811, 457);
            this.Controls.Add(this.dgvDatos);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmReporteGeneral";
            this.Text = "Reporte general";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblMontoMes;
        private System.Windows.Forms.Label lblTotalMes;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblMontoSemanal;
        private System.Windows.Forms.Label lblTotalSemanal;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label lblMontoHoy;
        private System.Windows.Forms.Label lblTotalHoy;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DataGridView dgvDatos;
    }
}