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
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbTotal = new System.Windows.Forms.ComboBox();
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
            this.label1.Location = new System.Drawing.Point(817, 530);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Registros:";
            // 
            // lblTotalRegistros
            // 
            this.lblTotalRegistros.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTotalRegistros.AutoSize = true;
            this.lblTotalRegistros.Location = new System.Drawing.Point(892, 530);
            this.lblTotalRegistros.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTotalRegistros.Name = "lblTotalRegistros";
            this.lblTotalRegistros.Size = new System.Drawing.Size(54, 13);
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
            this.panel2.Location = new System.Drawing.Point(11, 138);
            this.panel2.Margin = new System.Windows.Forms.Padding(2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(946, 40);
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
            this.btnEditarContrato.Location = new System.Drawing.Point(727, -1);
            this.btnEditarContrato.Margin = new System.Windows.Forms.Padding(2);
            this.btnEditarContrato.Name = "btnEditarContrato";
            this.btnEditarContrato.Size = new System.Drawing.Size(112, 40);
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
            this.btnEliminarContrato.Location = new System.Drawing.Point(843, -1);
            this.btnEliminarContrato.Margin = new System.Windows.Forms.Padding(2);
            this.btnEliminarContrato.Name = "btnEliminarContrato";
            this.btnEliminarContrato.Size = new System.Drawing.Size(99, 40);
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
            this.btnNuevoContrato.Location = new System.Drawing.Point(796, 1);
            this.btnNuevoContrato.Margin = new System.Windows.Forms.Padding(2);
            this.btnNuevoContrato.Name = "btnNuevoContrato";
            this.btnNuevoContrato.Size = new System.Drawing.Size(145, 40);
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
            this.panel1.Location = new System.Drawing.Point(11, 39);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(943, 40);
            this.panel1.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 11);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(108, 13);
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
            this.btnCerrar.Location = new System.Drawing.Point(917, -1);
            this.btnCerrar.Margin = new System.Windows.Forms.Padding(2);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(36, 39);
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
            this.dgvDatos.Location = new System.Drawing.Point(11, 182);
            this.dgvDatos.Margin = new System.Windows.Forms.Padding(2);
            this.dgvDatos.Name = "dgvDatos";
            this.dgvDatos.RowHeadersWidth = 51;
            this.dgvDatos.RowTemplate.Height = 24;
            this.dgvDatos.Size = new System.Drawing.Size(942, 270);
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
            this.panel3.Location = new System.Drawing.Point(11, 457);
            this.panel3.Margin = new System.Windows.Forms.Padding(2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(943, 70);
            this.panel3.TabIndex = 20;
            // 
            // txtProyeccion
            // 
            this.txtProyeccion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtProyeccion.Location = new System.Drawing.Point(808, 42);
            this.txtProyeccion.Margin = new System.Windows.Forms.Padding(2);
            this.txtProyeccion.Name = "txtProyeccion";
            this.txtProyeccion.ReadOnly = true;
            this.txtProyeccion.Size = new System.Drawing.Size(126, 20);
            this.txtProyeccion.TabIndex = 0;
            // 
            // panel4
            // 
            this.panel4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel4.Controls.Add(this.label3);
            this.panel4.Controls.Add(this.label4);
            this.panel4.Controls.Add(this.cmbTotal);
            this.panel4.Controls.Add(this.iconPictureBox2);
            this.panel4.Controls.Add(this.txtFiltrar);
            this.panel4.Location = new System.Drawing.Point(11, 80);
            this.panel4.Margin = new System.Windows.Forms.Padding(2);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(943, 50);
            this.panel4.TabIndex = 21;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(880, 21);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 13);
            this.label3.TabIndex = 14;
            this.label3.Text = "Entradas";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(712, 21);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "Mostrar";
            // 
            // cmbTotal
            // 
            this.cmbTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbTotal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTotal.FormattingEnabled = true;
            this.cmbTotal.Items.AddRange(new object[] {
            "2",
            "10",
            "25",
            "50",
            "100",
            "Todos"});
            this.cmbTotal.Location = new System.Drawing.Point(757, 19);
            this.cmbTotal.Margin = new System.Windows.Forms.Padding(2);
            this.cmbTotal.Name = "cmbTotal";
            this.cmbTotal.Size = new System.Drawing.Size(121, 21);
            this.cmbTotal.TabIndex = 12;
            this.cmbTotal.SelectedIndexChanged += new System.EventHandler(this.cmbTotal_SelectedIndexChanged);
            // 
            // iconPictureBox2
            // 
            this.iconPictureBox2.BackColor = System.Drawing.SystemColors.Control;
            this.iconPictureBox2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.iconPictureBox2.IconChar = FontAwesome.Sharp.IconChar.MagnifyingGlass;
            this.iconPictureBox2.IconColor = System.Drawing.SystemColors.ControlText;
            this.iconPictureBox2.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconPictureBox2.IconSize = 21;
            this.iconPictureBox2.Location = new System.Drawing.Point(14, 19);
            this.iconPictureBox2.Margin = new System.Windows.Forms.Padding(2);
            this.iconPictureBox2.Name = "iconPictureBox2";
            this.iconPictureBox2.Size = new System.Drawing.Size(21, 23);
            this.iconPictureBox2.TabIndex = 11;
            this.iconPictureBox2.TabStop = false;
            this.iconPictureBox2.Click += new System.EventHandler(this.iconPictureBox2_Click);
            // 
            // txtFiltrar
            // 
            this.txtFiltrar.Location = new System.Drawing.Point(10, 9);
            this.txtFiltrar.Margin = new System.Windows.Forms.Padding(2);
            this.txtFiltrar.Multiline = true;
            this.txtFiltrar.Name = "txtFiltrar";
            this.txtFiltrar.Size = new System.Drawing.Size(449, 35);
            this.txtFiltrar.TabIndex = 10;
            this.txtFiltrar.TextChanged += new System.EventHandler(this.txtFiltrar_TextChanged_1);
            // 
            // frmListaContrato
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(963, 550);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.dgvDatos);
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.lblTotalRegistros);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(2);
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
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbTotal;
    }
}