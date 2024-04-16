using System.Drawing;
using System.Windows;
using Point = System.Windows.Point;

namespace SilkroadInterfaceTool.SROControls;

/// <summary>
/// CIFNormalTile , it is a repeated background tile
/// </summary>
public class CIFNormalTile : CIFControlBase
{
    public CIFNormalTile(UIElement parent) : base(parent)
    {
        CIFType = CIFType.CIFNormalTile;
    }
    
    public override void DefaultSetup()
    {
        base.DefaultSetup();
        
        CIFClientRect = new Rect(0, 0, 0, 0);
        CIFColor = Color.FromArgb(255,72,211,143);
        CIFDDJ = "interface\\\\ifcommon\\\\bg_tile\\\\com_bg_tile_b.ddj";
        CIFFontColor = Color.FromArgb(255, 255, 255, 255);
        CIFFontIndex = 0;
        CIFHAlign = 0;
        CIFRect = new Rect(22,50,355,230);
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