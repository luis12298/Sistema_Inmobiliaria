namespace SistemaInmobiliaria.Views
{
    partial class frmLote
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnCancelar = new FontAwesome.Sharp.IconButton();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbEstado = new System.Windows.Forms.ComboBox();
            this.btnMostrar = new FontAwesome.Sharp.IconButton();
            this.btnEliminar = new FontAwesome.Sharp.IconButton();
            this.btnActualizar = new FontAwesome.Sharp.IconButton();
            this.btnNuevo = new FontAwesome.Sharp.IconButton();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.txtPrecio = new System.Windows.Forms.TextBox();
            this.txtVaras = new System.Windows.Forms.TextBox();
            this.txtMetros = new System.Windows.Forms.TextBox();
            this.txtNo = new System.Windows.Forms.TextBox();
            this.lsvDatos = new System.Windows.Forms.ListView();
            this.lblTotalRegistros = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCerrar = new FontAwesome.Sharp.IconButton();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.btnCancelar);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.cmbEstado);
            this.groupBox1.Controls.Add(this.btnMostrar);
            this.groupBox1.Controls.Add(this.btnEliminar);
            this.groupBox1.Controls.Add(this.btnActualizar);
            this.groupBox1.Controls.Add(this.btnNuevo);
            this.groupBox1.Controls.Add(this.txtDescripcion);
            this.groupBox1.Controls.Add(this.txtPrecio);
            this.groupBox1.Controls.Add(this.txtVaras);
            this.groupBox1.Controls.Add(this.txtMetros);
            this.groupBox1.Controls.Add(this.txtNo);
            this.groupBox1.Location = new System.Drawing.Point(12, 52);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(840, 274);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Nuevo lote";
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancelar.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnCancelar.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnCancelar.IconChar = FontAwesome.Sharp.IconChar.Ban;
            this.btnCancelar.IconColor = System.Drawing.Color.White;
            this.btnCancelar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnCancelar.IconSize = 30;
            this.btnCancelar.Location = new System.Drawing.Point(420, 233);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(134, 35);
            this.btnCancelar.TabIndex = 12;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(376, 109);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 16);
            this.label2.TabIndex = 11;
            this.label2.Text = "Estado";
            // 
            // cmbEstado
            // 
            this.cmbEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEstado.FormattingEnabled = true;
            this.cmbEstado.Location = new System.Drawing.Point(379, 128);
            this.cmbEstado.Name = "cmbEstado";
            this.cmbEstado.Size = new System.Drawing.Size(154, 24);
            this.cmbEstado.TabIndex = 10;
            // 
            // btnMostrar
            // 
            this.btnMostrar.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.btnMostrar.IconChar = FontAwesome.Sharp.IconChar.Binoculars;
            this.btnMostrar.IconColor = System.Drawing.Color.Black;
            this.btnMostrar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnMostrar.IconSize = 30;
            this.btnMostrar.Location = new System.Drawing.Point(180, 233);
            this.btnMostrar.Name = "btnMostrar";
            this.btnMostrar.Size = new System.Drawing.Size(167, 35);
            this.btnMostrar.TabIndex = 9;
            this.btnMostrar.Text = "Mostrar listado";
            this.btnMostrar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnMostrar.UseVisualStyleBackColor = false;
            this.btnMostrar.Click += new System.EventHandler(this.btnMostrar_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEliminar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this.btnEliminar.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnEliminar.IconChar = FontAwesome.Sharp.IconChar.FileCircleXmark;
            this.btnEliminar.IconColor = System.Drawing.Color.White;
            this.btnEliminar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnEliminar.IconSize = 30;
            this.btnEliminar.Location = new System.Drawing.Point(700, 233);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(134, 35);
            this.btnEliminar.TabIndex = 8;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnEliminar.UseVisualStyleBackColor = false;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnActualizar
            // 
            this.btnActualizar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnActualizar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(202)))), ((int)(((byte)(240)))));
            this.btnActualizar.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnActualizar.IconChar = FontAwesome.Sharp.IconChar.FilePen;
            this.btnActualizar.IconColor = System.Drawing.Color.White;
            this.btnActualizar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnActualizar.IconSize = 30;
            this.btnActualizar.Location = new System.Drawing.Point(560, 233);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(134, 35);
            this.btnActualizar.TabIndex = 7;
            this.btnActualizar.Text = "Actualizar";
            this.btnActualizar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnActualizar.UseVisualStyleBackColor = false;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // btnNuevo
            // 
            this.btnNuevo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(110)))), ((int)(((byte)(253)))));
            this.btnNuevo.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnNuevo.IconChar = FontAwesome.Sharp.IconChar.FileArchive;
            this.btnNuevo.IconColor = System.Drawing.Color.White;
            this.btnNuevo.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnNuevo.IconSize = 30;
            this.btnNuevo.Location = new System.Drawing.Point(20, 233);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(154, 35);
            this.btnNuevo.TabIndex = 6;
            this.btnNuevo.Text = "Nuevo Lote";
            this.btnNuevo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnNuevo.UseVisualStyleBackColor = false;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Location = new System.Drawing.Point(20, 182);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(352, 22);
            this.txtDescripcion.TabIndex = 5;
            // 
            // txtPrecio
            // 
            this.txtPrecio.Location = new System.Drawing.Point(20, 119);
            this.txtPrecio.Name = "txtPrecio";
            this.txtPrecio.Size = new System.Drawing.Size(352, 22);
            this.txtPrecio.TabIndex = 3;
            // 
            // txtVaras
            // 
            this.txtVaras.Location = new System.Drawing.Point(366, 51);
            this.txtVaras.Name = "txtVaras";
            this.txtVaras.ReadOnly = true;
            this.txtVaras.Size = new System.Drawing.Size(167, 22);
            this.txtVaras.TabIndex = 2;
            // 
            // txtMetros
            // 
            this.txtMetros.Location = new System.Drawing.Point(193, 51);
            this.txtMetros.Name = "txtMetros";
            this.txtMetros.Size = new System.Drawing.Size(167, 22);
            this.txtMetros.TabIndex = 1;
            this.txtMetros.TextChanged += new System.EventHandler(this.txtMetros_TextChanged);
            this.txtMetros.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMetros_KeyPress);
            // 
            // txtNo
            // 
            this.txtNo.Location = new System.Drawing.Point(20, 51);
            this.txtNo.Name = "txtNo";
            this.txtNo.Size = new System.Drawing.Size(167, 22);
            this.txtNo.TabIndex = 0;
            this.txtNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNo_KeyPress);
            // 
            // lsvDatos
            // 
            this.lsvDatos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lsvDatos.FullRowSelect = true;
            this.lsvDatos.GridLines = true;
            this.lsvDatos.HideSelection = false;
            this.lsvDatos.Location = new System.Drawing.Point(12, 343);
            this.lsvDatos.Name = "lsvDatos";
            this.lsvDatos.Size = new System.Drawing.Size(840, 326);
            this.lsvDatos.TabIndex = 1;
            this.lsvDatos.UseCompatibleStateImageBehavior = false;
            this.lsvDatos.View = System.Windows.Forms.View.Details;
            this.lsvDatos.DoubleClick += new System.EventHandler(this.lsvDatos_DoubleClick);
            // 
            // lblTotalRegistros
            // 
            this.lblTotalRegistros.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTotalRegistros.AutoSize = true;
            this.lblTotalRegistros.Location = new System.Drawing.Point(780, 677);
            this.lblTotalRegistros.Name = "lblTotalRegistros";
            this.lblTotalRegistros.Size = new System.Drawing.Size(68, 16);
            this.lblTotalRegistros.TabIndex = 6;
            this.lblTotalRegistros.Text = "Registros:";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(679, 677);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 16);
            this.label1.TabIndex = 5;
            this.label1.Text = "Registros:";
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
            this.btnCerrar.Location = new System.Drawing.Point(804, 12);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(48, 48);
            this.btnCerrar.TabIndex = 18;
            this.btnCerrar.UseVisualStyleBackColor = false;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // frmLote
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(858, 714);
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.lblTotalRegistros);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lsvDatos);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmLote";
            this.Text = "Lotes";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListView lsvDatos;
        private System.Windows.Forms.Label lblTotalRegistros;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.TextBox txtPrecio;
        private System.Windows.Forms.TextBox txtVaras;
        private System.Windows.Forms.TextBox txtMetros;
        private System.Windows.Forms.TextBox txtNo;
        private FontAwesome.Sharp.IconButton btnNuevo;
        private FontAwesome.Sharp.IconButton btnEliminar;
        private FontAwesome.Sharp.IconButton btnActualizar;
        private FontAwesome.Sharp.IconButton btnMostrar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbEstado;
        private FontAwesome.Sharp.IconButton btnCancelar;
        private FontAwesome.Sharp.IconButton btnCerrar;
    }
}