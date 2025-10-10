namespace SistemaInmobiliaria.Views
{
    partial class frmAtrasados
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
            this.dgvDatos = new System.Windows.Forms.DataGridView();
            this.lblTotal = new System.Windows.Forms.Label();
            this.btnRecordatorio = new FontAwesome.Sharp.IconButton();
            this.iconPictureBox2 = new FontAwesome.Sharp.IconPictureBox();
            this.txtFiltrar = new System.Windows.Forms.TextBox();
            this.btnWhatsApp = new FontAwesome.Sharp.IconButton();
            this.iconButton1 = new FontAwesome.Sharp.IconButton();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(7, 56);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(246, 24);
            this.label1.TabIndex = 27;
            this.label1.Text = "Clientes atrasados de pagos";
            // 
            // dgvDatos
            // 
            this.dgvDatos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvDatos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDatos.Location = new System.Drawing.Point(11, 137);
            this.dgvDatos.Margin = new System.Windows.Forms.Padding(2);
            this.dgvDatos.Name = "dgvDatos";
            this.dgvDatos.RowHeadersWidth = 51;
            this.dgvDatos.RowTemplate.Height = 24;
            this.dgvDatos.Size = new System.Drawing.Size(904, 506);
            this.dgvDatos.TabIndex = 26;
            this.dgvDatos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDatos_CellClick);
            this.dgvDatos.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvDatos_CellMouseClick);
            // 
            // lblTotal
            // 
            this.lblTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTotal.AutoSize = true;
            this.lblTotal.Location = new System.Drawing.Point(852, 680);
            this.lblTotal.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(35, 13);
            this.lblTotal.TabIndex = 29;
            this.lblTotal.Text = "label2";
            // 
            // btnRecordatorio
            // 
            this.btnRecordatorio.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRecordatorio.IconChar = FontAwesome.Sharp.IconChar.Bell;
            this.btnRecordatorio.IconColor = System.Drawing.Color.Black;
            this.btnRecordatorio.IconFont = FontAwesome.Sharp.IconFont.Solid;
            this.btnRecordatorio.IconSize = 32;
            this.btnRecordatorio.Location = new System.Drawing.Point(738, 94);
            this.btnRecordatorio.Margin = new System.Windows.Forms.Padding(2);
            this.btnRecordatorio.Name = "btnRecordatorio";
            this.btnRecordatorio.Size = new System.Drawing.Size(177, 40);
            this.btnRecordatorio.TabIndex = 28;
            this.btnRecordatorio.Text = "Ver Recordatorio";
            this.btnRecordatorio.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnRecordatorio.UseVisualStyleBackColor = true;
            this.btnRecordatorio.Visible = false;
            this.btnRecordatorio.Click += new System.EventHandler(this.btnRecordatorio_Click);
            // 
            // iconPictureBox2
            // 
            this.iconPictureBox2.BackColor = System.Drawing.SystemColors.Control;
            this.iconPictureBox2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.iconPictureBox2.IconChar = FontAwesome.Sharp.IconChar.MagnifyingGlass;
            this.iconPictureBox2.IconColor = System.Drawing.SystemColors.ControlText;
            this.iconPictureBox2.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconPictureBox2.IconSize = 21;
            this.iconPictureBox2.Location = new System.Drawing.Point(15, 104);
            this.iconPictureBox2.Margin = new System.Windows.Forms.Padding(2);
            this.iconPictureBox2.Name = "iconPictureBox2";
            this.iconPictureBox2.Size = new System.Drawing.Size(21, 23);
            this.iconPictureBox2.TabIndex = 31;
            this.iconPictureBox2.TabStop = false;
            // 
            // txtFiltrar
            // 
            this.txtFiltrar.Location = new System.Drawing.Point(11, 94);
            this.txtFiltrar.Margin = new System.Windows.Forms.Padding(2);
            this.txtFiltrar.Multiline = true;
            this.txtFiltrar.Name = "txtFiltrar";
            this.txtFiltrar.Size = new System.Drawing.Size(449, 35);
            this.txtFiltrar.TabIndex = 30;
            this.txtFiltrar.TextChanged += new System.EventHandler(this.txtFiltrar_TextChanged);
            // 
            // btnWhatsApp
            // 
            this.btnWhatsApp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnWhatsApp.IconChar = FontAwesome.Sharp.IconChar.Whatsapp;
            this.btnWhatsApp.IconColor = System.Drawing.Color.White;
            this.btnWhatsApp.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnWhatsApp.IconSize = 32;
            this.btnWhatsApp.Location = new System.Drawing.Point(573, 93);
            this.btnWhatsApp.Margin = new System.Windows.Forms.Padding(2);
            this.btnWhatsApp.Name = "btnWhatsApp";
            this.btnWhatsApp.Size = new System.Drawing.Size(161, 40);
            this.btnWhatsApp.TabIndex = 32;
            this.btnWhatsApp.Text = "Whatsapp";
            this.btnWhatsApp.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnWhatsApp.UseVisualStyleBackColor = true;
            this.btnWhatsApp.Visible = false;
            this.btnWhatsApp.Click += new System.EventHandler(this.btnWhatsApp_Click);
            // 
            // iconButton1
            // 
            this.iconButton1.IconChar = FontAwesome.Sharp.IconChar.ArrowAltCircleLeft;
            this.iconButton1.IconColor = System.Drawing.Color.Black;
            this.iconButton1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconButton1.IconSize = 25;
            this.iconButton1.Location = new System.Drawing.Point(15, 12);
            this.iconButton1.Name = "iconButton1";
            this.iconButton1.Size = new System.Drawing.Size(109, 30);
            this.iconButton1.TabIndex = 39;
            this.iconButton1.Text = "Regresar";
            this.iconButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.iconButton1.UseVisualStyleBackColor = true;
            this.iconButton1.Click += new System.EventHandler(this.iconButton1_Click);
            // 
            // frmAtrasados
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(926, 714);
            this.Controls.Add(this.iconButton1);
            this.Controls.Add(this.btnWhatsApp);
            this.Controls.Add(this.iconPictureBox2);
            this.Controls.Add(this.txtFiltrar);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.btnRecordatorio);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvDatos);
            this.Name = "frmAtrasados";
            this.Text = "frmAtrasados";
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private FontAwesome.Sharp.IconButton btnRecordatorio;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvDatos;
        private System.Windows.Forms.Label lblTotal;
        private FontAwesome.Sharp.IconPictureBox iconPictureBox2;
        private System.Windows.Forms.TextBox txtFiltrar;
        private FontAwesome.Sharp.IconButton btnWhatsApp;
        private FontAwesome.Sharp.IconButton iconButton1;
    }
}