using System.Drawing;
using System.Windows;
using Point = System.Windows.Point;

namespace SilkroadInterfaceTool.SROControls;

public class CIFFrame : CIFControlBase
{
    public CIFFrame(UIElement parent) : base(parent)
    {
        CIFType = CIFType.CIFFrame;
    }
    
    public override void DefaultSetup()
    {
        base.DefaultSetup();
        
        CIFClientRect = new Rect(0, 0, 0, 0);
        CIFColor = Color.FromArgb(255,108,205,164);
        CIFDDJ = "interface\\\\inventory\\\\int_window_";
        CIFFontColor = Color.FromArgb(255, 255, 255, 255);
        CIFFontIndex = 0;
        CIFHAlign = 2;
        CIFRect = new Rect(17,45,366,240);
        CIFStyle = 0;;
        CIFSubSection = string.Empty;
        CIFText = string.Empty;
        CIFUV_LT = new Point(0, 0);
        CIFUV_RB = new Point(1, 1);
        CIFUV_RT = new Point(1, 0);
        CIFVAlign = 0;
        
        //-------\\
        Width = CIFRect.Width;
        Height = CIFRect.Height;
        Margin = new Thickness(CIFRect.X,CIFRect.Y,0,0);
    }
}