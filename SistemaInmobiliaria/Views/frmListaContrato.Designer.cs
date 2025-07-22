namespace SistemaInmobiliaria.Views
{
    partial class frmListaContrato
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
            this.lblTotalRegistros = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnEditarContrato = new FontAwesome.Sharp.IconButton();
            this.btnEliminarContrato = new FontAwesome.Sharp.IconButton();
            this.btnNuevoContrato = new FontAwesome.Sharp.IconButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.btnCerrar = new FontAwesome.Sharp.IconButton();
            this.dgvDatos = new System.Windows.Forms.DataGridView();
            this.panel3 = new System.Windows.Forms.Panel();
            this.txtProyeccion = new System.Windows.Forms.TextBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.iconPictureBox2 = new FontAwesome.Sharp.IconPictureBox();
            this.txtFiltrar = new System.Windows.Forms.TextBox();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatos)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1089, 652);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 16);
            this.label1.TabIndex = 3;
            this.label1.Text = "Registros:";
            // 
            // lblTotalRegistros
            // 
            this.lblTotalRegistros.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTotalRegistros.AutoSize = true;
            this.lblTotalRegistros.Location = new System.Drawing.Point(1190, 652);
            this.lblTotalRegistros.Name = "lblTotalRegistros";
            this.lblTotalRegistros.Size = new System.Drawing.Size(68, 16);
            this.lblTotalRegistros.TabIndex = 4;
            this.lblTotalRegistros.Text = "Registros:";
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.btnEditarContrato);
            this.panel2.Controls.Add(this.btnEliminarContrato);
            this.panel2.Location = new System.Drawing.Point(12, 132);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1260, 41);
            this.panel2.TabIndex = 5;
            // 
            // btnEditarContrato
            // 
            this.btnEditarContrato.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEditarContrato.BackColor = System.Drawing.Color.Teal;
            this.btnEditarContrato.ForeColor = System.Drawing.Color.White;
            this.btnEditarContrato.IconChar = FontAwesome.Sharp.IconChar.FilePen;
            this.btnEditarContrato.IconColor = System.Drawing.Color.White;
            this.btnEditarContrato.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnEditarContrato.IconSize = 30;
            this.btnEditarContrato.Location = new System.Drawing.Point(1048, 2);
            this.btnEditarContrato.Name = "btnEditarContrato";
            this.btnEditarContrato.Size = new System.Drawing.Size(92, 35);
            this.btnEditarContrato.TabIndex = 3;
            this.btnEditarContrato.Text = "Editar";
            this.btnEditarContrato.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnEditarContrato.UseVisualStyleBackColor = false;
            this.btnEditarContrato.Click += new System.EventHandler(this.btnEditarContrato_Click);
            // 
            // btnEliminarContrato
            // 
            this.btnEliminarContrato.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEliminarContrato.BackColor = System.Drawing.Color.Red;
            this.btnEliminarContrato.ForeColor = System.Drawing.Color.White;
            this.btnEliminarContrato.IconChar = FontAwesome.Sharp.IconChar.FileCircleXmark;
            this.btnEliminarContrato.IconColor = System.Drawing.Color.White;
            this.btnEliminarContrato.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnEliminarContrato.IconSize = 30;
            this.btnEliminarContrato.Location = new System.Drawing.Point(1146, 2);
            this.btnEliminarContrato.Name = "btnEliminarContrato";
            this.btnEliminarContrato.Size = new System.Drawing.Size(109, 35);
            this.btnEliminarContrato.TabIndex = 4;
            this.btnEliminarContrato.Text = "Eliminar";
            this.btnEliminarContrato.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnEliminarContrato.UseVisualStyleBackColor = false;
            this.btnEliminarContrato.Click += new System.EventHandler(this.btnEliminarContrato_Click);
            // 
            // btnNuevoContrato
            // 
            this.btnNuevoContrato.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNuevoContrato.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(229)))), ((int)(((byte)(250)))));
            this.btnNuevoContrato.FlatAppearance.BorderSize = 0;
            this.btnNuevoContrato.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnNuevoContrato.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNuevoContrato.IconChar = FontAwesome.Sharp.IconChar.FileCirclePlus;
            this.btnNuevoContrato.IconColor = System.Drawing.Color.White;
            this.btnNuevoContrato.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnNuevoContrato.IconSize = 30;
            this.btnNuevoContrato.Location = new System.Drawing.Point(1061, 1);
            this.btnNuevoContrato.Name = "btnNuevoContrato";
            this.btnNuevoContrato.Size = new System.Drawing.Size(193, 40);
            this.btnNuevoContrato.TabIndex = 0;
            this.btnNuevoContrato.Text = "Nuevo contrato";
            this.btnNuevoContrato.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnNuevoContrato.UseVisualStyleBackColor = false;
            this.btnNuevoContrato.Click += new System.EventHandler(this.btnNuevoContrato_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.btnNuevoContrato);
            this.panel1.Location = new System.Drawing.Point(15, 48);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1257, 40);
            this.panel1.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(135, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Listados de contratos";
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
            this.btnCerrar.Location = new System.Drawing.Point(1223, -1);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(48, 48);
            this.btnCerrar.TabIndex = 18;
            this.btnCerrar.UseVisualStyleBackColor = false;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // dgvDatos
            // 
            this.dgvDatos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvDatos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDatos.Location = new System.Drawing.Point(15, 179);
            this.dgvDatos.Name = "dgvDatos";
            this.dgvDatos.RowHeadersWidth = 51;
            this.dgvDatos.RowTemplate.Height = 24;
            this.dgvDatos.Size = new System.Drawing.Size(1256, 378);
            this.dgvDatos.TabIndex = 19;
            this.dgvDatos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDatos_CellClick);
            this.dgvDatos.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvDatos_CellFormatting);
            this.dgvDatos.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvDatos_CellMouseClick);
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.Controls.Add(this.txtProyeccion);
            this.panel3.Location = new System.Drawing.Point(15, 563);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1257, 86);
            this.panel3.TabIndex = 20;
            // 
            // txtProyeccion
            // 
            this.txtProyeccion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtProyeccion.Location = new System.Drawing.Point(1077, 52);
            this.txtProyeccion.Name = "txtProyeccion";
            this.txtProyeccion.ReadOnly = true;
            this.txtProyeccion.Size = new System.Drawing.Size(167, 22);
            this.txtProyeccion.TabIndex = 0;
            // 
            // panel4
            // 
            this.panel4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel4.Controls.Add(this.iconPictureBox2);
            this.panel4.Controls.Add(this.txtFiltrar);
            this.panel4.Location = new System.Drawing.Point(15, 90);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1257, 40);
            this.panel4.TabIndex = 21;
            // 
            // iconPictureBox2
            // 
            this.iconPictureBox2.BackColor = System.Drawing.SystemColors.Control;
            this.iconPictureBox2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.iconPictureBox2.IconChar = FontAwesome.Sharp.IconChar.MagnifyingGlass;
            this.iconPictureBox2.IconColor = System.Drawing.SystemColors.ControlText;
            this.iconPictureBox2.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconPictureBox2.IconSize = 28;
            this.iconPictureBox2.Location = new System.Drawing.Point(5, 7);
            this.iconPictureBox2.Name = "iconPictureBox2";
            this.iconPictureBox2.Size = new System.Drawing.Size(28, 28);
            this.iconPictureBox2.TabIndex = 11;
            this.iconPictureBox2.TabStop = false;
            // 
            // txtFiltrar
            // 
            this.txtFiltrar.Location = new System.Drawing.Point(3, 3);
            this.txtFiltrar.Multiline = true;
            this.txtFiltrar.Name = "txtFiltrar";
            this.txtFiltrar.Size = new System.Drawing.Size(597, 32);
            this.txtFiltrar.TabIndex = 10;
            this.txtFiltrar.TextChanged += new System.EventHandler(this.txtFiltrar_TextChanged_1);
            // 
            // frmListaContrato
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1284, 677);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.dgvDatos);
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.lblTotalRegistros);
            this.Controls.Add(this.label1);
            this.Name = "frmListaContrato";
            this.Text = "Listado contratos";
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatos)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private FontAwesome.Sharp.IconButton btnNuevoContrato;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblTotalRegistros;
        private System.Windows.Forms.Panel panel2;
        private FontAwesome.Sharp.IconButton btnEditarContrato;
        private FontAwesome.Sharp.IconButton btnEliminarContrato;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private FontAwesome.Sharp.IconButton btnCerrar;
        private System.Windows.Forms.DataGridView dgvDatos;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox txtProyeccion;
        private System.Windows.Forms.Panel panel4;
        private FontAwesome.Sharp.IconPictureBox iconPictureBox2;
        private System.Windows.Forms.TextBox txtFiltrar;
    }
}