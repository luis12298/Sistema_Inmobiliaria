namespace SistemaInmobiliaria.Views
{
    partial class frmVerListaContrato
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
            this.lsvDatos = new System.Windows.Forms.ListView();
            this.txtFiltrar = new System.Windows.Forms.TextBox();
            this.iconPictureBox1 = new FontAwesome.Sharp.IconPictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lsvDatos
            // 
            this.lsvDatos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lsvDatos.FullRowSelect = true;
            this.lsvDatos.GridLines = true;
            this.lsvDatos.HideSelection = false;
            this.lsvDatos.Location = new System.Drawing.Point(12, 152);
            this.lsvDatos.Name = "lsvDatos";
            this.lsvDatos.Size = new System.Drawing.Size(776, 340);
            this.lsvDatos.TabIndex = 0;
            this.lsvDatos.UseCompatibleStateImageBehavior = false;
            // 
            // txtFiltrar
            // 
            this.txtFiltrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFiltrar.Location = new System.Drawing.Point(12, 91);
            this.txtFiltrar.Multiline = true;
            this.txtFiltrar.Name = "txtFiltrar";
            this.txtFiltrar.Size = new System.Drawing.Size(385, 40);
            this.txtFiltrar.TabIndex = 1;
            this.txtFiltrar.TextChanged += new System.EventHandler(this.txtFiltrar_TextChanged);
            // 
            // iconPictureBox1
            // 
            this.iconPictureBox1.BackColor = System.Drawing.Color.White;
            this.iconPictureBox1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.iconPictureBox1.IconChar = FontAwesome.Sharp.IconChar.MagnifyingGlass;
            this.iconPictureBox1.IconColor = System.Drawing.SystemColors.ControlText;
            this.iconPictureBox1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconPictureBox1.IconSize = 30;
            this.iconPictureBox1.Location = new System.Drawing.Point(13, 95);
            this.iconPictureBox1.Name = "iconPictureBox1";
            this.iconPictureBox1.Size = new System.Drawing.Size(30, 30);
            this.iconPictureBox1.TabIndex = 2;
            this.iconPictureBox1.TabStop = false;
            // 
            // frmVerListaContrato
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 557);
            this.Controls.Add(this.iconPictureBox1);
            this.Controls.Add(this.txtFiltrar);
            this.Controls.Add(this.lsvDatos);
            this.MinimizeBox = false;
            this.Name = "frmVerListaContrato";
            this.Text = "Lista de contratos";
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lsvDatos;
        private System.Windows.Forms.TextBox txtFiltrar;
        private FontAwesome.Sharp.IconPictureBox iconPictureBox1;
    }
}