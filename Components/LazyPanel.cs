using Conta_Certa.DataProviders;
using System.Linq.Expressions;

namespace Conta_Certa.Components;

// Definição de Coluna (AGORA COM WEIGHT)
public class ColumnDefinition<T>
{
    public required string Header { get; set; }
    public required Func<T, string> ValueSelector { get; set; }
    public Expression<Func<T, object?>>? OrderBySelector { get; set; }
    public StringAlignment Alignment { get; set; } = StringAlignment.Near;
    public int Weight { get; set; } = 1; // NOVO: Peso da coluna para cálculo de largura
}

public partial class LazyPanel<T> : Panel
{
    // CACHE
    private IDataProvider<T>? _provider;
    private Dictionary<int, T> _cache = [];
    private List<ColumnDefinition<T>> _columns = [];

    // TAMANHO
    private int _itemHeight = 40;
    private readonly int _cacheSize = 50, _blockSize = 25;
    private int _cacheStart = 0, _cacheEnd = -1;

    // FONTES
    private readonly Font _headerFont = new("Arial", 11, FontStyle.Bold);
    private readonly Font _itemFont = new("Arial", 11);

    // SELEÇÃO
    private int _selectedIndex = -1, _hoverIndex = -1;

    // ORDEM E FILTRO
    private Expression<Func<T, object?>>? _orderBy;
    private bool _orderAscending = true;
    private int _sortColumnIndex = 0;

    // CONTEXT MENU
    private readonly ContextMenuStrip _menuStrip;
    public event EventHandler<T>? ItemChange, ItemDelete;

    public LazyPanel()
    {
        SetStyle(ControlStyles.UserPaint |
                 ControlStyles.AllPaintingInWmPaint |
                 ControlStyles.OptimizedDoubleBuffer |
                 ControlStyles.ResizeRedraw, true);

        SetStyle(ControlStyles.ContainerControl, true);

        DoubleBuffered = true;
        AutoScroll = true;

        _menuStrip = new ContextMenuStrip();

        _menuStrip.Leave += MenuStrip_Leave;
        _menuStrip.Items.Add("Alterar", null, (s, e) =>
        {
            if (_selectedIndex >= 0 && _provider != null && _selectedIndex < _provider.GetTotalCount())
            {
                var item = GetItem(_selectedIndex);
                ItemChange?.Invoke(this, item);
            }
        });

        _menuStrip.Items.Add("Excluir", null, (s, e) =>
        {
            if (_selectedIndex >= 0 && _provider != null && _selectedIndex < _provider.GetTotalCount())
            {
                var item = GetItem(_selectedIndex);
                ItemDelete?.Invoke(this, item);
            }
        });
    }

    public void SetColumns(List<ColumnDefinition<T>> columns)
    {
        _columns = columns;
        if (columns.Count > 0)
        {
            _orderBy = columns[0].OrderBySelector;
        }

        RecalcScrollSize();
        Invalidate();
    }

    public void SetProvider(IDataProvider<T> provider, int itemHeight = 40)
    {
        _provider = provider;
        _itemHeight = itemHeight;

        if (provider != null)
        {
            _cache.Clear();
            _cacheStart = 0;
            _cacheEnd = -1;

            RecalcScrollSize();
            RemakeCache();
        }
    }

    public void RemakeCache()
    {
        _cache.Clear();

        if (_provider != null && _orderBy != null)
        {
            int totalCount = _provider.GetTotalCount();

            // Garante que o intervalo de cache seja válido
            if (_cacheStart < 0) _cacheStart = 0;
            _cacheEnd = Math.Min(totalCount - 1, _cacheStart + _cacheSize - 1);

            int count = _cacheEnd - _cacheStart + 1;
            if (count <= 0) return;

            // Carrega o cache novo
            var items = _provider!.GetRange(
                _cacheStart,
                count,
                _orderBy,
                _orderAscending).ToArray();

            for (int i = 0; i < items.Length; i++)
            {
                _cache[_cacheStart + i] = items[i];
            }

            Invalidate();
        }
    }

    private void RecalcScrollSize()
    {
        if (_provider == null) return;

        AutoScrollMinSize = new(
            ClientSize.Width,
            _provider.GetTotalCount() * _itemHeight);

        Invalidate();
    }

    private void MenuStrip_Leave(object? sender, EventArgs e)
    {
        _selectedIndex = -1;
        Invalidate();
    }

    private T GetItem(int index)
    {
        if (_cache.TryGetValue(index, out var item)) return item;

        if (_provider == null || index < 0 || index >= _provider!.GetTotalCount())
        {
            throw new IndexOutOfRangeException($"Índice {index} fora do intervalo de itens disponíveis.");
        }

        int start = Math.Max(0, index - _blockSize);

        _cacheStart = start;
        _cacheEnd = -1;

        RemakeCache();

        if (_cache.TryGetValue(index, out var reloaded))
        {
            return reloaded;
        }

        throw new InvalidOperationException($"Nenhum item disponível para o índice {index} após recarga.");
    }

