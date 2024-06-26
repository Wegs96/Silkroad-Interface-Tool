using System.Windows;
using System.Windows.Media;
using SilkroadInterfaceTool.Base;
using SilkroadInterfaceTool.Helpers;
using Color = System.Drawing.Color;
using Point = System.Windows.Point;

namespace SilkroadInterfaceTool.SROControls;

/// <summary>
/// CIFNormalTile , it is a repeated background tile
/// </summary>
public class CIFNormalTile : CIFControl
{
    public CIFNormalTile(CIFMainFrame mainFrame) : base(mainFrame)
    {
        CIFType = CIFType.CIFNormalTile;
    }

    public override void DefaultSetup()
    {
        base.DefaultSetup();

        CIFClientRect = new Rect(0, 0, 0, 0);
        CIFColor = Color.FromArgb(255, 72, 211, 143);
        CIFDDJ = "interface\\\\ifcommon\\\\bg_tile\\\\com_bg_tile_b.ddj";
        CIFFontColor = Color.FromArgb(255, 255, 255, 255);
        CIFFontIndex = 0;
        CIFHAlign = 0;
        CIFRect = new Rect(22, 50, 355, 230);
        CIFStyle = 0;
        CIFSubSection = string.Empty;
        CIFText = string.Empty;
        CIFUV_LT = new Point(0, 0);
        CIFUV_RB = new Point(1, 1);
        CIFUV_RT = new Point(1, 0);
        CIFVAlign = 0;
    }

    protected override void OnRender(DrawingContext drawingContext)
    {
        base.OnRender(drawingContext);
        var tileTexture = ResourceHelper.GetBitmapImageFromRes("Textures/Tiles/com_bg_tile_b.png");

        ImageHelper.FillPattern(drawingContext, tileTexture, new Rect(0, 0, CIFRect.Width, CIFRect.Height));
    }
}