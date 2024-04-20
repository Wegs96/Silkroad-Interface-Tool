using System.Windows;
using System.Windows.Media;
using SilkroadInterfaceTool.Helpers;
using Color = System.Drawing.Color;
using Point = System.Windows.Point;

namespace SilkroadInterfaceTool.SROControls;

public class CIFButton : CIFControlBase
{
    public CIFButton() : base()
    {
        CIFType = CIFType.CIFButton;
    }

    public override void DefaultSetup()
    {
        base.DefaultSetup();

        CIFClientRect = new Rect(0, 0, 0, 0);
        CIFColor = Color.FromArgb(255, 73, 102, 178);
        CIFDDJ = "interface\\\\system\\\\sys_button.ddj";
        CIFFontColor = Color.FromArgb(255, 254, 251, 216);
        CIFFontIndex = 0;
        CIFHAlign = 1;
        CIFRect = new Rect(0, 0, 152, 24);
        CIFStyle = 0;
        CIFSubSection = string.Empty;
        CIFText = string.Empty;
        CIFUV_LB = new Point(0, 1);
        CIFUV_LT = new Point(0, 0);
        CIFUV_RB = new Point(1, 1);
        CIFUV_RT = new Point(1, 0);
        CIFVAlign = 0;

        //-------\\
        //   Margin = new Thickness(CIFRect.X,CIFRect.Y,0,0);
    }

    protected override void OnRender(DrawingContext drawingContext)
    {
        base.OnRender(drawingContext);
        var btnTexture = ResourceHelper.GetBitmapImageFromRes("Textures/sys_button.png");
        drawingContext.DrawImage(btnTexture, new Rect(0, 0, CIFRect.Width, CIFRect.Height));
    }
}