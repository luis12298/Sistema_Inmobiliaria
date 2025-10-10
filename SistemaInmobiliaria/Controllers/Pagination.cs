using FontAwesome.Sharp;
using System;
using System.Collections.Generic;
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
        private Label _showingEntriesLabel;

        public void Setup(DataGridView dgv, DataTable data, Control container, int pageSize)
        {
            _dgv = dgv;
            _fullData = data;
            _pageSize = pageSize;

            if (_paginationPanel == null)
            {
                CreatePaginationControls(container);
            }

            _currentPage = 1;
            UpdateView();
        }

        public void UpdatePageSize(int newPageSize)
        {
            if (newPageSize <= 0) return;

            _pageSize = newPageSize;
            _currentPage = 1;
            UpdateView();
        }

        private void CreatePaginationControls(Control container)
        {
            _paginationPanel = new Panel
            {
                Dock = DockStyle.Bottom,
                Height = 50,
                Padding = new Padding(5)

            };

            var flowPanel = new FlowLayoutPanel
            {
                Dock = DockStyle.Right,            // Dock a la derecha
                FlowDirection = FlowDirection.RightToLeft, // Controles de derecha a izquierda
                WrapContents = false,
                AutoSize = true,
                AutoSizeMode = AutoSizeMode.GrowAndShrink,
                Padding = new Padding(0),
                Margin = new Padding(0),
                RightToLeft = RightToLeft.Yes     // Importante para ordenar bien los controles
            };
            // Label mostrando rango "Mostrando X a Y de Z entradas"
            _showingEntriesLabel = new Label
            {
                AutoSize = true,
                Font = new Font("Segoe UI", 9),
                ForeColor = Color.DimGray,
                Margin = new Padding(5, 12, 15, 0),
                Text = "Mostrando 0 a 0 de 0 entradas"
            };
            flowPanel.Controls.Add(_showingEntriesLabel);

            var btnFirst = CreateNavigationButton(IconChar.AngleDoubleLeft, "Primera página");
            btnFirst.Click += (s, e) => GoToPage(1);

            var btnPrevious = CreateNavigationButton(IconChar.AngleLeft, "Página anterior");
            btnPrevious.Click += (s, e) => ChangePage(-1);

            _pageNumberTextBox = new TextBox
            {
                Text = "1",
                Font = new Font("Segoe UI", 9),
                Width = 40,
                Height = 25,
                TextAlign = HorizontalAlignment.Center,
                Margin = new Padding(5, 6, 5, 6),
                BorderStyle = BorderStyle.FixedSingle,
                BackColor = Color.White,
                ForeColor = Color.Blue,
            };
            _pageNumberTextBox.KeyPress += (s, e) =>
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                    e.Handled = true;

                if (e.KeyChar == (char)Keys.Enter)
                {
                    e.Handled = true;
                    ProcessPageNumberInput();
                }
            };
            _pageNumberTextBox.Leave += (s, e) => ProcessPageNumberInput();

            _totalPagesLabel = new Label
            {
                Text = $"de {TotalPages}",
                AutoSize = true,
                Font = new Font("Segoe UI", 9),
                ForeColor = Color.DimGray,
                Margin = new Padding(0, 8, 10, 0),
            };

            var btnNext = CreateNavigationButton(IconChar.AngleRight, "Página siguiente");
            btnNext.Click += (s, e) => ChangePage(1);

            var btnLast = CreateNavigationButton(IconChar.AngleDoubleRight, "Última página");
            btnLast.Click += (s, e) => GoToPage(TotalPages);

            // Label para total de registros
            var totalRecordsLabel = new Label
            {
                Text = $"Total registros: {_fullData.Rows.Count}",
                AutoSize = true,
                Font = new Font("Segoe UI", 9, FontStyle.Bold),
                ForeColor = Color.FromArgb(60, 60, 60),
                Margin = new Padding(15, 8, 0, 0),
                Name = "lblTotalRecords"
            };

            // Agregar controles al flowPanel

            flowPanel.Controls.Add(btnFirst);
            flowPanel.Controls.Add(btnPrevious);
            flowPanel.Controls.Add(_pageNumberTextBox);
            flowPanel.Controls.Add(_totalPagesLabel);
            flowPanel.Controls.Add(btnNext);
            flowPanel.Controls.Add(btnLast);
            flowPanel.Controls.Add(totalRecordsLabel);

            var containerPanel = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 3,
                RowCount = 1,
            };

            containerPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50));
            containerPanel.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
            containerPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50));

            containerPanel.Controls.Add(new Panel(), 0, 0);
            containerPanel.Controls.Add(flowPanel, 1, 0);
            containerPanel.Controls.Add(new Panel(), 2, 0);

            _paginationPanel.Controls.Add(containerPanel);
            container.Controls.Add(_paginationPanel);
        }

        private void ProcessPageNumberInput()
        {
            if (int.TryParse(_pageNumberTextBox.Text, out int pageNumber))
            {
                if (pageNumber >= 1 && pageNumber <= TotalPages)
                {
                    GoToPage(pageNumber);
                }
                else
                {
                    _pageNumberTextBox.Text = _currentPage.ToString();
                }
            }
            else
            {
                _pageNumberTextBox.Text = _currentPage.ToString();
            }
        }

        private IconButton CreateNavigationButton(IconChar iconChar, string tooltip)
        {
            var btn = new IconButton
            {
                IconChar = iconChar,
                IconSize = 20,
                Size = new Size(32, 32),
                Font = new Font("Segoe UI", 11, FontStyle.Bold),
                Margin = new Padding(2),
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand,
                AccessibleDescription = tooltip,
                BackColor = Color.White,
                ForeColor = Color.FromArgb(33, 150, 243) // azul tipo primary
            };

            btn.FlatAppearance.BorderSize = 1;
            btn.FlatAppearance.BorderColor = Color.FromArgb(33, 150, 243);
            btn.FlatAppearance.MouseOverBackColor = Color.FromArgb(220, 235, 252);
            btn.FlatAppearance.MouseDownBackColor = Color.FromArgb(200, 220, 245);

            return btn;
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

                    _dgv.DataSource = pageData.Any()
                        ? pageData.CopyToDataTable()
                        : _fullData.Clone();
                }
                else
                {
                    _dgv.DataSource = _fullData.Clone();
                }

                _pageNumberTextBox.Text = _currentPage.ToString();
                _totalPagesLabel.Text = $"de {TotalPages}";

                var buttons = _paginationPanel.Controls[0].Controls[1].Controls.OfType<Button>().ToList();
                if (buttons.Count >= 4)
                {
                    buttons[0].Enabled = _currentPage > 1;
                    buttons[1].Enabled = _currentPage > 1;
                    buttons[2].Enabled = _currentPage < TotalPages;
                    buttons[3].Enabled = _currentPage < TotalPages;
                }

                // Actualizar label de total registros
                var totalRecordsLabel = _paginationPanel.Controls[0].Controls[1].Controls
                    .OfType<Label>().FirstOrDefault(l => l.Name == "lblTotalRecords");
                if (totalRecordsLabel != null)
                {
                    totalRecordsLabel.Text = $"Total registros: {_fullData.Rows.Count}";
                }

                // Actualizar label "Mostrando X a Y de Z entradas"
                int totalRecords = _fullData.Rows.Count;

                if (totalRecords > 0)
                {
                    int startEntry = (_currentPage - 1) * _pageSize + 1;
                    int endEntry = Math.Min(_currentPage * _pageSize, totalRecords);

                    _showingEntriesLabel.Text = $"Mostrando {startEntry} a {endEntry} de {totalRecords} entradas";
                }
                else
                {
                    _showingEntriesLabel.Text = "Mostrando 0 a 0 de 0 entradas";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al paginar: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private int TotalPages => _fullData.Rows.Count == 0 ? 1 : (int)Math.Ceiling((double)_fullData.Rows.Count / _pageSize);
        //metodo para llenar el combobox 10,25,50,100
        public List<KeyValuePair<int, string>> FillPageSizeComboBox()
        {
            return new List<KeyValuePair<int, string>> {
        new KeyValuePair<int, string>(10, "10"),
        new KeyValuePair<int, string>(25, "25"),
        new KeyValuePair<int, string>(50, "50"),
        new KeyValuePair<int, string>(100, "100"),
        new KeyValuePair<int, string>(int.MaxValue, "Todos") // valor muy grande para "Todos"
    };
        }
    }
}