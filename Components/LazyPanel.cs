using Conta_Certa.Utils;

namespace Conta_Certa.Components;

public partial class LazyPanel<T> : Panel
{
    private List<T> _items = [];
    private string _filter = "";
    private OrderBy _order = OrderBy.ID;
    private int _itemHeight = 40;
    private int _selectedIndex = -1, _hoverIndex = -1;
    private readonly Action<Graphics, Rectangle, T, bool, bool> itemRenderer;

    public event EventHandler<T> ItemClick;

    public LazyPanel()
    {
        DoubleBuffered = true;
        AutoScroll = true;
        SetStyle(ControlStyles.ResizeRedraw, true);

        MouseMove += LazyPanel_MouseMove;
        MouseClick += LazyPanel_MouseClick;

        itemRenderer = (g, rect, item, isHover, isSelected) =>
        {
            if (isSelected) g.FillRectangle(Brushes.LightBlue, rect);
            else if (isHover) g.FillRectangle(Brushes.AliceBlue, rect);
            else
            {
                g.FillRectangle((rect.Y / _itemHeight) % 2 == 0 
                    ? Brushes.White 
                    : Brushes.WhiteSmoke, rect);
            }

            string text = item?.ToString() ?? "(null)";
            g.DrawString(text, this.Font, Brushes.Black, rect,
                new StringFormat { LineAlignment = StringAlignment.Center, Alignment = StringAlignment.Near });

            g.DrawLine(Pens.LightGray, rect.Left, rect.Bottom - 1, rect.Right, rect.Bottom - 1);
        };

        InitializeComponent();
    }
    
    public void SetItems(List<T> items, int itemHeight = 40)
    {
        _items = items;
        _itemHeight = itemHeight;
        AutoScrollMinSize = new Size(0, _items.Count * itemHeight);
        Invalidate();
    }

    private void LazyPanel_MouseMove(object? sender, MouseEventArgs e)
    {
        int index = (e.Y + VerticalScroll.Value) / _itemHeight;

        if (index >= 0 && index < _items.Count)
        {
            if (_hoverIndex != index)
            {
                _hoverIndex = index;
                Invalidate();
            }
        }

        else
        {
            _hoverIndex = -1;
            Invalidate();
        }
    }

    private void LazyPanel_MouseClick(object? sender, MouseEventArgs e)
    {
        int index = (e.Y + VerticalScroll.Value) / _itemHeight;

        if (index >= 0 && index < _items.Count)
        {
            _selectedIndex = index;
            Invalidate();

            ItemClick?.Invoke(this, _items.ElementAt(index));
        }
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        base.OnPaint(e);

        var g = e.Graphics;
        g.TranslateTransform(0, -VerticalScroll.Value);


        int firstVisible = VerticalScroll.Value / _itemHeight;
        int visibleCount = (ClientSize.Height / _itemHeight) + 2;
        int lastVisible = Math.Min(_items.Count, firstVisible + visibleCount);

        for (int i = firstVisible; i < lastVisible; i++)
        {
            Rectangle rect = new(
                0,
                i * _itemHeight,
                ClientSize.Width,
                _itemHeight);

            bool isHover = (i == _hoverIndex);
            bool isSelected = (i == _selectedIndex);

            itemRenderer(g, rect, _items[i], isHover, isSelected);
        }
    }
}