    private int GetColumnHit(int contentX)
    {
        if (_columns.Count == 0) return -1;

        int totalWeight = _columns.Sum(c => c.Weight);
        int remainingWidth = ClientSize.Width;
        List<int> columnWidths = [];

        for (int j = 0; j < _columns.Count - 1; j++)
        {
            int width = (int)Math.Round((double)ClientSize.Width * _columns[j].Weight / totalWeight);
            columnWidths.Add(width);
            remainingWidth -= width;
        }

        if (_columns.Count > 0)
        {
            columnWidths.Add(remainingWidth);
        }

        int x = 0;

        for (int i = 0; i < _columns.Count; i++)
        {
            int colWidth = columnWidths[i];

            if (contentX >= x && contentX < x + colWidth)
            {
                return i;
            }

            x += colWidth;
        }
        return -1;
    }

    protected override void OnMouseMove(MouseEventArgs e)
    {
        base.OnMouseMove(e);

        if (_provider == null) return;

        int contentY = e.Y + VerticalScroll.Value;

        // Se o mouse está sobre o cabeçalho
        if (contentY < _itemHeight)
        {
            if (_hoverIndex != -1)
            {
                _hoverIndex = -1;
                Invalidate();
            }
            return;
        }

        // O índice do item de dados começa após o cabeçalho (linha 1)
        int index = (contentY - _itemHeight) / _itemHeight;

        // Valida contra o total de itens.
        if (index >= 0 && index < _provider.GetTotalCount())
        {
            if (_hoverIndex != index)
            {
                _hoverIndex = index;
                Invalidate();
            }
        }
        else if (_hoverIndex != -1)
        {
            _hoverIndex = -1;
            Invalidate();
        }
    }

    protected override void OnMouseClick(MouseEventArgs e)
    {
        base.OnMouseClick(e);

        if (_provider == null) return;

        int contentX = e.X + HorizontalScroll.Value;
        int contentY = e.Y + VerticalScroll.Value;

        // MENU (Botão Direito)
        if (e.Button == MouseButtons.Right)
        {
            // Se o clique for abaixo do cabeçalho
            if (e.Y > _itemHeight)
            {
                // O índice do item de dados começa após o cabeçalho (linha 1)
                int index = (contentY - _itemHeight) / _itemHeight;

                // Valida contra o total de itens.
                if (index >= 0 && index < _provider.GetTotalCount())
                {
                    _selectedIndex = index;

                    _menuStrip.Show(this, e.Location);
                    Invalidate(); // Força o redesenho para destacar o item selecionado
                }
            }
        }

        // ORDENAÇÃO (Botão Esquerdo no Cabeçalho)
        else if (e.Button == MouseButtons.Left && e.Y <= _itemHeight)
        {
            int col = GetColumnHit(contentX);

            if (col >= 0)
            {
                var clickedCol = _columns[col];

                // Só permite ordenar se a coluna tiver um OrderBySelector
                if (clickedCol.OrderBySelector == null) return;

                if (_sortColumnIndex == col)
                {
                    _orderAscending = !_orderAscending;
                }

                else
                {
                    _orderAscending = true;
                    _sortColumnIndex = col;
                }

                _orderBy = clickedCol.OrderBySelector;

                // Reseta a rolagem e o cache para o início da lista
                _cacheStart = 0;
                VerticalScroll.Value = VerticalScroll.Minimum;
                AutoScrollPosition = new Point(0, 0);

                RemakeCache(); // Carrega o novo bloco ordenado
                Invalidate();
            }
        }
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        var g = e.Graphics;

        // Configurações de qualidade
        g.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighSpeed;
        g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighSpeed;
        g.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.None;

        if (_provider == null || _columns.Count == 0) return;

        int totalAvailableWidth = ClientSize.Width;
        int totalWeight = _columns.Sum(c => c.Weight);
        int remainingWidth = totalAvailableWidth;
        List<int> columnWidths = new();

        for (int j = 0; j < _columns.Count - 1; j++)
        {
            var col = _columns[j];
            int width = (int)Math.Round((double)totalAvailableWidth * col.Weight / totalWeight);
            columnWidths.Add(width);
            remainingWidth -= width;
        }

        if (_columns.Count > 0)
        {
            columnWidths.Add(remainingWidth);
        }

        g.FillRectangle(new SolidBrush(BackColor), e.ClipRectangle);
        g.TranslateTransform(DisplayRectangle.Location.X, 0);

        int x = 0;

        // DESENHO DO CABEÇALHO (FIXO, SEM TRANSFORMAÇÃO) 
        Rectangle headerRectTotal = new(0, 0, ClientSize.Width, _itemHeight);
        g.FillRectangle(Brushes.LightGray, headerRectTotal);
        g.DrawLine(Pens.DarkGray, 0, _itemHeight - 1, ClientSize.Width, _itemHeight - 1); // Linha separadora

        for (int j = 0; j < _columns.Count; j++)
        {
            var col = _columns[j];
            int colWidth = columnWidths[j];
            Rectangle rect = new(x, 0, colWidth, _itemHeight); // y=0 fixo

            g.DrawRectangle(Pens.Gray, rect);

            using var sf = new StringFormat()
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center,
                FormatFlags = StringFormatFlags.NoWrap
            };

            var txt = col.Header;
            if (_sortColumnIndex == j)
            {
                txt += (_orderAscending ? " ▲" : " ▼");
            }

            g.DrawString(txt, _headerFont, Brushes.Black, rect, sf);
            x += colWidth;
        }

