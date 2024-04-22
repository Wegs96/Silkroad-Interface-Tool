using System.Globalization;
using System.Windows;
using System.Windows.Media;
using SilkroadInterfaceTool.Base;
using Color = System.Drawing.Color;
using Point = System.Windows.Point;

namespace SilkroadInterfaceTool.SROControls;

public class CIFEdit : CIFControl
{
    public CIFEdit(CIFMainFrame mainFrame) : base(mainFrame)
    {
        CIFType = CIFType.CIFEdit;
    }

    public override void DefaultSetup()
    {
        base.DefaultSetup();

        CIFClientRect = new Rect(0, 0, 0, 0);
        CIFColor = Color.FromArgb(255, 255, 255, 255);
        CIFDDJ = string.Empty;
        CIFFontColor = Color.FromArgb(255, 255, 255, 255);
        CIFFontIndex = 0;
        CIFHAlign = 0;
        CIFRect = new Rect(0, 0, 100, 15);
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

        var p = new Pen(Brushes.Red, 1);

        drawingContext.DrawLine(p, new Point(0, 0), new Point(CIFRect.Width, 0));
        drawingContext.DrawLine(p, new Point(0, 0), new Point(0, CIFRect.Height));
        drawingContext.DrawLine(p, new Point(CIFRect.Width, CIFRect.Height), new Point(0, CIFRect.Height));
        drawingContext.DrawLine(p, new Point(CIFRect.Width, 0), new Point(CIFRect.Width, CIFRect.Height));

        var fText = new FormattedText("CIFEdit", CultureInfo.GetCultureInfo("en-us"), FlowDirection.LeftToRight,
            new Typeface("Arial"), 9, Brushes.White,
            VisualTreeHelper.GetDpi(this).PixelsPerDip)
        {
            TextAlignment = TextAlignment.Center,
            LineHeight = CIFRect.Height
        };

        drawingContext.DrawText(fText, new Point(CIFRect.Width / 2, 0));
    }
}