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
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatos2)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(11, 67);
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
            this.dgvDatos2.Size = new System.Drawing.Size(1154, 452);
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
            this.btnWhatsApp.Location = new System.Drawing.Point(1004, 67);
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
            // frmCobros
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1176, 603);
            this.Controls.Add(this.btnWhatsApp);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dgvDatos2);
            this.Name = "frmCobros";
            this.Text = "frmCobros";
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatos2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private FontAwesome.Sharp.IconButton btnWhatsApp;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgvDatos2;
    }
}