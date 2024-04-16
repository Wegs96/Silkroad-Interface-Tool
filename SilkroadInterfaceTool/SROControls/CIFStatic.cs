using System.Drawing;
using System.Windows;
using Point = System.Windows.Point;

namespace SilkroadInterfaceTool.SROControls;

public class CIFStatic : CIFControlBase
{
    public CIFStatic(UIElement parent) : base(parent)
    {
        CIFType = CIFType.CIFStatic;
    }
    
    public override void DefaultSetup()
    {
        base.DefaultSetup();
        
        CIFClientRect = new Rect(0, 0, 0, 0);
        CIFColor = Color.FromArgb(255,214,171,46);
        CIFDDJ = "interface\\\\ifcommon\\\\bg_tile\\\\com_bg_tile_b.ddj";
        CIFFontColor = Color.FromArgb(255,254,251,216);
        CIFFontIndex = 1;
        CIFHAlign = 1;
        CIFRect = new Rect(0,0,120,20);
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