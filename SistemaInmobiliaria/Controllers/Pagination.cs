using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace SistemaInmobiliaria.Controllers
{
    public class PaginationManager
    {
        private DataTable _fullData;
        private int _currentPage = 1;
        private int _pageSize;
        private DataGridView _dgv;
        private Panel _paginationPanel;
        private Label _totalPagesLabel;
        private TextBox _pageNumberTextBox;

        public void Setup(DataGridView dgv, DataTable data, Control container, int pageSize)

        {
            _pageSize = pageSize;
            _dgv = dgv;
            _fullData = data;
            CreatePaginationControls(container);
            UpdateView();
        }

        private void CreatePaginationControls(Control container)
        {
            _paginationPanel = new Panel
            {
                Dock = DockStyle.Bottom,
                Height = 30,

            };

            // Contenedor principal con FlowLayoutPanel para el estilo de navegador
            var flowPanel = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                FlowDirection = FlowDirection.LeftToRight,
                WrapContents = false,
                AutoSize = true,
                AutoSizeMode = AutoSizeMode.GrowAndShrink
            };

            // Botón Primera Página (doble flecha izquierda)
            var btnFirst = CreateNavigationButton("⏪", "Primera página");
            btnFirst.Click += (s, e) => GoToPage(1);

            // Botón Anterior (flecha izquierda)
            var btnPrevious = CreateNavigationButton("◀️", "Página anterior");
            btnPrevious.Click += (s, e) => ChangePage(-1);

            // TextBox para número de página actual
            _pageNumberTextBox = new TextBox
            {
                Text = "1",
                Width = 40,
                Height = 22,
                TextAlign = HorizontalAlignment.Center,
                Margin = new Padding(2),
                AccessibleDescription = "Número de página actual"
            };
            _pageNumberTextBox.KeyPress += (s, e) =>
            {
                // Solo permitir números y tecla de control
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }

                // Si presiona Enter, navegar a la página
                if (e.KeyChar == (char)Keys.Enter)
                {
                    e.Handled = true;
                    ProcessPageNumberInput();
                }
            };
            _pageNumberTextBox.Leave += (s, e) => ProcessPageNumberInput();

            // Label "of X" para total de páginas
            _totalPagesLabel = new Label
            {
                Text = $"of {TotalPages}",
                AutoSize = true,
                Font = new Font("Segoe UI", 9, FontStyle.Regular),
                TextAlign = ContentAlignment.MiddleCenter,
                Margin = new Padding(2, 5, 2, 0)
            };

            // Botón Siguiente (flecha derecha)
            var btnNext = CreateNavigationButton("▶️", "Página siguiente");
            btnNext.Click += (s, e) => ChangePage(1);

            // Botón Última Página (doble flecha derecha)
            var btnLast = CreateNavigationButton("⏩", "Última página");
            btnLast.Click += (s, e) => GoToPage(TotalPages);

            // Agregar todos los controles al panel de flujo
            flowPanel.Controls.Add(btnFirst);
            flowPanel.Controls.Add(btnPrevious);
            flowPanel.Controls.Add(_pageNumberTextBox);
            flowPanel.Controls.Add(_totalPagesLabel);
            flowPanel.Controls.Add(btnNext);
            flowPanel.Controls.Add(btnLast);

            // Centrar horizontalmente el panel de flujo
            var containerPanel = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 3,
                RowCount = 1
            };

            containerPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50));
            containerPanel.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
            containerPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50));

            containerPanel.Controls.Add(new Panel(), 0, 0); // Espaciador izquierdo
            containerPanel.Controls.Add(flowPanel, 1, 0); // Panel con controles de paginación
            containerPanel.Controls.Add(new Panel(), 2, 0); // Espaciador derecho

            _paginationPanel.Controls.Add(containerPanel);
            container.Controls.Add(_paginationPanel);
        }

        private void ProcessPageNumberInput()
        {
            if (int.TryParse(_pageNumberTextBox.Text, out int pageNumber))
            {
                // Validar que la página esté dentro del rango válido
                if (pageNumber >= 1 && pageNumber <= TotalPages)
                {
                    GoToPage(pageNumber);
                }
                else
                {
                    // Si el número está fuera de rango, restablecer al valor actual
                    _pageNumberTextBox.Text = _currentPage.ToString();
                }
            }
            else
            {
                // Si el texto no es un número válido, restablecer al valor actual
                _pageNumberTextBox.Text = _currentPage.ToString();
            }
        }

        private Button CreateNavigationButton(string text, string tooltip)
        {
            return new Button
            {
                Text = text,
                Size = new Size(25, 30),
                Font = new Font("Segoe UI", 8, FontStyle.Regular),
                Margin = new Padding(0, 0, 0, 5),
                Padding = new Padding(0),
                FlatStyle = FlatStyle.Flat,
                FlatAppearance = { BorderSize = 0 },
                Cursor = Cursors.Hand,
                AccessibleDescription = tooltip
            };
        }

        private void ChangePage(int direction)
        {
            int newPage = _currentPage + direction;
            if (newPage >= 1 && newPage <= TotalPages)
            {
                _currentPage = newPage;
                UpdateView();
            }
        }

        private void GoToPage(int pageNumber)
        {
            if (pageNumber >= 1 && pageNumber <= TotalPages)
            {
                _currentPage = pageNumber;
                UpdateView();
            }
        }

        private void UpdateView()
        {
            try
            {
                if (_fullData.Rows.Count > 0)
                {
                    var pageData = _fullData.AsEnumerable()
                        .Skip((_currentPage - 1) * _pageSize)
                        .Take(_pageSize);

                    if (pageData.Any())
                    {
                        _dgv.DataSource = pageData.CopyToDataTable();
                    }
                    else
                    {
                        // Si no hay datos para esta página, volver a la primera
                        _currentPage = 1;
                        _dgv.DataSource = _fullData.AsEnumerable()
                            .Take(_pageSize)
                            .CopyToDataTable();
                    }
                }
                else
                {
                    _dgv.DataSource = _fullData.Clone(); // Mostrar tabla vacía
                }

                // Actualizar controles de navegación
                _pageNumberTextBox.Text = _currentPage.ToString();
                _totalPagesLabel.Text = $"of {TotalPages}";

                // Obtener los botones de navegación para habilitar/deshabilitar
                var buttons = _paginationPanel.Controls[0].Controls[1].Controls.OfType<Button>().ToList();
                buttons.ForEach(b => b.Cursor = Cursors.Hand);
                if (buttons.Count >= 4)
                {
                    buttons[0].Enabled = _currentPage > 1;       // Primera
                    buttons[1].Enabled = _currentPage > 1;       // Anterior
                    buttons[2].Enabled = _currentPage < TotalPages; // Siguiente
                    buttons[3].Enabled = _currentPage < TotalPages; // Última
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al paginar: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private int TotalPages => _fullData.Rows.Count == 0 ? 1 : (int)Math.Ceiling((double)_fullData.Rows.Count / _pageSize);
    }
}