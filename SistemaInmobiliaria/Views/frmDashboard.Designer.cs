namespace SistemaInmobiliaria.Views
{
    partial class frmDashboard
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.dgvDatos = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.dgvDatos2 = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.btnRecordatorio = new FontAwesome.Sharp.IconButton();
            this.btnWhatsApp = new FontAwesome.Sharp.IconButton();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatos2)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvDatos
            // 
            this.dgvDatos.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvDatos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDatos.Location = new System.Drawing.Point(12, 66);
            this.dgvDatos.Name = "dgvDatos";
            this.dgvDatos.RowHeadersWidth = 51;
            this.dgvDatos.RowTemplate.Height = 24;
            this.dgvDatos.Size = new System.Drawing.Size(1161, 219);
            this.dgvDatos.TabIndex = 0;
            this.dgvDatos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDatos_CellClick);
            this.dgvDatos.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvDatos_CellMouseClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(7, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(319, 29);
            this.label1.TabIndex = 20;
            this.label1.Text = "Clientes atrasados de pagos";
            // 
            // lblTotal
            // 
            this.lblTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTotal.AutoSize = true;
            this.lblTotal.Location = new System.Drawing.Point(1122, 827);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(44, 16);
            this.lblTotal.TabIndex = 21;
            this.lblTotal.Text = "label2";
            // 
            // chart1
            // 
            this.chart1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(39, 562);
            this.chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(1065, 281);
            this.chart1.TabIndex = 22;
            this.chart1.Text = "chart1";
            // 
            // dgvDatos2
            // 
            this.dgvDatos2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvDatos2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDatos2.Location = new System.Drawing.Point(12, 335);
            this.dgvDatos2.Name = "dgvDatos2";
            this.dgvDatos2.RowHeadersWidth = 51;
            this.dgvDatos2.RowTemplate.Height = 24;
            this.dgvDatos2.Size = new System.Drawing.Size(1161, 221);
            this.dgvDatos2.TabIndex = 23;
            this.dgvDatos2.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDatos2_CellClick);
            this.dgvDatos2.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvDatos2_CellMouseClick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 294);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(184, 29);
            this.label2.TabIndex = 24;
            this.label2.Text = "Cobros del mes";
            // 
            // btnRecordatorio
            // 
            this.btnRecordatorio.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRecordatorio.IconChar = FontAwesome.Sharp.IconChar.Bell;
            this.btnRecordatorio.IconColor = System.Drawing.Color.Black;
            this.btnRecordatorio.IconFont = FontAwesome.Sharp.IconFont.Solid;
            this.btnRecordatorio.IconSize = 32;
            this.btnRecordatorio.Location = new System.Drawing.Point(958, 19);
            this.btnRecordatorio.Name = "btnRecordatorio";
            this.btnRecordatorio.Size = new System.Drawing.Size(198, 35);
            this.btnRecordatorio.TabIndex = 25;
            this.btnRecordatorio.Text = "Ver Recordatorio";
            this.btnRecordatorio.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnRecordatorio.UseVisualStyleBackColor = true;
            this.btnRecordatorio.Visible = false;
            this.btnRecordatorio.Click += new System.EventHandler(this.btnRecordatorio_Click);
            // 
            // btnWhatsApp
            // 
            this.btnWhatsApp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnWhatsApp.IconChar = FontAwesome.Sharp.IconChar.Whatsapp;
            this.btnWhatsApp.IconColor = System.Drawing.Color.White;
            this.btnWhatsApp.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnWhatsApp.IconSize = 32;
            this.btnWhatsApp.Location = new System.Drawing.Point(947, 294);
            this.btnWhatsApp.Name = "btnWhatsApp";
            this.btnWhatsApp.Size = new System.Drawing.Size(172, 35);
            this.btnWhatsApp.TabIndex = 26;
            this.btnWhatsApp.Text = "Whatsapp";
            this.btnWhatsApp.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnWhatsApp.UseVisualStyleBackColor = true;
            this.btnWhatsApp.Visible = false;
            this.btnWhatsApp.Click += new System.EventHandler(this.btnWhatsApp_Click);
            // 
            // frmDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1185, 852);
            this.Controls.Add(this.btnWhatsApp);
            this.Controls.Add(this.btnRecordatorio);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dgvDatos2);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvDatos);
            this.Name = "frmDashboard";
            this.Text = "Dashboard";
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatos2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvDatos;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.DataGridView dgvDatos2;
        private System.Windows.Forms.Label label2;
        private FontAwesome.Sharp.IconButton btnRecordatorio;
        private FontAwesome.Sharp.IconButton btnWhatsApp;
    }
}