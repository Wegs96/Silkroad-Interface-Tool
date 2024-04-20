using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;

namespace SilkroadInterfaceTool.SROControls.Helpers;

public class CResizeAdorner : Adorner
{
    private Thumb _thumb;
    private VisualCollection _visualCollection;

    public CResizeAdorner(UIElement adornedElement) : base(adornedElement)
    {
        _visualCollection = new VisualCollection(this);
        _thumb = new Thumb() { Background = Brushes.Red, Height = 10, Width = 10 };
        _thumb.DragDelta += ThumbOnDragDelta;
        _visualCollection.Add(_thumb);
    }

    protected override int VisualChildrenCount => _visualCollection.Count;

    private void ThumbOnDragDelta(object sender, DragDeltaEventArgs e)
    {
        //Check if Shift Button is down otherwise return
        if (!Keyboard.IsKeyDown(Key.LeftShift) && !Keyboard.IsKeyDown(Key.RightShift)) return;


        //multiple support for both MainFrame and Sub-Controls
        if (AdornedElement is CIFControlBase)
        {
            var ele = (CIFControlBase)AdornedElement;
            ele.SetCIFRectHeight(ele.Height + e.VerticalChange < 0 ? ele.MinHeight : ele.Height + e.VerticalChange);
            ele.SetCIFRectWidth(ele.Width + e.HorizontalChange < 0 ? ele.MinWidth : ele.Width + e.HorizontalChange);
        }
        else if (AdornedElement is CIFMainFrameBase)
        {
            var ele = (CIFMainFrameBase)AdornedElement;
            ele.SetCIFRectHeight(ele.Height + e.VerticalChange < 0 ? ele.MinHeight : ele.Height + e.VerticalChange);
            ele.SetCIFRectWidth(ele.Width + e.HorizontalChange < 0 ? ele.MinWidth : ele.Width + e.HorizontalChange);
        }
    }

    protected override Visual GetVisualChild(int index)
    {
        return _visualCollection[index];
    }

    protected override Size ArrangeOverride(Size finalSize)
    {
        _thumb.Arrange(new Rect(AdornedElement.DesiredSize.Width - 5, AdornedElement.DesiredSize.Height - 5, 10, 10));
        return base.ArrangeOverride(finalSize);
    }
}