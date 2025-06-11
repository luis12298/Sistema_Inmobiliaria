namespace SistemaInmobiliaria.Views
{
    partial class frmRecuperar
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtCorreo = new System.Windows.Forms.TextBox();
            this.btnEnviar = new FontAwesome.Sharp.IconButton();
            this.label2 = new System.Windows.Forms.Label();
            this.txtVerificar = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(205, 127);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(180, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Ingrese su correo electronico";
            // 
            // txtCorreo
            // 
            this.txtCorreo.Location = new System.Drawing.Point(58, 158);
            this.txtCorreo.Multiline = true;
            this.txtCorreo.Name = "txtCorreo";
            this.txtCorreo.Size = new System.Drawing.Size(510, 40);
            this.txtCorreo.TabIndex = 1;
            this.txtCorreo.TextChanged += new System.EventHandler(this.txtCorreo_TextChanged);
            // 
            // btnEnviar
            // 
            this.btnEnviar.IconChar = FontAwesome.Sharp.IconChar.None;
            this.btnEnviar.IconColor = System.Drawing.Color.Black;
            this.btnEnviar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnEnviar.Location = new System.Drawing.Point(189, 215);
            this.btnEnviar.Name = "btnEnviar";
            this.btnEnviar.Size = new System.Drawing.Size(206, 42);
            this.btnEnviar.TabIndex = 2;
            this.btnEnviar.Text = "Enviar codigo";
            this.btnEnviar.UseVisualStyleBackColor = true;
            this.btnEnviar.Click += new System.EventHandler(this.btnEnviar_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(415, 48);
            this.label2.TabIndex = 3;
            this.label2.Text = "Se enviará un el usuario y contraseña al correo registrado en la app, \r\nde lo con" +
    "trario no podra cambiar su contraseña,\r\ndeberá contactar al tecnico asignado.";
            // 
            // txtVerificar
            // 
            this.txtVerificar.Location = new System.Drawing.Point(45, 301);
            this.txtVerificar.Multiline = true;
            this.txtVerificar.Name = "txtVerificar";
            this.txtVerificar.Size = new System.Drawing.Size(510, 40);
            this.txtVerificar.TabIndex = 5;
            this.txtVerificar.Visible = false;
            this.txtVerificar.TextChanged += new System.EventHandler(this.txtVerificar_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(247, 271);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 16);
            this.label3.TabIndex = 4;
            this.label3.Text = "Verificar codigo";
            this.label3.Visible = false;
            // 
            // frmRecuperar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(632, 353);
            this.Controls.Add(this.txtVerificar);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnEnviar);
            this.Controls.Add(this.txtCorreo);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmRecuperar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Recuperar";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCorreo;
        private FontAwesome.Sharp.IconButton btnEnviar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtVerificar;
        private System.Windows.Forms.Label label3;
    }
}