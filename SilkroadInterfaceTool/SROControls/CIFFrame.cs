using System.Windows;
using System.Windows.Media;
using SilkroadInterfaceTool.Helpers;
using Color = System.Drawing.Color;
using Point = System.Windows.Point;

namespace SilkroadInterfaceTool.SROControls;

public class CIFFrame : CIFControlBase
{
    public CIFFrame() : base()
    {
        CIFType = CIFType.CIFFrame;
    }

    public override void DefaultSetup()
    {
        base.DefaultSetup();

        CIFClientRect = new Rect(0, 0, 0, 0);
        CIFColor = Color.FromArgb(255, 108, 205, 164);
        CIFDDJ = "interface\\\\inventory\\\\int_window_";
        CIFFontColor = Color.FromArgb(255, 255, 255, 255);
        CIFFontIndex = 0;
        CIFHAlign = 2;
        CIFRect = new Rect(17, 45, 366, 240);
        CIFStyle = 0;
        ;
        CIFSubSection = string.Empty;
        CIFText = string.Empty;
        CIFUV_LT = new Point(0, 0);
        CIFUV_RB = new Point(1, 1);
        CIFUV_RT = new Point(1, 0);
        CIFVAlign = 0;

        //-------\\
        // Width = CIFRect.Width;
        // Height = CIFRect.Height;
        // Margin = new Thickness(CIFRect.X,CIFRect.Y,0,0);
    }

    protected override void OnRender(DrawingContext drawingContext)
    {
        base.OnRender(drawingContext);

        var leftUpTexture = ResourceHelper.GetBitmapImageFromRes("Textures/Frame/frame_left_up.png");
        var midUpTexture = ResourceHelper.GetBitmapImageFromRes("Textures/Frame/frame_mid_up.png");
        var rightUpTexture = ResourceHelper.GetBitmapImageFromRes("/Textures/Frame/frame_right_up.png");

        var leftSideTexture = ResourceHelper.GetBitmapImageFromRes("Textures/Frame/frame_left_side.png");
        var rightSideTexture = ResourceHelper.GetBitmapImageFromRes("Textures/Frame/frame_right_side.png");

        var leftDownTexture = ResourceHelper.GetBitmapImageFromRes("Textures/Frame/frame_left_down.png");
        var midDownTexture = ResourceHelper.GetBitmapImageFromRes("Textures/Frame/frame_mid_down.png");
        var rightDownTexture = ResourceHelper.GetBitmapImageFromRes("Textures/Frame/frame_right_down.png");


        drawingContext.DrawImage(leftUpTexture, new Rect(0, 0, leftUpTexture.Width, leftUpTexture.Height));

        var midUpPos = ImageHelper.FillPattern(drawingContext, midUpTexture,
            new Rect(leftUpTexture.Width, 0, CIFRect.Width - leftUpTexture.Width - rightUpTexture.Width,
                midUpTexture.Height));

        drawingContext.DrawImage(rightUpTexture,
            new Rect(midUpPos.Width + leftUpTexture.Width, 0, rightUpTexture.Width, rightUpTexture.Height));


        var leftSidePos = ImageHelper.FillPattern(drawingContext, leftSideTexture,
            new Rect(0, leftUpTexture.Height, leftSideTexture.Width,
                CIFRect.Height - leftUpTexture.Height - leftDownTexture.Height));
        var rightSidePos = ImageHelper.FillPattern(drawingContext, rightSideTexture,
            new Rect(midUpPos.Width + leftUpTexture.Width, rightUpTexture.Height, rightSideTexture.Width,
                CIFRect.Height - rightUpTexture.Height - rightDownTexture.Height));

        drawingContext.DrawImage(leftDownTexture,
            new Rect(0, leftSidePos.Height + leftUpTexture.Height, leftDownTexture.Width, leftDownTexture.Height));
        var midDownPos = ImageHelper.FillPattern(drawingContext, midDownTexture,
            new Rect(rightDownTexture.Width, leftSidePos.Height + leftUpTexture.Height,
                CIFRect.Width - rightDownTexture.Width - leftDownTexture.Width, midDownTexture.Height));
        drawingContext.DrawImage(rightDownTexture,
            new Rect(midDownPos.Width + leftDownTexture.Width, rightSidePos.Height + rightUpTexture.Height,
                rightDownTexture.Width, rightDownTexture.Height));
    }
}