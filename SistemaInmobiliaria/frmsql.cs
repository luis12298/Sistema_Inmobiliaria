using SistemaInmobiliaria.Connection;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaInmobiliaria
{
    public partial class frmsql : Form
    {
        Conexion conexion = new Conexion();
        private ContextMenuStrip treeContextMenu;
        private ToolStripMenuItem agregarColumna;
        private ToolStripMenuItem eliminarColumna;
        private ToolStripMenuItem editarColumna;
        public frmsql()
        {
            InitializeComponent();
            treeContextMenu = new ContextMenuStrip();
            agregarColumna = new ToolStripMenuItem("Agregar columna");
            eliminarColumna = new ToolStripMenuItem("Eliminar columna");
            editarColumna = new ToolStripMenuItem("Editar columna");
            eliminarColumna.Click += (s, e) =>
            {
                EliminarColumna_Click(this, e);
            };
            editarColumna.Click += (s, e) =>
            {
                EditarColumna_Click(this, e);
            };
            treeContextMenu.Items.AddRange(new ToolStripItem[] { agregarColumna, eliminarColumna, editarColumna });
            treeView1.ContextMenuStrip = treeContextMenu;
            CargarEstructuraBD();


            treeContextMenu.Items.AddRange(new ToolStripItem[] { agregarColumna, eliminarColumna });
            agregarColumna.Click += (s, e) =>
            {
                if (treeView1.SelectedNode != null && treeView1.SelectedNode.Nodes.Count > 0)
                {
                    string tabla = treeView1.SelectedNode.Text;
                    string query = $"ALTER TABLE [{tabla}] ADD [NuevaColumna] INT;";
                    txtQuery.Text = query;
                }
            };
            if (treeView1.SelectedNode != null && treeView1.SelectedNode.Parent != null)
            {
                string tabla = treeView1.SelectedNode.Parent.Text;
                string columna = treeView1.SelectedNode.Text.Split(' ')[0]; // nombre de la columna
                string query = $"ALTER TABLE [{tabla}] DROP COLUMN [{columna}];";
                txtQuery.Text = query;
            }

            txtQuery.KeyPress += (s, e) =>
            {
                e.KeyChar = Char.ToUpper(e.KeyChar);

            };


            // add column if not already present
            lvResultados.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);

        }

        private void CargarEstructuraBD()
        {
            treeView1.Nodes.Clear();

            try
            {
                using (SqlConnection sqlConnection = conexion.Open())
                {

                    // -----------------------------
                    // 1️⃣ Listar Tablas y Columnas
                    // -----------------------------
                    DataTable tablas = sqlConnection.GetSchema("Tables");

                    foreach (DataRow tabla in tablas.Rows)
                    {
                        string tableName = tabla["TABLE_NAME"].ToString();

                        TreeNode tableNode = new TreeNode(tableName)
                        {
                            ImageIndex = 0,
                            SelectedImageIndex = 0
                        };

                        // Columnas
                        DataTable columnas = sqlConnection.GetSchema("Columns", new string[] { null, null, tableName, null });
                        foreach (DataRow columna in columnas.Rows)
                        {
                            string columnName = columna["COLUMN_NAME"].ToString();
                            string columnType = columna["DATA_TYPE"].ToString();

                            string maxLength = "";
                            if (columnType.Equals("varchar", StringComparison.OrdinalIgnoreCase) ||
                                columnType.Equals("nvarchar", StringComparison.OrdinalIgnoreCase) ||
                                columnType.Equals("char", StringComparison.OrdinalIgnoreCase) ||
                                columnType.Equals("nchar", StringComparison.OrdinalIgnoreCase))
                            {
                                maxLength = columna["CHARACTER_MAXIMUM_LENGTH"].ToString();
                                columnType += $"({maxLength})";
                            }

                            TreeNode columnNode = new TreeNode($"{columnName} ({columnType})")
                            {
                                ImageIndex = 1,
                                SelectedImageIndex = 1
                            };
                            tableNode.Nodes.Add(columnNode);
                        }

                        treeView1.Nodes.Add(tableNode);
                    }

                    // -----------------------------
                    // 2️⃣ Listar Stored Procedures
                    // -----------------------------
                    TreeNode spRoot = new TreeNode("Stored Procedures")
                    {
                        ImageIndex = 0,
                        SelectedImageIndex = 0
                    };

                    string spQuery = "SELECT name FROM sys.objects WHERE type = 'P' ORDER BY name";
                    using (SqlCommand cmd = new SqlCommand(spQuery, sqlConnection))
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string spName = reader.GetString(0);
                            TreeNode spNode = new TreeNode(spName)
                            {
                                ImageIndex = 1,
                                SelectedImageIndex = 1,
                                Tag = spName
                            };
                            spRoot.Nodes.Add(spNode);
                        }
                    }

                    treeView1.Nodes.Add(spRoot);

                    sqlConnection.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar estructura: " + ex.Message);
            }
        }
        private void btnEjecutar_Click(object sender, EventArgs e)
        {
            string query = txtQuery.Text.Trim();
            if (string.IsNullOrEmpty(query))
            {
                MessageBox.Show("Escribe una consulta SQL.");
                return;
            }

            EjecutarQuery(query);

        }
        private void EjecutarQuery(string query)
        {
            try
            {
                lvResultados.Clear();

                using (SqlConnection sqlConnection = conexion.Open())
                {
                    using (SqlCommand cmd = new SqlCommand(query, sqlConnection))
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        // Crear columnas en el ListView según los nombres de columnas del reader
                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            lvResultados.Columns.Add(reader.GetName(i));
                        }

                        // Agregar filas
                        while (reader.Read())
                        {
                            string[] row = new string[reader.FieldCount];
                            for (int i = 0; i < reader.FieldCount; i++)
                            {
                                row[i] = reader[i].ToString();
                            }
                            ListViewItem item = new ListViewItem(row);
                            lvResultados.Items.Add(item);
                        }
                    }
                    sqlConnection.Close();
                }

                lvResultados.View = View.Details; // Mostrar columnas
                lvResultados.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al ejecutar query: " + ex.Message);
            }
        }

        private void treeView1_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node == null) return;

            // Verificar si es un Stored Procedure
            if (e.Node.Parent != null && e.Node.Parent.Text == "Stored Procedures")
            {
                string spName = e.Node.Tag.ToString();

                try
                {
                    using (SqlConnection sqlConnection = conexion.Open())
                    {
                        string getSPCode = @"
                    SELECT OBJECT_DEFINITION(OBJECT_ID(@spName)) AS Codigo";

                        using (SqlCommand cmd = new SqlCommand(getSPCode, sqlConnection))
                        {
                            cmd.Parameters.AddWithValue("@spName", spName);
                            string codigo = cmd.ExecuteScalar()?.ToString() ?? "No se pudo obtener el código.";
                            txtQuery.Text = codigo;
                        }

                        sqlConnection.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al obtener el código del SP: " + ex.Message);
                }

                return;
            }

            // -------------------
            // Tabla
            // -------------------
            if (e.Node.Nodes.Count > 0)
            {
                string tableName = e.Node.Text;
                txtQuery.Text = $"SELECT * FROM [{tableName}]";
            }
        }


        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtQuery.Clear();
            lvResultados.Clear();
        }

        private void treeView1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                TreeNode node = treeView1.GetNodeAt(e.X, e.Y);
                treeView1.SelectedNode = node;

                if (node != null)
                {
                    // Nodo de tabla
                    agregarColumna.Enabled = node.Nodes.Count > 0;

                    // Nodo de columna
                    eliminarColumna.Enabled = node.Parent != null && node.Parent.Nodes.Contains(node);
                    editarColumna.Enabled = node.Parent != null && node.Parent.Nodes.Contains(node);
                    treeContextMenu.Show(treeView1, e.Location);
                }
            }
            if (e.Button == MouseButtons.Right)
            {
                TreeNode node = treeView1.GetNodeAt(e.X, e.Y);
                treeView1.SelectedNode = node;

                if (node != null)
                {
                    // -------------------------------
                    // Solo mostrar menú en tablas y columnas
                    // -------------------------------
                    if (node.Parent != null && node.Parent.Text == "Stored Procedures")
                    {
                        // Nodo es SP → no mostrar menú
                        treeContextMenu.Hide();
                        return;
                    }

                    // Nodo de tabla (tiene hijos)
                    agregarColumna.Enabled = node.Nodes.Count > 0;

                    // Nodo de columna
                    eliminarColumna.Enabled = node.Parent != null && node.Parent.Nodes.Contains(node);
                    editarColumna.Enabled = node.Parent != null && node.Parent.Nodes.Contains(node);

                    treeContextMenu.Show(treeView1, e.Location);
                }
            }
        }
        private void AgregarColumna_Click(object sender, EventArgs e)
        {
            if (treeView1.SelectedNode != null && treeView1.SelectedNode.Nodes.Count > 0)
            {
                string tabla = treeView1.SelectedNode.Text;
                string query = $"ALTER TABLE [{tabla}] ADD [NuevaColumna] INT;";
                txtQuery.Text = query;
            }
        }

        // -----------------------------
        // Generar query: Eliminar columna
        // -----------------------------
        private void EliminarColumna_Click(object sender, EventArgs e)
        {
            if (treeView1.SelectedNode != null && treeView1.SelectedNode.Parent != null)
            {
                string tabla = treeView1.SelectedNode.Parent.Text;
                string columna = treeView1.SelectedNode.Text.Split(' ')[0];
                string query = $"ALTER TABLE [{tabla}] DROP COLUMN [{columna}];";
                txtQuery.Text = query;
            }
        }

        // -----------------------------
        // Generar query: Editar columna
        // -----------------------------
        private void EditarColumna_Click(object sender, EventArgs e)
        {
            if (treeView1.SelectedNode != null && treeView1.SelectedNode.Parent != null)
            {
                string tabla = treeView1.SelectedNode.Parent.Text;
                string nodoTexto = treeView1.SelectedNode.Text;
                int idx = nodoTexto.IndexOf('(');
                string columna = nodoTexto.Substring(0, idx).Trim();
                string tipo = nodoTexto.Substring(idx + 1, nodoTexto.Length - idx - 2).Trim();

                string query = $"ALTER TABLE [{tabla}] ALTER COLUMN [{columna}] {tipo};";
                txtQuery.Text = query;
            }
        }

        private void txtQuery_TextChanged(object sender, EventArgs e)
        {
            //MAYUSCULAS

        }
    }
}
