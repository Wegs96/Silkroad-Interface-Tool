// ReSharper disable InconsistentNaming

using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using Point = System.Windows.Point;

#pragma warning disable CS0414 // Field is assigned but its value is never used

namespace SilkroadInterfaceTool.Base;

public class CIFControl : ControlBase
{
    private readonly CIFMainFrame _mainFrame;

    protected CIFControl(CIFMainFrame mainFrame)
    {
        _mainFrame = mainFrame;
    }

    public CIFMainFrame MainFrame => _mainFrame;

    // <summary>
    // Default Setup , to be overridden from controls
    // </summary>
    public virtual void DefaultSetup()
    {
        this.ContextMenu = new ContextMenu();
        var removeItem = new MenuItem
        {
            Header = "Remove Me"
        };
        removeItem.Click += (sender, args) => { _mainFrame.RemoveControl(this); };

        this.ContextMenu.Items.Add(removeItem);
    }

    #region Dragable control

    private Point _positionInBlock;

    protected override void OnMouseDown(MouseButtonEventArgs e)
    {
        base.OnMouseDown(e);

        if (e.LeftButton != MouseButtonState.Pressed) return;

        _positionInBlock = Mouse.GetPosition(this);
        this.CaptureMouse();
    }

    protected override void OnMouseMove(MouseEventArgs e)
    {
        base.OnMouseMove(e);

        //Check if mouse is begin Captured otherwise return
        if (!this.IsMouseCaptured) return;
        //Check if Ctrl Button is down otherwise return
        if (!Keyboard.IsKeyDown(Key.LeftCtrl) && !Keyboard.IsKeyDown(Key.RightCtrl)) return;

        this.Cursor = DesignArea.GetCIFCursor(DesignArea.CIFCursorType.Hand);
        //var container = VisualTreeHelper.GetParent(this) as Canvas;
        var mousePosition = e.GetPosition(_mainFrame);
        if (mousePosition is { X: > 0, Y: > 0 } &&
            (mousePosition.X < _mainFrame.ActualWidth && mousePosition.Y < _mainFrame.ActualHeight))
        {
            var trans = this.RenderTransform = new TranslateTransform(mousePosition.X - _positionInBlock.X,
                mousePosition.Y - _positionInBlock.Y);

            SetCIFRectPosition(trans.Value.OffsetX, trans.Value.OffsetY);
        }
        else
            this.ReleaseMouseCapture();
    }

    protected override void OnMouseUp(MouseButtonEventArgs e)
    {
        base.OnMouseUp(e);

        this.Cursor = DesignArea.GetCIFCursor(DesignArea.CIFCursorType.Main);
        this.ReleaseMouseCapture();
    }

    #endregion
}