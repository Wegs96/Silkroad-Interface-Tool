using System.Windows;
using System.Windows.Media;
using SilkroadInterfaceTool.Helpers;
using Color = System.Drawing.Color;
using Point = System.Windows.Point;

namespace SilkroadInterfaceTool.MVVM.Models.SROControls;

public class CIFCheckBox : CIFControl
{
    public CIFCheckBox(CIFMainFrame mainFrame) : base(mainFrame)
    {
        CIFType = CIFType.CIFCheckBox;
    }

    public override void DefaultSetup()
    {
        base.DefaultSetup();

        CIFClientRect = new Rect(0, 0, 0, 0);
        CIFColor = Color.FromArgb(255, 255, 255, 255);
        CIFDDJ = "interface\\\\ifcommon\\\\com_checkbutton_off.ddj";
        CIFFontColor = Color.FromArgb(255, 255, 255, 255);
        CIFFontIndex = 0;
        CIFHAlign = 1;
        CIFRect = new Rect(0, 0, 16, 16);
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

        var btnTexture = ResourceHelper.GetBitmapImageFromRes("Textures/CheckBox/checkbutton_on.png");
        drawingContext.DrawImage(btnTexture, new Rect(0, 0, CIFRect.Width, CIFRect.Height));
    }
}