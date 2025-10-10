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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
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
            this.chart3 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chart2 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.panel9 = new System.Windows.Forms.Panel();
            this.lblPorcentaj = new System.Windows.Forms.Label();
            this.panel10 = new System.Windows.Forms.Panel();
            this.lblPorcentaje = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.container.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart2)).BeginInit();
            this.panel9.SuspendLayout();
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
            this.chart1.Location = new System.Drawing.Point(31, 467);
            this.chart1.Margin = new System.Windows.Forms.Padding(2);
            this.chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(1153, 300);
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
            this.panel3.Location = new System.Drawing.Point(590, 14);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(281, 200);
            this.panel3.TabIndex = 27;
            // 
            // panel8
            // 
            this.panel8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(73)))), ((int)(((byte)(39)))));
            this.panel8.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel8.Location = new System.Drawing.Point(0, 0);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(6, 200);
            this.panel8.TabIndex = 5;
            // 
            // btnMostrarAtra
            // 
            this.btnMostrarAtra.IconChar = FontAwesome.Sharp.IconChar.CircleInfo;
            this.btnMostrarAtra.IconColor = System.Drawing.Color.White;
            this.btnMostrarAtra.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnMostrarAtra.IconSize = 35;
            this.btnMostrarAtra.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMostrarAtra.Location = new System.Drawing.Point(18, 147);
            this.btnMostrarAtra.Name = "btnMostrarAtra";
            this.btnMostrarAtra.Size = new System.Drawing.Size(248, 40);
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
            this.lblTotalDeudas.Location = new System.Drawing.Point(36, 21);
            this.lblTotalDeudas.Name = "lblTotalDeudas";
            this.lblTotalDeudas.Size = new System.Drawing.Size(179, 63);
            this.lblTotalDeudas.TabIndex = 2;
            this.lblTotalDeudas.Text = "label5";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(30, 84);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(150, 36);
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
            this.panel4.Location = new System.Drawing.Point(303, 14);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(281, 200);
            this.panel4.TabIndex = 28;
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(117)))), ((int)(((byte)(125)))));
            this.panel7.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel7.Location = new System.Drawing.Point(0, 0);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(6, 200);
            this.panel7.TabIndex = 5;
            // 
            // btnMostrarCob
            // 
            this.btnMostrarCob.IconChar = FontAwesome.Sharp.IconChar.CircleInfo;
            this.btnMostrarCob.IconColor = System.Drawing.Color.White;
            this.btnMostrarCob.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnMostrarCob.IconSize = 35;
            this.btnMostrarCob.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMostrarCob.Location = new System.Drawing.Point(18, 147);
            this.btnMostrarCob.Name = "btnMostrarCob";
            this.btnMostrarCob.Size = new System.Drawing.Size(251, 40);
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
            this.lblTotalCob.Location = new System.Drawing.Point(25, 21);
            this.lblTotalCob.Name = "lblTotalCob";
            this.lblTotalCob.Size = new System.Drawing.Size(179, 63);
            this.lblTotalCob.TabIndex = 2;
            this.lblTotalCob.Text = "label5";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(30, 84);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(112, 36);
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
            this.panel1.Location = new System.Drawing.Point(16, 14);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(281, 200);
            this.panel1.TabIndex = 6;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(167)))), ((int)(((byte)(69)))));
            this.panel5.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(6, 200);
            this.panel5.TabIndex = 4;
            // 
            // btnMostrarSus
            // 
            this.btnMostrarSus.IconChar = FontAwesome.Sharp.IconChar.CircleInfo;
            this.btnMostrarSus.IconColor = System.Drawing.Color.White;
            this.btnMostrarSus.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnMostrarSus.IconSize = 35;
            this.btnMostrarSus.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMostrarSus.Location = new System.Drawing.Point(18, 147);
            this.btnMostrarSus.Name = "btnMostrarSus";
            this.btnMostrarSus.Size = new System.Drawing.Size(245, 40);
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
            this.lblTotalCon.Location = new System.Drawing.Point(19, 11);
            this.lblTotalCon.Name = "lblTotalCon";
            this.lblTotalCon.Size = new System.Drawing.Size(179, 63);
            this.lblTotalCon.TabIndex = 2;
            this.lblTotalCon.Text = "label2";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 73);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(144, 36);
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
            this.panel2.Location = new System.Drawing.Point(878, 14);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(281, 200);
            this.panel2.TabIndex = 29;
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(123)))), ((int)(((byte)(255)))));
            this.panel6.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel6.Location = new System.Drawing.Point(0, 0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(6, 200);
            this.panel6.TabIndex = 5;
            // 
            // lblTotalLote
            // 
            this.lblTotalLote.AutoSize = true;
            this.lblTotalLote.Font = new System.Drawing.Font("Microsoft Sans Serif", 40F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalLote.Location = new System.Drawing.Point(36, 21);
            this.lblTotalLote.Name = "lblTotalLote";
            this.lblTotalLote.Size = new System.Drawing.Size(179, 63);
            this.lblTotalLote.TabIndex = 2;
            this.lblTotalLote.Text = "label3";
            // 
            // btnMostrarLote
            // 
            this.btnMostrarLote.IconChar = FontAwesome.Sharp.IconChar.CircleInfo;
            this.btnMostrarLote.IconColor = System.Drawing.Color.White;
            this.btnMostrarLote.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnMostrarLote.IconSize = 35;
            this.btnMostrarLote.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMostrarLote.Location = new System.Drawing.Point(18, 148);
            this.btnMostrarLote.Name = "btnMostrarLote";
            this.btnMostrarLote.Size = new System.Drawing.Size(249, 40);
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
            this.label4.Location = new System.Drawing.Point(30, 84);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(88, 36);
            this.label4.TabIndex = 0;
            this.label4.Text = "Lotes";
            // 
            // container
            // 
            this.container.Controls.Add(this.chart3);
            this.container.Controls.Add(this.chart2);
            this.container.Controls.Add(this.panel9);
            this.container.Controls.Add(this.panel3);
            this.container.Controls.Add(this.panel2);
            this.container.Controls.Add(this.panel4);
            this.container.Controls.Add(this.panel1);
            this.container.Location = new System.Drawing.Point(10, 22);
            this.container.Name = "container";
            this.container.Size = new System.Drawing.Size(1174, 440);
            this.container.TabIndex = 30;
            // 
            // chart3
            // 
            chartArea2.Name = "ChartArea1";
            this.chart3.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.chart3.Legends.Add(legend2);
            this.chart3.Location = new System.Drawing.Point(649, 220);
            this.chart3.Name = "chart3";
            this.chart3.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Pastel;
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastLine;
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.chart3.Series.Add(series2);
            this.chart3.Size = new System.Drawing.Size(365, 200);
            this.chart3.TabIndex = 32;
            this.chart3.Text = "|||||";
            // 
            // chart2
            // 
            chartArea3.Name = "ChartArea1";
            this.chart2.ChartAreas.Add(chartArea3);
            legend3.Name = "Legend1";
            this.chart2.Legends.Add(legend3);
            this.chart2.Location = new System.Drawing.Point(303, 220);
            this.chart2.Name = "chart2";
            this.chart2.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Pastel;
            series3.ChartArea = "ChartArea1";
            series3.Legend = "Legend1";
            series3.Name = "Series1";
            this.chart2.Series.Add(series3);
            this.chart2.Size = new System.Drawing.Size(340, 200);
            this.chart2.TabIndex = 31;
            this.chart2.Text = "|||||";
            // 
            // panel9
            // 
            this.panel9.BackColor = System.Drawing.Color.White;
            this.panel9.Controls.Add(this.lblPorcentaj);
            this.panel9.Controls.Add(this.panel10);
            this.panel9.Controls.Add(this.lblPorcentaje);
            this.panel9.Controls.Add(this.label5);
            this.panel9.Location = new System.Drawing.Point(16, 220);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(281, 200);
            this.panel9.TabIndex = 30;
            // 
            // lblPorcentaj
            // 
            this.lblPorcentaj.AutoSize = true;
            this.lblPorcentaj.Font = new System.Drawing.Font("Microsoft Sans Serif", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPorcentaj.Location = new System.Drawing.Point(41, 156);
            this.lblPorcentaj.Name = "lblPorcentaj";
            this.lblPorcentaj.Size = new System.Drawing.Size(144, 36);
            this.lblPorcentaj.TabIndex = 5;
            this.lblPorcentaj.Text = "Contratos";
            // 
            // panel10
            // 
            this.panel10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(193)))), ((int)(((byte)(7)))));
            this.panel10.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel10.Location = new System.Drawing.Point(0, 0);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(6, 200);
            this.panel10.TabIndex = 5;
            // 
            // lblPorcentaje
            // 
            this.lblPorcentaje.AutoSize = true;
            this.lblPorcentaje.Font = new System.Drawing.Font("Microsoft Sans Serif", 40F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPorcentaje.Location = new System.Drawing.Point(36, 21);
            this.lblPorcentaje.Name = "lblPorcentaje";
            this.lblPorcentaje.Size = new System.Drawing.Size(179, 63);
            this.lblPorcentaje.TabIndex = 2;
            this.lblPorcentaje.Text = "label3";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(33, 84);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(165, 72);
            this.label5.TabIndex = 0;
            this.label5.Text = "Porcentaje \r\nde pagos";
            // 
            // frmDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1204, 800);
            this.Controls.Add(this.container);
            this.Controls.Add(this.chart1);
            this.Margin = new System.Windows.Forms.Padding(2);
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
            ((System.ComponentModel.ISupportInitialize)(this.chart3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart2)).EndInit();
            this.panel9.ResumeLayout(false);
            this.panel9.PerformLayout();
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
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Panel panel10;
        private System.Windows.Forms.Label lblPorcentaje;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblPorcentaj;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart2;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart3;
    }
}