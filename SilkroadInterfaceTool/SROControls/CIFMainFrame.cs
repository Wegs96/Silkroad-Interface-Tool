using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using SilkroadInterfaceTool.Helpers;
using Color = System.Drawing.Color;
using Point = System.Windows.Point;

namespace SilkroadInterfaceTool.SROControls;

/// <summary>
/// CIFMainFrame aka window
/// </summary>
public class CIFMainFrame : CIFControlBase
{
    private readonly Canvas _canvas;
    public CIFMainFrame(UIElement parent) : base(parent)
    {
        CIFType = CIFType.CIFMainFrame;
        this._canvas = new Canvas();
    }

    public override void DefaultSetup()
    {
        base.DefaultSetup();
        
        CIFClientRect = new Rect(0, 0, 0, 0);
        CIFColor = Color.FromArgb(0, 0, 0, 0);
        CIFDDJ = "interface\\\\frame\\\\mframe_wnd_";
        CIFFontColor = Color.FromArgb(255, 255, 255, 255);
        CIFFontIndex = 0;
        CIFHAlign = 0;
        CIFRect = new Rect(0, 0, 400, 300);
        CIFStyle = 0;
        CIFSubSection = string.Empty;
        CIFText = "UIIT_PAG_SIT";
        CIFUV_LB = new Point(0, 1);
        CIFUV_LT = new Point(0, 0);
        CIFUV_RB = new Point(1, 1);
        CIFUV_RT = new Point(1, 0);
        CIFVAlign = 0;
        
        //-------\\
      
        Margin = new Thickness(CIFRect.X,CIFRect.Y,0,0);

        // //TODO: Context Menu 
        // if (ContextMenu != null)
        // {
        //     foreach (var cType in Enum.GetValues(typeof(CIFType)).Cast<CIFType>())
        //     {
        //         if(cType == CIFType.CIFMainFrame || cType == CIFType.CIFUNKNOWN)
        //             continue;
        //         var mItem = new MenuItem();
        //         mItem.Header = "Add New " + cType;
        //         mItem.Click += (sender, args) =>
        //         {
        //
        //         };
        //         
        //         ContextMenu.Items.Add(mItem);
        //
        //     }
        // }
    }

    public void AddControl(CIFControlBase control)
    {
        _canvas.Children.Add(control);
        //maybe we need to change Canvas Set top and left to Render RenderTransform
        Canvas.SetLeft(control, control.CIFRect.X);
        Canvas.SetTop(control, control.CIFRect.Y);
    }
    
    public void RemoveControl(CIFControlBase control)
    {
        _canvas.Children.Remove(control);
    }

    protected override void OnRender(DrawingContext drawingContext)
    {
        base.OnRender(drawingContext);

        var leftUpTexture = ResourceHelper.GetBitmapImageFromRes("Textures/MainFrame/mframe_wnd_left_up.png");
        var midUpTexture = ResourceHelper.GetBitmapImageFromRes("Textures/MainFrame/mframe_wnd_mid_up.png");
        var rightUpTexture = ResourceHelper.GetBitmapImageFromRes("/Textures/MainFrame/mframe_wnd_right_up.png");

        var leftSideTexture = ResourceHelper.GetBitmapImageFromRes("Textures/MainFrame/mframe_wnd_left_side.png");
        var rightSideTexture = ResourceHelper.GetBitmapImageFromRes("Textures/MainFrame/mframe_wnd_right_side.png");

        var leftDownTexture = ResourceHelper.GetBitmapImageFromRes("Textures/MainFrame/mframe_wnd_left_down.png");
        var midDownTexture = ResourceHelper.GetBitmapImageFromRes("Textures/MainFrame/mframe_wnd_mid_down.png");
        var rightDownTexture = ResourceHelper.GetBitmapImageFromRes("Textures/MainFrame/mframe_wnd_right_down.png");


        drawingContext.DrawImage(leftUpTexture, new Rect(0, 0, leftUpTexture.Width, leftUpTexture.Height));
        
        var midUpPos = ImageHelper.FillPattern(drawingContext, midUpTexture,
            new Rect(leftUpTexture.Width, 0, CIFRect.Width - leftUpTexture.Width - rightUpTexture.Width, midUpTexture.Height));
        
        drawingContext.DrawImage(rightUpTexture,
            new Rect(midUpPos.Width + leftUpTexture.Width, 0, rightUpTexture.Width, rightUpTexture.Height));
        
        
        var leftSidePos = ImageHelper.FillPattern(drawingContext, leftSideTexture,
            new Rect(0, leftUpTexture.Height,leftSideTexture.Width ,CIFRect.Height - leftUpTexture.Height - leftDownTexture.Height));
        var rightSidePos = ImageHelper.FillPattern(drawingContext, rightSideTexture,
            new Rect(midUpPos.Width + leftUpTexture.Width, rightUpTexture.Height,rightSideTexture.Width ,CIFRect.Height - rightUpTexture.Height - rightDownTexture.Height));

        drawingContext.DrawImage(leftDownTexture, new Rect(0, leftSidePos.Height + leftUpTexture.Height, leftDownTexture.Width, leftDownTexture.Height));
        var midDownPos = ImageHelper.FillPattern(drawingContext, midDownTexture,
            new Rect(rightDownTexture.Width, leftSidePos.Height + leftUpTexture.Height ,CIFRect.Width - rightDownTexture.Width - leftDownTexture.Width ,midDownTexture.Height));
        drawingContext.DrawImage(rightDownTexture, new Rect( midDownPos.Width + leftDownTexture.Width, rightSidePos.Height + rightUpTexture.Height, rightDownTexture.Width, rightDownTexture.Height));
    }
}