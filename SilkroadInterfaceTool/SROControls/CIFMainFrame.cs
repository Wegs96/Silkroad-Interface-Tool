using System.Drawing;
using System.Windows;
using System.Windows.Controls;
using Point = System.Windows.Point;

namespace SilkroadInterfaceTool.SROControls;

/// <summary>
/// CIFMainFrame aka window
/// </summary>
public class CIFMainFrame : CIFControlBase
{
    private readonly Canvas _canvas;
    public CIFMainFrame(UIElement parent) : base(parent)
    {
        CIFType = CIFType.CIFMainFrame;
        this._canvas = new Canvas();
    }

    public override void DefaultSetup()
    {
        base.DefaultSetup();
        
        CIFClientRect = new Rect(0, 0, 0, 0);
        CIFColor = Color.FromArgb(0, 0, 0, 0);
        CIFDDJ = "interface\\\\frame\\\\mframe_wnd_";
        CIFFontColor = Color.FromArgb(255, 255, 255, 255);
        CIFFontIndex = 0;
        CIFHAlign = 0;
        CIFRect = new Rect(300, 200, 400, 300);
        CIFStyle = 0;
        CIFSubSection = string.Empty;
        CIFText = "UIIT_PAG_SIT";
        CIFUV_LB = new Point(0, 1);
        CIFUV_LT = new Point(0, 0);
        CIFUV_RB = new Point(1, 1);
        CIFUV_RT = new Point(1, 0);
        CIFVAlign = 0;
        
        //-------\\
        Width = CIFRect.Width;
        Height = CIFRect.Height;
        Margin = new Thickness(CIFRect.X,CIFRect.Y,0,0);
    }

    public void AddControl(CIFControlBase control)
    {
        _canvas.Children.Add(control);
        //maybe we need to change Canvas Set top and left to Render RenderTransform
        Canvas.SetLeft(control, control.CIFRect.X);
        Canvas.SetTop(control, control.CIFRect.Y);
    }
    
    public void RemoveControl(CIFControlBase control)
    {
        _canvas.Children.Remove(control);
    }
}