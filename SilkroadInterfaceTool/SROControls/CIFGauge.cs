using System.Windows;
using System.Windows.Media;
using SilkroadInterfaceTool.Base;
using SilkroadInterfaceTool.Helpers;
using Color = System.Drawing.Color;
using Point = System.Windows.Point;

namespace SilkroadInterfaceTool.SROControls;

public class CIFGauge : CIFControl
{
    public CIFGauge(CIFMainFrame mainFrame) : base(mainFrame)
    {
        CIFType = CIFType.CIFGauge;
    }

    public override void DefaultSetup()
    {
        base.DefaultSetup();
        CIFClientRect = new Rect(0, 0, 0, 0);
        CIFColor = Color.FromArgb(255, 28, 181, 42);
        CIFDDJ = "interface\\\\playerminiinfo\\\\pmi_hp.ddj";
        CIFFontColor = Color.FromArgb(255, 255, 255, 255);
        CIFFontIndex = 0;
        CIFHAlign = 0;
        CIFRect = new Rect(0, 0, 124, 12);
        CIFStyle = 0;
        CIFSubSection = string.Empty;
        CIFText = string.Empty;
        CIFUV_LB = new Point(0, 1);
        CIFUV_LT = new Point(0, 0);
        CIFUV_RB = new Point(1, 1);
        CIFUV_RT = new Point(1, 0);
        CIFVAlign = 0;
    }

    protected override void OnRender(DrawingContext drawingContext)
    {
        base.OnRender(drawingContext);

        var gaugeTexture = ResourceHelper.GetBitmapImageFromRes("Textures/Gauge/red_gauge.png");
        drawingContext.DrawImage(gaugeTexture, new Rect(0, 0, CIFRect.Width, CIFRect.Height));
    }
}