using Conta_Certa.DataProviders;
using System.Diagnostics;
using System.Linq.Expressions;

namespace Conta_Certa.Components;

public class ColumnDefinition<T>
{
    public required string Header { get; set; }
    public required Func<T, string> ValueSelector { get; set; }
    public Expression<Func<T, object?>>? OrderBySelector { get; set; }
    public StringAlignment Alignment { get; set; } = StringAlignment.Near;
}

public partial class LazyPanel<T> : Panel
{
    // CACHE
    private IDataProvider<T>? _provider;
    private Dictionary<int, T> _cache = [];
    private List<ColumnDefinition<T>> _columns = [];

    // TAMANHO
    private int _itemHeight = 40, _itemWidth = 0;
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
        DoubleBuffered = true;
        AutoScroll = true;
        SetStyle(ControlStyles.ResizeRedraw, true);

        // MENU STRIP

        _menuStrip = new ContextMenuStrip();

        _menuStrip.Leave += MenuStrip_Leave;
        _menuStrip.Items.Add("Alterar", null, (EventHandler?)((s, e) =>
        {
            if (_selectedIndex >= 0 && _selectedIndex < _cache.Count)
            {
                ItemChange?.Invoke(this, _cache[_selectedIndex]);
            }
        }));

        _menuStrip.Items.Add("Excluir", null, (EventHandler?)((s, e) =>
        {
            if (_selectedIndex >= 0 && _selectedIndex < _cache.Count)
            {
                ItemDelete?.Invoke(this, _cache[_selectedIndex]);
            }
        }));
    }

    public void SetColumns(List<ColumnDefinition<T>> columns)
    {
        _columns = columns;
        _orderBy = columns[0].OrderBySelector;

        RecalcScrollSize();
        Invalidate();
    }

    public void SetProvider(IDataProvider<T> provider, int itemHeight = 40)
    {
        _provider = provider;
        _itemHeight = itemHeight;

        if (provider != null)
        {
            RecalcScrollSize();
        }
    }

    public void RemakeCache()
    {
        _cache.Clear();

        if (_provider != null && _orderBy != null)
        {
            // Carrega o cache novo
            var items = _provider!.GetRange(
                _cacheStart,
                _cacheEnd - _cacheStart + 1,
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
            (_cache.Count + 1) * _itemHeight);

        Invalidate();
    }

    private void MenuStrip_Leave(object? sender, EventArgs e)
    {
        _selectedIndex = -1;
    }

    private T GetItem(int index)
    {
        if (_cache.TryGetValue(index, out var item)) return item;

        if (index < 0 || index >= _provider!.GetTotalCount())
        {
            throw new IndexOutOfRangeException($"Índice {index} fora do intervalo de itens disponíveis.");
        }

        int start = Math.Max(0, index - _blockSize);
        int end = Math.Min(_provider!.GetTotalCount() - 1, start + _cacheSize);

        _cacheStart = start;
        _cacheEnd = end;

        RemakeCache();

        if (_cache.TryGetValue(index, out var reloaded))
        {
            return reloaded;
        }

        throw new InvalidOperationException($"Nenhum item disponível para o índice {index}");
    }

    private int GetColumnHit(int contentX)
    {
        int x = 0;

        for (int i = 0; i < _columns.Count; i++)
        {
            if (contentX >= x && contentX < x + _itemWidth)
            {
                return i;
            }

            x += _itemWidth;
        }
        return -1;
    }

    protected override void OnMouseMove(MouseEventArgs e)
    {
        base.OnMouseMove(e);

        int contentY = e.Y + VerticalScroll.Value;
        int index = (contentY - _itemHeight) / _itemHeight;

        if (index >= 0 && index < _cache.Count)
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

        int contentX = e.X + HorizontalScroll.Value;
        int contentY = e.Y + VerticalScroll.Value;

        // MENU
        if (e.Button == MouseButtons.Right)
        {
            if (e.Y > _itemHeight)
            {
                int index = (contentY - _itemHeight) / _itemHeight;

                if (index >= 0 && index < _cache.Count)
                {
                    _selectedIndex = index;

                    _menuStrip.Show(this, e.Location);
                    Invalidate();
                }
            }

        }

        // ORDENAÇÃO
        else if (e.Y <= _itemHeight)
        {
            int col = GetColumnHit(contentX);

            if (col >= 0)
            {
                var clickedCol = _columns[col];

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

                RemakeCache();
            }
        }
    }
   
    protected override void OnPaint(PaintEventArgs e)
    {
        base.OnPaint(e);

        if (_provider == null || _columns.Count == 0) return;
        _itemWidth = ClientSize.Width / _columns.Count;

        var g = e.Graphics;
        g.TranslateTransform(0, -VerticalScroll.Value);
        g.Clear(BackColor);

        int x = 0;
        int scrollY = VerticalScroll.Value;

        // CABEÇALHO
        for (int j = 0; j < _columns.Count; j++)
        {
            var col = _columns[j];

            Rectangle rect = new(x, 0, _itemWidth, _itemHeight);
            g.FillRectangle(Brushes.LightGray, rect);
            g.DrawRectangle(Pens.Gray, rect);

            using var sf = new StringFormat()
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            };

            var txt = col.Header;

            if (_sortColumnIndex == j)
            {
                txt += (_orderAscending ? " ▲" : " ▼");
            }

            g.DrawString(txt, _headerFont, Brushes.Black, rect, sf);

            x += _itemWidth;
        }

        // SEM RESULTADOS
        if (_provider.GetTotalCount() == 0)
        {
            g.DrawString("Nenhum item encontrado", _headerFont, Brushes.Gray, new PointF(10, _itemHeight + 10));
            return;
        }

        // RANGE VISÍVEL
        int firstVisible = Math.Max(0, scrollY / _itemHeight);
        int lastVisible = Math.Min(
            _provider.GetTotalCount() - 1,
            firstVisible + (ClientSize.Height + _itemHeight) / _itemHeight);

        // ITENS
        for (int i = firstVisible; i <= lastVisible; i++)
        {
            var item = GetItem(i);

            x = 0;

            int rowTop = _itemHeight + i * _itemHeight - scrollY;
            Rectangle rowRectWhole = new(0, rowTop, ClientSize.Width, _itemHeight);

            // BACKGROUND
            bool isHover = (i == _hoverIndex);

            if (isHover)
            {
                using SolidBrush hoverBackBrush = new(Color.FromArgb(50, Color.LightBlue));
                g.FillRectangle(hoverBackBrush, new Rectangle(rowRectWhole.Left, rowTop, rowRectWhole.Width, rowRectWhole.Height));
            }

            else
            {
                g.FillRectangle(i % 2 == 0 ? Brushes.White : Brushes.WhiteSmoke, new Rectangle(rowRectWhole.Left, rowTop, rowRectWhole.Width, rowRectWhole.Height));
            }

            foreach (var col in _columns)
            {

                Rectangle rect = new(x, rowTop, _itemWidth, _itemHeight);
                g.DrawRectangle(Pens.Gray, rect);

                using var sf = new StringFormat()
                {
                    Alignment = col.Alignment,
                    LineAlignment = StringAlignment.Center
                };

                if (col.ValueSelector != null)
                {
                    g.DrawString(col.ValueSelector(item), _itemFont, Brushes.Black, rect, sf);
                }

                x += _itemWidth;
            }
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