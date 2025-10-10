namespace SistemaInmobiliaria
{
    partial class frmSettings
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
            this.txtMensajeW = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtMensaje = new System.Windows.Forms.TextBox();
            this.txtRutaLogo = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnCargar = new FontAwesome.Sharp.IconButton();
            this.label4 = new System.Windows.Forms.Label();
            this.txtLicenciaFirebase = new System.Windows.Forms.TextBox();
            this.btnGuardar = new FontAwesome.Sharp.IconButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtCorreo = new System.Windows.Forms.TextBox();
            this.txtTelefono = new System.Windows.Forms.TextBox();
            this.txtDireccion = new System.Windows.Forms.TextBox();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.txtFirma = new System.Windows.Forms.TextBox();
            this.btnCargar2 = new FontAwesome.Sharp.IconButton();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtMensajeW
            // 
            this.txtMensajeW.Location = new System.Drawing.Point(12, 48);
            this.txtMensajeW.Multiline = true;
            this.txtMensajeW.Name = "txtMensajeW";
            this.txtMensajeW.Size = new System.Drawing.Size(580, 100);
            this.txtMensajeW.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(231, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Mensaje de Whatsapp [Cliente],[Fecha],[Cuota]";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 163);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(323, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Mensaje de recordatorio, ejemplo [Cliente],[Cuota],[Fecha],[Cuenta]";
            // 
            // txtMensaje
            // 
            this.txtMensaje.Location = new System.Drawing.Point(12, 182);
            this.txtMensaje.Multiline = true;
            this.txtMensaje.Name = "txtMensaje";
            this.txtMensaje.Size = new System.Drawing.Size(580, 100);
            this.txtMensaje.TabIndex = 2;
            // 
            // txtRutaLogo
            // 
            this.txtRutaLogo.Location = new System.Drawing.Point(16, 322);
            this.txtRutaLogo.Name = "txtRutaLogo";
            this.txtRutaLogo.Size = new System.Drawing.Size(437, 20);
            this.txtRutaLogo.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 297);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Logo prinicipal";
            // 
            // btnCargar
            // 
            this.btnCargar.IconChar = FontAwesome.Sharp.IconChar.None;
            this.btnCargar.IconColor = System.Drawing.Color.Black;
            this.btnCargar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnCargar.Location = new System.Drawing.Point(459, 322);
            this.btnCargar.Name = "btnCargar";
            this.btnCargar.Size = new System.Drawing.Size(110, 35);
            this.btnCargar.TabIndex = 6;
            this.btnCargar.Text = "Cargar";
            this.btnCargar.UseVisualStyleBackColor = true;
            this.btnCargar.Click += new System.EventHandler(this.btnCargar_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 371);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(123, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Nombre licencia firebase";
            // 
            // txtLicenciaFirebase
            // 
            this.txtLicenciaFirebase.Location = new System.Drawing.Point(16, 399);
            this.txtLicenciaFirebase.Name = "txtLicenciaFirebase";
            this.txtLicenciaFirebase.Size = new System.Drawing.Size(437, 20);
            this.txtLicenciaFirebase.TabIndex = 7;
            // 
            // btnGuardar
            // 
            this.btnGuardar.IconChar = FontAwesome.Sharp.IconChar.None;
            this.btnGuardar.IconColor = System.Drawing.Color.Black;
            this.btnGuardar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnGuardar.Location = new System.Drawing.Point(183, 749);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(213, 42);
            this.btnGuardar.TabIndex = 9;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnCargar2);
            this.groupBox1.Controls.Add(this.txtFirma);
            this.groupBox1.Controls.Add(this.txtCorreo);
            this.groupBox1.Controls.Add(this.txtTelefono);
            this.groupBox1.Controls.Add(this.txtDireccion);
            this.groupBox1.Controls.Add(this.txtNombre);
            this.groupBox1.Location = new System.Drawing.Point(16, 453);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(576, 290);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Encabezado";
            // 
            // txtCorreo
            // 
            this.txtCorreo.Location = new System.Drawing.Point(6, 205);
            this.txtCorreo.Name = "txtCorreo";
            this.txtCorreo.Size = new System.Drawing.Size(437, 20);
            this.txtCorreo.TabIndex = 11;
            // 
            // txtTelefono
            // 
            this.txtTelefono.Location = new System.Drawing.Point(6, 152);
            this.txtTelefono.Name = "txtTelefono";
            this.txtTelefono.Size = new System.Drawing.Size(437, 20);
            this.txtTelefono.TabIndex = 10;
            // 
            // txtDireccion
            // 
            this.txtDireccion.Location = new System.Drawing.Point(6, 102);
            this.txtDireccion.Name = "txtDireccion";
            this.txtDireccion.Size = new System.Drawing.Size(437, 20);
            this.txtDireccion.TabIndex = 9;
            this.txtDireccion.TextChanged += new System.EventHandler(this.txtDireccion_TextChanged);
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(6, 53);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(437, 20);
            this.txtNombre.TabIndex = 8;
            // 
            // txtFirma
            // 
            this.txtFirma.Location = new System.Drawing.Point(6, 250);
            this.txtFirma.Name = "txtFirma";
            this.txtFirma.Size = new System.Drawing.Size(437, 20);
            this.txtFirma.TabIndex = 12;
            // 
            // btnCargar2
            // 
            this.btnCargar2.IconChar = FontAwesome.Sharp.IconChar.None;
            this.btnCargar2.IconColor = System.Drawing.Color.Black;
            this.btnCargar2.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnCargar2.Location = new System.Drawing.Point(449, 250);
            this.btnCargar2.Name = "btnCargar2";
            this.btnCargar2.Size = new System.Drawing.Size(110, 35);
            this.btnCargar2.TabIndex = 13;
            this.btnCargar2.Text = "Cargar";
            this.btnCargar2.UseVisualStyleBackColor = true;
            this.btnCargar2.Click += new System.EventHandler(this.btnCargar2_Click);
            // 
            // frmSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(604, 803);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtLicenciaFirebase);
            this.Controls.Add(this.btnCargar);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtRutaLogo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtMensaje);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtMensajeW);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSettings";
            this.Text = "Configuraciones";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtMensajeW;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtMensaje;
        private System.Windows.Forms.TextBox txtRutaLogo;
        private System.Windows.Forms.Label label3;
        private FontAwesome.Sharp.IconButton btnCargar;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtLicenciaFirebase;
        private FontAwesome.Sharp.IconButton btnGuardar;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtDireccion;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.TextBox txtCorreo;
        private System.Windows.Forms.TextBox txtTelefono;
        private System.Windows.Forms.TextBox txtFirma;
        private FontAwesome.Sharp.IconButton btnCargar2;
    }
}