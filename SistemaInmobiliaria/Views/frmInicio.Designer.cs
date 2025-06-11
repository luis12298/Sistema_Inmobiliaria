namespace SistemaInmobiliaria.Views
{
    partial class frmInicio
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.clientesToolStripMenuItem = new FontAwesome.Sharp.IconMenuItem();
            this.verClientesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.registrarClienteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contratosToolStripMenuItem = new FontAwesome.Sharp.IconMenuItem();
            this.registrarContratoToolStripMenuItem = new FontAwesome.Sharp.IconMenuItem();
            this.registrarContratoToolStripMenuItem1 = new FontAwesome.Sharp.IconMenuItem();
            this.cobrarToolStripMenuItem = new FontAwesome.Sharp.IconMenuItem();
            this.lotesYViviendaToolStripMenuItem = new FontAwesome.Sharp.IconMenuItem();
            this.registrarLoteOTerrenoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.verLotesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.calculadoraToolStripMenuItem = new FontAwesome.Sharp.IconMenuItem();
            this.calculadoraDeCuotasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.usuariosToolStripMenuItem = new FontAwesome.Sharp.IconMenuItem();
            this.agregarUsuarioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.agregarCorreoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reportesToolStripMenuItem = new FontAwesome.Sharp.IconMenuItem();
            this.verReporteGeneralToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Main = new System.Windows.Forms.Panel();
            this.menuStrip2 = new System.Windows.Forms.MenuStrip();
            this.iconMenuItem1 = new FontAwesome.Sharp.IconMenuItem();
            this.userLog = new FontAwesome.Sharp.IconMenuItem();
            this.toolStripMenuItem2 = new FontAwesome.Sharp.IconMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblHora = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.menuStrip2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clientesToolStripMenuItem,
            this.contratosToolStripMenuItem,
            this.lotesYViviendaToolStripMenuItem,
            this.calculadoraToolStripMenuItem,
            this.usuariosToolStripMenuItem,
            this.reportesToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(9, 9);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(832, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // clientesToolStripMenuItem
            // 
            this.clientesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.verClientesToolStripMenuItem,
            this.registrarClienteToolStripMenuItem});
            this.clientesToolStripMenuItem.IconChar = FontAwesome.Sharp.IconChar.UserGroup;
            this.clientesToolStripMenuItem.IconColor = System.Drawing.Color.Black;
            this.clientesToolStripMenuItem.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.clientesToolStripMenuItem.Name = "clientesToolStripMenuItem";
            this.clientesToolStripMenuItem.Size = new System.Drawing.Size(95, 24);
            this.clientesToolStripMenuItem.Text = "Clientes";
            // 
            // verClientesToolStripMenuItem
            // 
            this.verClientesToolStripMenuItem.Name = "verClientesToolStripMenuItem";
            this.verClientesToolStripMenuItem.Size = new System.Drawing.Size(201, 26);
            this.verClientesToolStripMenuItem.Text = "Ver clientes";
            this.verClientesToolStripMenuItem.Click += new System.EventHandler(this.verClientesToolStripMenuItem_Click);
            // 
            // registrarClienteToolStripMenuItem
            // 
            this.registrarClienteToolStripMenuItem.Name = "registrarClienteToolStripMenuItem";
            this.registrarClienteToolStripMenuItem.Size = new System.Drawing.Size(201, 26);
            this.registrarClienteToolStripMenuItem.Text = "Registrar Cliente";
            this.registrarClienteToolStripMenuItem.Click += new System.EventHandler(this.registrarClienteToolStripMenuItem_Click);
            // 
            // contratosToolStripMenuItem
            // 
            this.contratosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.registrarContratoToolStripMenuItem,
            this.registrarContratoToolStripMenuItem1,
            this.cobrarToolStripMenuItem});
            this.contratosToolStripMenuItem.IconChar = FontAwesome.Sharp.IconChar.FileSignature;
            this.contratosToolStripMenuItem.IconColor = System.Drawing.Color.Black;
            this.contratosToolStripMenuItem.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.contratosToolStripMenuItem.Name = "contratosToolStripMenuItem";
            this.contratosToolStripMenuItem.Size = new System.Drawing.Size(107, 24);
            this.contratosToolStripMenuItem.Text = "Contratos";
            // 
            // registrarContratoToolStripMenuItem
            // 
            this.registrarContratoToolStripMenuItem.IconChar = FontAwesome.Sharp.IconChar.FileContract;
            this.registrarContratoToolStripMenuItem.IconColor = System.Drawing.Color.Black;
            this.registrarContratoToolStripMenuItem.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.registrarContratoToolStripMenuItem.Name = "registrarContratoToolStripMenuItem";
            this.registrarContratoToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.registrarContratoToolStripMenuItem.Text = "Ver contratos";
            this.registrarContratoToolStripMenuItem.Click += new System.EventHandler(this.registrarContratoToolStripMenuItem_Click);
            // 
            // registrarContratoToolStripMenuItem1
            // 
            this.registrarContratoToolStripMenuItem1.IconChar = FontAwesome.Sharp.IconChar.FilePen;
            this.registrarContratoToolStripMenuItem1.IconColor = System.Drawing.Color.Black;
            this.registrarContratoToolStripMenuItem1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.registrarContratoToolStripMenuItem1.Name = "registrarContratoToolStripMenuItem1";
            this.registrarContratoToolStripMenuItem1.Size = new System.Drawing.Size(224, 26);
            this.registrarContratoToolStripMenuItem1.Text = "Registrar contrato";
            this.registrarContratoToolStripMenuItem1.Click += new System.EventHandler(this.registrarContratoToolStripMenuItem1_Click);
            // 
            // cobrarToolStripMenuItem
            // 
            this.cobrarToolStripMenuItem.IconChar = FontAwesome.Sharp.IconChar.MoneyBillTransfer;
            this.cobrarToolStripMenuItem.IconColor = System.Drawing.Color.Black;
            this.cobrarToolStripMenuItem.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.cobrarToolStripMenuItem.Name = "cobrarToolStripMenuItem";
            this.cobrarToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.cobrarToolStripMenuItem.Text = "Tramites";
            this.cobrarToolStripMenuItem.Click += new System.EventHandler(this.cobrarToolStripMenuItem_Click);
            // 
            // lotesYViviendaToolStripMenuItem
            // 
            this.lotesYViviendaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.registrarLoteOTerrenoToolStripMenuItem,
            this.verLotesToolStripMenuItem});
            this.lotesYViviendaToolStripMenuItem.IconChar = FontAwesome.Sharp.IconChar.Map;
            this.lotesYViviendaToolStripMenuItem.IconColor = System.Drawing.Color.Black;
            this.lotesYViviendaToolStripMenuItem.IconFont = FontAwesome.Sharp.IconFont.Solid;
            this.lotesYViviendaToolStripMenuItem.Name = "lotesYViviendaToolStripMenuItem";
            this.lotesYViviendaToolStripMenuItem.Size = new System.Drawing.Size(149, 24);
            this.lotesYViviendaToolStripMenuItem.Text = "Lotes o terrenos";
            // 
            // registrarLoteOTerrenoToolStripMenuItem
            // 
            this.registrarLoteOTerrenoToolStripMenuItem.Name = "registrarLoteOTerrenoToolStripMenuItem";
            this.registrarLoteOTerrenoToolStripMenuItem.Size = new System.Drawing.Size(246, 26);
            this.registrarLoteOTerrenoToolStripMenuItem.Text = "Registrar lote o terreno";
            this.registrarLoteOTerrenoToolStripMenuItem.Click += new System.EventHandler(this.registrarLoteOTerrenoToolStripMenuItem_Click);
            // 
            // verLotesToolStripMenuItem
            // 
            this.verLotesToolStripMenuItem.Name = "verLotesToolStripMenuItem";
            this.verLotesToolStripMenuItem.Size = new System.Drawing.Size(246, 26);
            this.verLotesToolStripMenuItem.Text = "Ver lotes";
            this.verLotesToolStripMenuItem.Click += new System.EventHandler(this.verLotesToolStripMenuItem_Click);
            // 
            // calculadoraToolStripMenuItem
            // 
            this.calculadoraToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.calculadoraDeCuotasToolStripMenuItem});
            this.calculadoraToolStripMenuItem.IconChar = FontAwesome.Sharp.IconChar.Calculator;
            this.calculadoraToolStripMenuItem.IconColor = System.Drawing.Color.Black;
            this.calculadoraToolStripMenuItem.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.calculadoraToolStripMenuItem.Name = "calculadoraToolStripMenuItem";
            this.calculadoraToolStripMenuItem.Size = new System.Drawing.Size(122, 24);
            this.calculadoraToolStripMenuItem.Text = "Calculadora";
            // 
            // calculadoraDeCuotasToolStripMenuItem
            // 
            this.calculadoraDeCuotasToolStripMenuItem.Name = "calculadoraDeCuotasToolStripMenuItem";
            this.calculadoraDeCuotasToolStripMenuItem.Size = new System.Drawing.Size(239, 26);
            this.calculadoraDeCuotasToolStripMenuItem.Text = "Calculadora de cuotas";
            this.calculadoraDeCuotasToolStripMenuItem.Click += new System.EventHandler(this.calculadoraDeCuotasToolStripMenuItem_Click);
            // 
            // usuariosToolStripMenuItem
            // 
            this.usuariosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.agregarUsuarioToolStripMenuItem,
            this.agregarCorreoToolStripMenuItem});
            this.usuariosToolStripMenuItem.IconChar = FontAwesome.Sharp.IconChar.UserGear;
            this.usuariosToolStripMenuItem.IconColor = System.Drawing.Color.Black;
            this.usuariosToolStripMenuItem.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.usuariosToolStripMenuItem.Name = "usuariosToolStripMenuItem";
            this.usuariosToolStripMenuItem.Size = new System.Drawing.Size(99, 24);
            this.usuariosToolStripMenuItem.Text = "Usuarios";
            // 
            // agregarUsuarioToolStripMenuItem
            // 
            this.agregarUsuarioToolStripMenuItem.Name = "agregarUsuarioToolStripMenuItem";
            this.agregarUsuarioToolStripMenuItem.Size = new System.Drawing.Size(198, 26);
            this.agregarUsuarioToolStripMenuItem.Text = "Agregar usuario";
            this.agregarUsuarioToolStripMenuItem.Click += new System.EventHandler(this.agregarUsuarioToolStripMenuItem_Click);
            // 
            // agregarCorreoToolStripMenuItem
            // 
            this.agregarCorreoToolStripMenuItem.Name = "agregarCorreoToolStripMenuItem";
            this.agregarCorreoToolStripMenuItem.Size = new System.Drawing.Size(198, 26);
            this.agregarCorreoToolStripMenuItem.Text = "Agregar correo";
            this.agregarCorreoToolStripMenuItem.Click += new System.EventHandler(this.agregarCorreoToolStripMenuItem_Click);
            // 
            // reportesToolStripMenuItem
            // 
            this.reportesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.verReporteGeneralToolStripMenuItem});
            this.reportesToolStripMenuItem.IconChar = FontAwesome.Sharp.IconChar.ChartColumn;
            this.reportesToolStripMenuItem.IconColor = System.Drawing.Color.Black;
            this.reportesToolStripMenuItem.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.reportesToolStripMenuItem.Name = "reportesToolStripMenuItem";
            this.reportesToolStripMenuItem.Size = new System.Drawing.Size(102, 24);
            this.reportesToolStripMenuItem.Text = "Reportes";
            // 
            // verReporteGeneralToolStripMenuItem
            // 
            this.verReporteGeneralToolStripMenuItem.Name = "verReporteGeneralToolStripMenuItem";
            this.verReporteGeneralToolStripMenuItem.Size = new System.Drawing.Size(220, 26);
            this.verReporteGeneralToolStripMenuItem.Text = "Ver reporte general";
            this.verReporteGeneralToolStripMenuItem.Click += new System.EventHandler(this.verReporteGeneralToolStripMenuItem_Click);
            // 
            // Main
            // 
            this.Main.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Main.Location = new System.Drawing.Point(13, 40);
            this.Main.Name = "Main";
            this.Main.Size = new System.Drawing.Size(1360, 507);
            this.Main.TabIndex = 1;
            // 
            // menuStrip2
            // 
            this.menuStrip2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.menuStrip2.BackColor = System.Drawing.Color.Transparent;
            this.menuStrip2.Dock = System.Windows.Forms.DockStyle.None;
            this.menuStrip2.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.iconMenuItem1});
            this.menuStrip2.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            this.menuStrip2.Location = new System.Drawing.Point(1265, 9);
            this.menuStrip2.Name = "menuStrip2";
            this.menuStrip2.Size = new System.Drawing.Size(99, 28);
            this.menuStrip2.TabIndex = 2;
            this.menuStrip2.Text = "menuStrip2";
            // 
            // iconMenuItem1
            // 
            this.iconMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.userLog,
            this.toolStripMenuItem2});
            this.iconMenuItem1.IconChar = FontAwesome.Sharp.IconChar.UserTie;
            this.iconMenuItem1.IconColor = System.Drawing.Color.Black;
            this.iconMenuItem1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconMenuItem1.Name = "iconMenuItem1";
            this.iconMenuItem1.Size = new System.Drawing.Size(93, 24);
            this.iconMenuItem1.Text = "Usuario";
            // 
            // userLog
            // 
            this.userLog.IconChar = FontAwesome.Sharp.IconChar.User;
            this.userLog.IconColor = System.Drawing.Color.Black;
            this.userLog.IconFont = FontAwesome.Sharp.IconFont.Solid;
            this.userLog.Name = "userLog";
            this.userLog.Size = new System.Drawing.Size(204, 26);
            this.userLog.Text = "User";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.IconChar = FontAwesome.Sharp.IconChar.RightFromBracket;
            this.toolStripMenuItem2.IconColor = System.Drawing.Color.Black;
            this.toolStripMenuItem2.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.toolStripMenuItem2.Size = new System.Drawing.Size(204, 26);
            this.toolStripMenuItem2.Text = "Cerrar aplicación";
            this.toolStripMenuItem2.Click += new System.EventHandler(this.toolStripMenuItem2_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.lblHora);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(13, 553);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1360, 54);
            this.panel1.TabIndex = 3;
            // 
            // lblHora
            // 
            this.lblHora.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblHora.AutoSize = true;
            this.lblHora.Location = new System.Drawing.Point(1224, 13);
            this.lblHora.Name = "lblHora";
            this.lblHora.Size = new System.Drawing.Size(44, 16);
            this.lblHora.TabIndex = 2;
            this.lblHora.Text = "label3";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(179, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "label2";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(149, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Derechos reservados ©";
            // 
            // frmInicio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1385, 619);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip2);
            this.Controls.Add(this.Main);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmInicio";
            this.Text = "Inicio";
            this.Load += new System.EventHandler(this.frmInicio_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.menuStrip2.ResumeLayout(false);
            this.menuStrip2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.Panel Main;
        private FontAwesome.Sharp.IconMenuItem clientesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem verClientesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem registrarClienteToolStripMenuItem;
        private FontAwesome.Sharp.IconMenuItem contratosToolStripMenuItem;
        private FontAwesome.Sharp.IconMenuItem registrarContratoToolStripMenuItem;
        private FontAwesome.Sharp.IconMenuItem registrarContratoToolStripMenuItem1;
        private FontAwesome.Sharp.IconMenuItem cobrarToolStripMenuItem;
        private FontAwesome.Sharp.IconMenuItem lotesYViviendaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem registrarLoteOTerrenoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem verLotesToolStripMenuItem;
        private FontAwesome.Sharp.IconMenuItem calculadoraToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem calculadoraDeCuotasToolStripMenuItem;
        private System.Windows.Forms.MenuStrip menuStrip2;
        private FontAwesome.Sharp.IconMenuItem iconMenuItem1;
        private FontAwesome.Sharp.IconMenuItem userLog;
        private FontAwesome.Sharp.IconMenuItem toolStripMenuItem2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblHora;
        private FontAwesome.Sharp.IconMenuItem usuariosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem agregarUsuarioToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem agregarCorreoToolStripMenuItem;
        private FontAwesome.Sharp.IconMenuItem reportesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem verReporteGeneralToolStripMenuItem;
    }
}