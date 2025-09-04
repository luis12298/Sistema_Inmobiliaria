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
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel8 = new System.Windows.Forms.Panel();
            this.btnMostrarAtra = new FontAwesome.Sharp.IconButton();
            this.lblTotalDeudas = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.btnMostrarCob = new FontAwesome.Sharp.IconButton();
            this.lblTotalCob = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.btnMostrarSus = new FontAwesome.Sharp.IconButton();
            this.lblTotalCon = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.lblTotalLote = new System.Windows.Forms.Label();
            this.btnMostrarLote = new FontAwesome.Sharp.IconButton();
            this.label4 = new System.Windows.Forms.Label();
            this.container = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.container.SuspendLayout();
            this.SuspendLayout();
            // 
            // chart1
            // 
            this.chart1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(41, 356);
            this.chart1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(1537, 455);
            this.chart1.TabIndex = 22;
            this.chart1.Text = "chart1";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.Controls.Add(this.panel8);
            this.panel3.Controls.Add(this.btnMostrarAtra);
            this.panel3.Controls.Add(this.lblTotalDeudas);
            this.panel3.Controls.Add(this.label6);
            this.panel3.Location = new System.Drawing.Point(787, 17);
            this.panel3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(375, 246);
            this.panel3.TabIndex = 27;
            // 
            // panel8
            // 
            this.panel8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(73)))), ((int)(((byte)(39)))));
            this.panel8.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel8.Location = new System.Drawing.Point(0, 0);
            this.panel8.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(8, 246);
            this.panel8.TabIndex = 5;
            // 
            // btnMostrarAtra
            // 
            this.btnMostrarAtra.IconChar = FontAwesome.Sharp.IconChar.CircleInfo;
            this.btnMostrarAtra.IconColor = System.Drawing.Color.Black;
            this.btnMostrarAtra.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnMostrarAtra.IconSize = 35;
            this.btnMostrarAtra.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMostrarAtra.Location = new System.Drawing.Point(24, 181);
            this.btnMostrarAtra.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnMostrarAtra.Name = "btnMostrarAtra";
            this.btnMostrarAtra.Size = new System.Drawing.Size(331, 49);
            this.btnMostrarAtra.TabIndex = 3;
            this.btnMostrarAtra.Text = "Mostrar";
            this.btnMostrarAtra.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnMostrarAtra.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnMostrarAtra.UseVisualStyleBackColor = true;
            this.btnMostrarAtra.Click += new System.EventHandler(this.btnMostrarAtra_Click);
            // 
            // lblTotalDeudas
            // 
            this.lblTotalDeudas.AutoSize = true;
            this.lblTotalDeudas.Font = new System.Drawing.Font("Microsoft Sans Serif", 40F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalDeudas.Location = new System.Drawing.Point(48, 26);
            this.lblTotalDeudas.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTotalDeudas.Name = "lblTotalDeudas";
            this.lblTotalDeudas.Size = new System.Drawing.Size(210, 73);
            this.lblTotalDeudas.TabIndex = 2;
            this.lblTotalDeudas.Text = "label5";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(40, 103);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(179, 40);
            this.label6.TabIndex = 0;
            this.label6.Text = "Atrasados";
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.White;
            this.panel4.Controls.Add(this.panel7);
            this.panel4.Controls.Add(this.btnMostrarCob);
            this.panel4.Controls.Add(this.lblTotalCob);
            this.panel4.Controls.Add(this.label3);
            this.panel4.Location = new System.Drawing.Point(404, 17);
            this.panel4.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(375, 246);
            this.panel4.TabIndex = 28;
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(117)))), ((int)(((byte)(125)))));
            this.panel7.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel7.Location = new System.Drawing.Point(0, 0);
            this.panel7.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(8, 246);
            this.panel7.TabIndex = 5;
            // 
            // btnMostrarCob
            // 
            this.btnMostrarCob.IconChar = FontAwesome.Sharp.IconChar.CircleInfo;
            this.btnMostrarCob.IconColor = System.Drawing.Color.Black;
            this.btnMostrarCob.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnMostrarCob.IconSize = 35;
            this.btnMostrarCob.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMostrarCob.Location = new System.Drawing.Point(24, 181);
            this.btnMostrarCob.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnMostrarCob.Name = "btnMostrarCob";
            this.btnMostrarCob.Size = new System.Drawing.Size(335, 49);
            this.btnMostrarCob.TabIndex = 3;
            this.btnMostrarCob.Text = "Mostrar";
            this.btnMostrarCob.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnMostrarCob.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnMostrarCob.UseVisualStyleBackColor = true;
            this.btnMostrarCob.Click += new System.EventHandler(this.btnMostrarCob_Click);
            // 
            // lblTotalCob
            // 
            this.lblTotalCob.AutoSize = true;
            this.lblTotalCob.Font = new System.Drawing.Font("Microsoft Sans Serif", 40F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalCob.Location = new System.Drawing.Point(48, 26);
            this.lblTotalCob.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTotalCob.Name = "lblTotalCob";
            this.lblTotalCob.Size = new System.Drawing.Size(210, 73);
            this.lblTotalCob.TabIndex = 2;
            this.lblTotalCob.Text = "label5";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(40, 103);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(133, 40);
            this.label3.TabIndex = 0;
            this.label3.Text = "Cobros";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.panel5);
            this.panel1.Controls.Add(this.btnMostrarSus);
            this.panel1.Controls.Add(this.lblTotalCon);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(21, 17);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(375, 246);
            this.panel1.TabIndex = 6;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(167)))), ((int)(((byte)(69)))));
            this.panel5.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(8, 246);
            this.panel5.TabIndex = 4;
            // 
            // btnMostrarSus
            // 
            this.btnMostrarSus.IconChar = FontAwesome.Sharp.IconChar.CircleInfo;
            this.btnMostrarSus.IconColor = System.Drawing.Color.Black;
            this.btnMostrarSus.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnMostrarSus.IconSize = 35;
            this.btnMostrarSus.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMostrarSus.Location = new System.Drawing.Point(24, 181);
            this.btnMostrarSus.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnMostrarSus.Name = "btnMostrarSus";
            this.btnMostrarSus.Size = new System.Drawing.Size(327, 49);
            this.btnMostrarSus.TabIndex = 3;
            this.btnMostrarSus.Text = "Mostrar";
            this.btnMostrarSus.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnMostrarSus.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnMostrarSus.UseVisualStyleBackColor = true;
            this.btnMostrarSus.Click += new System.EventHandler(this.btnMostrarSus_Click);
            // 
            // lblTotalCon
            // 
            this.lblTotalCon.AutoSize = true;
            this.lblTotalCon.Font = new System.Drawing.Font("Microsoft Sans Serif", 40F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalCon.Location = new System.Drawing.Point(25, 13);
            this.lblTotalCon.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTotalCon.Name = "lblTotalCon";
            this.lblTotalCon.Size = new System.Drawing.Size(210, 73);
            this.lblTotalCon.TabIndex = 2;
            this.lblTotalCon.Text = "label2";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(17, 90);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(173, 40);
            this.label1.TabIndex = 0;
            this.label1.Text = "Contratos";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.panel6);
            this.panel2.Controls.Add(this.lblTotalLote);
            this.panel2.Controls.Add(this.btnMostrarLote);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Location = new System.Drawing.Point(1170, 17);
            this.panel2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(375, 246);
            this.panel2.TabIndex = 29;
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(123)))), ((int)(((byte)(255)))));
            this.panel6.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel6.Location = new System.Drawing.Point(0, 0);
            this.panel6.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(8, 246);
            this.panel6.TabIndex = 5;
            // 
            // lblTotalLote
            // 
            this.lblTotalLote.AutoSize = true;
            this.lblTotalLote.Font = new System.Drawing.Font("Microsoft Sans Serif", 40F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalLote.Location = new System.Drawing.Point(48, 26);
            this.lblTotalLote.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTotalLote.Name = "lblTotalLote";
            this.lblTotalLote.Size = new System.Drawing.Size(210, 73);
            this.lblTotalLote.TabIndex = 2;
            this.lblTotalLote.Text = "label3";
            // 
            // btnMostrarLote
            // 
            this.btnMostrarLote.IconChar = FontAwesome.Sharp.IconChar.CircleInfo;
            this.btnMostrarLote.IconColor = System.Drawing.Color.Black;
            this.btnMostrarLote.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnMostrarLote.IconSize = 35;
            this.btnMostrarLote.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMostrarLote.Location = new System.Drawing.Point(24, 182);
            this.btnMostrarLote.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnMostrarLote.Name = "btnMostrarLote";
            this.btnMostrarLote.Size = new System.Drawing.Size(332, 49);
            this.btnMostrarLote.TabIndex = 1;
            this.btnMostrarLote.Text = "Mostrar";
            this.btnMostrarLote.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnMostrarLote.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnMostrarLote.UseVisualStyleBackColor = true;
            this.btnMostrarLote.Click += new System.EventHandler(this.btnMostrarLote_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(40, 103);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(105, 40);
            this.label4.TabIndex = 0;
            this.label4.Text = "Lotes";
            // 
            // container
            // 
            this.container.Controls.Add(this.panel3);
            this.container.Controls.Add(this.panel2);
            this.container.Controls.Add(this.panel4);
            this.container.Controls.Add(this.panel1);
            this.container.Location = new System.Drawing.Point(13, 27);
            this.container.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.container.Name = "container";
            this.container.Size = new System.Drawing.Size(1565, 295);
            this.container.TabIndex = 30;
            // 
            // frmDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1606, 852);
            this.Controls.Add(this.container);
            this.Controls.Add(this.chart1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "frmDashboard";
            this.Text = "Dashboard";
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.container.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel8;
        private FontAwesome.Sharp.IconButton btnMostrarAtra;
        private System.Windows.Forms.Label lblTotalDeudas;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel7;
        private FontAwesome.Sharp.IconButton btnMostrarCob;
        private System.Windows.Forms.Label lblTotalCob;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel5;
        private FontAwesome.Sharp.IconButton btnMostrarSus;
        private System.Windows.Forms.Label lblTotalCon;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label lblTotalLote;
        private FontAwesome.Sharp.IconButton btnMostrarLote;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel container;
    }
}