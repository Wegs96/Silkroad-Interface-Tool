using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Media;
using SilkroadInterfaceTool.Base;

namespace SilkroadInterfaceTool.Helpers;

public class CResizer : Canvas
{
    private readonly ControlBase _parent;
    private readonly Thumb _thumb;
    private readonly VisualCollection _visualCollection;

    public CResizer(ControlBase parent)
    {
        _parent = parent;
        _visualCollection = new VisualCollection(this);
        _thumb = new Thumb
        {
            Background = Brushes.Red, Height = 10, Width = 10,
            ToolTip = "Hold Shift Button & drag the mouse to Resize",
            Cursor = DesignArea.GetCIFCursor(DesignArea.CIFCursorType.Resize)
        };
        _thumb.DragDelta += ThumbOnDragDelta;
        _thumb.DragCompleted += (_, _) => this.Cursor = DesignArea.GetCIFCursor(DesignArea.CIFCursorType.Main);

        _visualCollection.Add(_thumb);
    }

    protected override int VisualChildrenCount => _visualCollection.Count;

    protected override Visual GetVisualChild(int index) => _visualCollection[index];

    protected override Size ArrangeOverride(Size finalSize)
    {
        _thumb.Arrange(new Rect(_parent.CIFRect.Width - 5, _parent.CIFRect.Height - 5, 10, 10));
        return base.ArrangeOverride(finalSize);
    }

    private void ThumbOnDragDelta(object sender, DragDeltaEventArgs e)
    {
        //Check if Shift Button is down otherwise return
        if (!Keyboard.IsKeyDown(Key.LeftShift) && !Keyboard.IsKeyDown(Key.RightShift)) return;

        this.Cursor = DesignArea.GetCIFCursor(DesignArea.CIFCursorType.Resize);
        _parent.SetCIFRectHeight(_parent.CIFRect.Height + e.VerticalChange < 0
            ? MinHeight
            : _parent.CIFRect.Height + e.VerticalChange);
        _parent.SetCIFRectWidth(_parent.CIFRect.Width + e.HorizontalChange < 0
            ? MinWidth
            : _parent.CIFRect.Width + e.HorizontalChange);
        _thumb.Arrange(new Rect(_parent.CIFRect.Width - 5, _parent.CIFRect.Height - 5, 10, 10));
    }
}