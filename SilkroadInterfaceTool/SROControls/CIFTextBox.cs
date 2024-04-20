using System.Globalization;
using System.Windows;
using System.Windows.Media;
using Color = System.Drawing.Color;
using Point = System.Windows.Point;

namespace SilkroadInterfaceTool.SROControls;

public class CIFTextBox : CIFControlBase
{
    public CIFTextBox() : base()
    {
        CIFType = CIFType.CIFTextBox;
    }

    public override void DefaultSetup()
    {
        base.DefaultSetup();

        CIFClientRect = new Rect(0, 0, 0, 0);
        CIFColor = Color.FromArgb(255, 117, 6, 140);
        CIFDDJ = string.Empty;
        CIFFontColor = Color.FromArgb(255, 255, 255, 255);
        CIFFontIndex = 0;
        CIFHAlign = 0;
        CIFRect = new Rect(0, 0, 200, 100);
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

        var p = new Pen(Brushes.GreenYellow, 1);

        drawingContext.DrawLine(p, new Point(0, 0), new Point(CIFRect.Width, 0));
        drawingContext.DrawLine(p, new Point(0, 0), new Point(0, CIFRect.Height));
        drawingContext.DrawLine(p, new Point(CIFRect.Width, CIFRect.Height), new Point(0, CIFRect.Height));
        drawingContext.DrawLine(p, new Point(CIFRect.Width, 0), new Point(CIFRect.Width, CIFRect.Height));

        var fText = new FormattedText("CIFTextBox", CultureInfo.GetCultureInfo("en-us"), FlowDirection.LeftToRight,
            new Typeface("Arial"), 16, Brushes.White,
            VisualTreeHelper.GetDpi(this).PixelsPerDip)
        {
            TextAlignment = TextAlignment.Center,
        };
        drawingContext.DrawText(fText, new Point(CIFRect.Width / 2, CIFRect.Height / 2));
    }
}