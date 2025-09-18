
namespace Conta_Certa.Components;

public class ColumnDefinition<T>
{
    public required string Header { get; set; }
    public required Func<T, string> ValueSelector { get; set; }
    public StringAlignment Alignment { get; set; } = StringAlignment.Near;
}

public partial class LazyPanel<T> : Panel
{
    private List<T> _items = [], _sortedItems = [];
    private List<ColumnDefinition<T>> _columns = [];

    // TAMANHO
    private int _itemHeight = 40, _itemWidth = 0;

    // FONTES
    private Font _headerFont = new("Arial", 11, FontStyle.Bold);
    private Font _itemFont = new("Arial", 11);

    // SELEÇÃO
    private int _selectedIndex = -1, _hoverIndex = -1;
    
    // ORDEM E FILTRO
    private int _sortColumnIndex = 0;
    private bool _sortAscending = true;

    private readonly ContextMenuStrip _menuStrip;

    public event EventHandler<T>? ItemChange, ItemDelete;
    public Func<T, bool> Filter = (item) => true;

    public LazyPanel()
    {
        DoubleBuffered = true;
        AutoScroll = true;
        SetStyle(ControlStyles.ResizeRedraw, true);

        // MENU STRIP

        _menuStrip = new ContextMenuStrip();

        _menuStrip.Leave += MenuStrip_Leave;

        _menuStrip.Items.Add("Alterar", null, (s, e) =>
        {
            if (_selectedIndex >= 0 && _selectedIndex < _sortedItems.Count)
            {
                ItemChange?.Invoke(this, _sortedItems.ElementAt(_selectedIndex));
            }
        });

        _menuStrip.Items.Add("Excluir", null, (s, e) =>
        {
            if (_selectedIndex >= 0 && _selectedIndex < _sortedItems.Count)
            {
                ItemDelete?.Invoke(this, _sortedItems.ElementAt(_selectedIndex));
            }
        });
    }
    
    public void SetColumns(List<ColumnDefinition<T>> columns)
    {
        _columns = columns;

        RecalcScrollSize();
        Invalidate();
    }

    public void SetItems(List<T> items, int itemHeight = 40)
    {
        _items = items;      
        _itemHeight = itemHeight;

        RecalcScrollSize();
        SortItems();
    }
  
    public void SortItems()
    {
        var filtered = _items.FindAll(i => Filter(i));
        var col = _columns[_sortColumnIndex];

        if (_sortAscending)
        {
            _sortedItems = [.. filtered.OrderBy(col.ValueSelector)];
        }

        else
        {
            _sortedItems = [.. filtered.OrderByDescending(col.ValueSelector)];
        }

        RecalcScrollSize();
        Invalidate();
    }

    private void RecalcScrollSize()
    {
        AutoScrollMinSize = new(ClientSize.Width, (_sortedItems.Count + 1) * _itemHeight);
    }

    private void MenuStrip_Leave(object? sender, EventArgs e)
    {
        _selectedIndex = -1;
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

        if (index >= 0 && index < _sortedItems.Count)
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

                if (index >= 0 && index < _sortedItems.Count)
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
                if (_sortColumnIndex == col)
                {
                    _sortAscending = !_sortAscending;
                }

                else 
                { 
                    _sortColumnIndex = col; 
                    _sortAscending = true; 
                }

                SortItems();
            }
        }
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        base.OnPaint(e);
     
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
                txt += (_sortAscending ? " ▲" : " ▼");
            }

            g.DrawString(txt, _headerFont, Brushes.Black, rect, sf);

            x += _itemWidth;
        }

        // RANGE VISÍVEL
        int firstVisible = Math.Max(0, scrollY / _itemHeight);
        int lastVisible = Math.Min(
            _sortedItems.Count - 1, 
            firstVisible + (ClientSize.Height + _itemHeight) / _itemHeight);

        // ITENS
        for (int i = firstVisible; i <= lastVisible; i++)
        {
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
                var item = _sortedItems[i];

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
}