        g.TranslateTransform(-DisplayRectangle.Location.X, 0);

        // ISOLAMENTO DO CONTEÚDO ROLÁVEL
        // Salva o estado atual do Graphics (sem rolagem e sem clip)
        var state = g.Save();

        // Define uma região de clipping para que os itens da lista não invadam a área do cabeçalho
        Rectangle contentClipRect = new(0, _itemHeight, ClientSize.Width, ClientSize.Height - _itemHeight);
        g.SetClip(contentClipRect);
        g.TranslateTransform(0, _itemHeight - VerticalScroll.Value);

        int totalCount = _provider.GetTotalCount();

        // SEM RESULTADOS
        if (totalCount == 0)
        {
            g.DrawString("Nenhum item encontrado", _headerFont, Brushes.Gray, new PointF(10, _itemHeight));
            return;
        }

        // RANGE VISÍVEL - Calcula quais índices devem ser desenhados
        int firstVisible = Math.Max(0, VerticalScroll.Value / _itemHeight);
        int lastVisible = Math.Min(
            totalCount - 1,
            firstVisible + (ClientSize.Height + _itemHeight) / _itemHeight);

        // ITENS
        for (int i = firstVisible; i <= lastVisible; i++)
        {
            var item = GetItem(i);

            x = 0;
            int rowTop = i * _itemHeight;

            Rectangle rowRectWhole = new(0, rowTop, ClientSize.Width, _itemHeight);

            // BACKGROUND
            bool isHover = (i == _hoverIndex);
            bool isSelected = (i == _selectedIndex);

            if (isSelected)
            {
                using SolidBrush selectBackBrush = new(Color.FromArgb(100, Color.DeepSkyBlue));
                g.FillRectangle(selectBackBrush, rowRectWhole);
            }

            else if (isHover)
            {
                using SolidBrush hoverBackBrush = new(Color.FromArgb(50, Color.LightBlue));
                g.FillRectangle(hoverBackBrush, rowRectWhole);
            }

            else
            {
                g.FillRectangle(i % 2 == 0 ? Brushes.White : Brushes.WhiteSmoke, rowRectWhole);
            }

            // DESENHO DAS CÉLULAS
            for (int j = 0; j < _columns.Count; j++)
            {
                var col = _columns[j];
                int colWidth = columnWidths[j];

                Rectangle rect = new(x, rowTop, colWidth, _itemHeight);
                g.DrawRectangle(Pens.Gray, rect);

                using var sf = new StringFormat()
                {
                    Alignment = col.Alignment,
                    LineAlignment = StringAlignment.Center,
                    Trimming = StringTrimming.EllipsisCharacter,
                    FormatFlags = StringFormatFlags.NoWrap
                };

                if (col.ValueSelector != null)
                {
                    Rectangle textRect = new(rect.X + 5, rect.Y, rect.Width - 10, rect.Height);
                    g.DrawString(col.ValueSelector(item), _itemFont, Brushes.Black, textRect, sf);
                }

                x += colWidth;
            }
        }

        g.Restore(state);
    }

    protected override void WndProc(ref Message m)
    {
        const int WM_VSCROLL = 0x115;
        const int WM_MOUSEWHEEL = 0x20A;
        const int WM_ERASEBKGND = 0x14;

        // Ignora a mensagem de apagar fundo
        if (m.Msg == WM_ERASEBKGND)
        {
            return;
        }

        base.WndProc(ref m);

        if (m.Msg == WM_VSCROLL || m.Msg == WM_MOUSEWHEEL)
        {
            Invalidate();
        }
    }

    protected override void Dispose(bool disposing)
    {
        if (disposing)
        {
            _headerFont.Dispose();
            _itemFont.Dispose();
            _menuStrip.Dispose();
        }

        base.Dispose(disposing);
    }
}