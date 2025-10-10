namespace SistemaInmobiliaria.Views
{
    partial class frmCobros
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
            this.label2 = new System.Windows.Forms.Label();
            this.dgvDatos2 = new System.Windows.Forms.DataGridView();
            this.btnWhatsApp = new FontAwesome.Sharp.IconButton();
            this.iconPictureBox2 = new FontAwesome.Sharp.IconPictureBox();
            this.txtFiltrar = new System.Windows.Forms.TextBox();
            this.dtpInicio = new System.Windows.Forms.DateTimePicker();
            this.dtpFinal = new System.Windows.Forms.DateTimePicker();
            this.btnEjecutar = new FontAwesome.Sharp.IconButton();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.iconButton1 = new FontAwesome.Sharp.IconButton();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatos2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(11, 39);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(143, 24);
            this.label2.TabIndex = 28;
            this.label2.Text = "Cobros del mes";
            // 
            // dgvDatos2
            // 
            this.dgvDatos2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvDatos2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDatos2.Location = new System.Drawing.Point(11, 121);
            this.dgvDatos2.Margin = new System.Windows.Forms.Padding(2);
            this.dgvDatos2.Name = "dgvDatos2";
            this.dgvDatos2.RowHeadersWidth = 51;
            this.dgvDatos2.RowTemplate.Height = 24;
            this.dgvDatos2.Size = new System.Drawing.Size(1154, 509);
            this.dgvDatos2.TabIndex = 27;
            this.dgvDatos2.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDatos2_CellClick);
            this.dgvDatos2.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvDatos2_CellMouseClick);
            // 
            // btnWhatsApp
            // 
            this.btnWhatsApp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnWhatsApp.IconChar = FontAwesome.Sharp.IconChar.Whatsapp;
            this.btnWhatsApp.IconColor = System.Drawing.Color.White;
            this.btnWhatsApp.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnWhatsApp.IconSize = 32;
            this.btnWhatsApp.Location = new System.Drawing.Point(1004, 71);
            this.btnWhatsApp.Margin = new System.Windows.Forms.Padding(2);
            this.btnWhatsApp.Name = "btnWhatsApp";
            this.btnWhatsApp.Size = new System.Drawing.Size(161, 40);
            this.btnWhatsApp.TabIndex = 29;
            this.btnWhatsApp.Text = "Whatsapp";
            this.btnWhatsApp.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnWhatsApp.UseVisualStyleBackColor = true;
            this.btnWhatsApp.Visible = false;
            this.btnWhatsApp.Click += new System.EventHandler(this.btnWhatsApp_Click);
            // 
            // iconPictureBox2
            // 
            this.iconPictureBox2.BackColor = System.Drawing.SystemColors.Control;
            this.iconPictureBox2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.iconPictureBox2.IconChar = FontAwesome.Sharp.IconChar.MagnifyingGlass;
            this.iconPictureBox2.IconColor = System.Drawing.SystemColors.ControlText;
            this.iconPictureBox2.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconPictureBox2.IconSize = 21;
            this.iconPictureBox2.Location = new System.Drawing.Point(19, 88);
            this.iconPictureBox2.Margin = new System.Windows.Forms.Padding(2);
            this.iconPictureBox2.Name = "iconPictureBox2";
            this.iconPictureBox2.Size = new System.Drawing.Size(21, 23);
            this.iconPictureBox2.TabIndex = 31;
            this.iconPictureBox2.TabStop = false;
            // 
            // txtFiltrar
            // 
            this.txtFiltrar.Location = new System.Drawing.Point(15, 78);
            this.txtFiltrar.Margin = new System.Windows.Forms.Padding(2);
            this.txtFiltrar.Multiline = true;
            this.txtFiltrar.Name = "txtFiltrar";
            this.txtFiltrar.Size = new System.Drawing.Size(449, 35);
            this.txtFiltrar.TabIndex = 30;
            this.txtFiltrar.TextChanged += new System.EventHandler(this.txtFiltrar_TextChanged);
            // 
            // dtpInicio
            // 
            this.dtpInicio.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpInicio.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpInicio.Location = new System.Drawing.Point(484, 88);
            this.dtpInicio.Name = "dtpInicio";
            this.dtpInicio.Size = new System.Drawing.Size(165, 23);
            this.dtpInicio.TabIndex = 32;
            // 
            // dtpFinal
            // 
            this.dtpFinal.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFinal.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFinal.Location = new System.Drawing.Point(668, 88);
            this.dtpFinal.Name = "dtpFinal";
            this.dtpFinal.Size = new System.Drawing.Size(165, 23);
            this.dtpFinal.TabIndex = 33;
            // 
            // btnEjecutar
            // 
            this.btnEjecutar.IconChar = FontAwesome.Sharp.IconChar.Exclamation;
            this.btnEjecutar.IconColor = System.Drawing.Color.White;
            this.btnEjecutar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnEjecutar.IconSize = 32;
            this.btnEjecutar.Location = new System.Drawing.Point(838, 75);
            this.btnEjecutar.Margin = new System.Windows.Forms.Padding(2);
            this.btnEjecutar.Name = "btnEjecutar";
            this.btnEjecutar.Size = new System.Drawing.Size(113, 40);
            this.btnEjecutar.TabIndex = 34;
            this.btnEjecutar.Text = "Ejecutar";
            this.btnEjecutar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnEjecutar.UseVisualStyleBackColor = true;
            this.btnEjecutar.Click += new System.EventHandler(this.btnEjecutar_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(1037, 642);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 18);
            this.label1.TabIndex = 35;
            this.label1.Text = "label1";
            this.label1.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(484, 69);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 36;
            this.label3.Text = "Desde";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(665, 71);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 37;
            this.label4.Text = "Hasta";
            // 
            // iconButton1
            // 
            this.iconButton1.IconChar = FontAwesome.Sharp.IconChar.ArrowAltCircleLeft;
            this.iconButton1.IconColor = System.Drawing.Color.Black;
            this.iconButton1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconButton1.IconSize = 25;
            this.iconButton1.Location = new System.Drawing.Point(15, 6);
            this.iconButton1.Name = "iconButton1";
            this.iconButton1.Size = new System.Drawing.Size(109, 30);
            this.iconButton1.TabIndex = 38;
            this.iconButton1.Text = "Regresar";
            this.iconButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.iconButton1.UseVisualStyleBackColor = true;
            this.iconButton1.Click += new System.EventHandler(this.iconButton1_Click);
            // 
            // frmCobros
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1176, 668);
            this.Controls.Add(this.iconButton1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnEjecutar);
            this.Controls.Add(this.dtpFinal);
            this.Controls.Add(this.dtpInicio);
            this.Controls.Add(this.iconPictureBox2);
            this.Controls.Add(this.txtFiltrar);
            this.Controls.Add(this.btnWhatsApp);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dgvDatos2);
            this.Name = "frmCobros";
            this.Text = "frmCobros";
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatos2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private FontAwesome.Sharp.IconButton btnWhatsApp;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgvDatos2;
        private FontAwesome.Sharp.IconPictureBox iconPictureBox2;
        private System.Windows.Forms.TextBox txtFiltrar;
        private System.Windows.Forms.DateTimePicker dtpInicio;
        private System.Windows.Forms.DateTimePicker dtpFinal;
        private FontAwesome.Sharp.IconButton btnEjecutar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private FontAwesome.Sharp.IconButton iconButton1;
    }
}