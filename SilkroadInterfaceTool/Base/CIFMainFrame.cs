using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using SilkroadInterfaceTool.Helpers;
using SilkroadInterfaceTool.SROControls;
using Color = System.Drawing.Color;
using Point = System.Windows.Point;

namespace SilkroadInterfaceTool.Base;

public class CIFMainFrame : ControlBase
{
    private readonly Dictionary<int, CIFControl> _controlsList; //visual collection ??

    private readonly DesignArea _designArea;

    // private readonly VisualCollection _visualCollection;
    public CIFMainFrame(DesignArea designArea)
    {
        _designArea = designArea;
        _controlsList = new Dictionary<int, CIFControl>();
        //_visualCollection = new VisualCollection(this);

        if (ContextMenu != null)
        {
            foreach (var cType in Enum.GetValues(typeof(CIFType)).Cast<CIFType>())
            {
                if (cType == CIFType.CIFMainFrame || cType == CIFType.CIFUNKNOWN)
                    continue;

                var mItem = new MenuItem();
                mItem.Header = "Add New " + cType;
                mItem.Tag = cType;
                mItem.Click += (sender, args) =>
                {
                    var s = sender as MenuItem;
                    CIFControl sroControl = s?.Tag.ToString() switch
                    {
                        "CIFFrame" => new CIFFrame(this),
                        "CIFSubFrame" => new CIFFrame(this),
                        "CIFNormalTile" => new CIFNormalTile(this),
                        "CIFButton" => new CIFButton(this),
                        "CIFStatic" => new CIFStatic(this),
                        "CIFGauge" => new CIFGauge(this),
                        "CIFCheckBox" => new CIFCheckBox(this),
                        "CIFEdit" => new CIFEdit(this),
                        "CIFTextBox" => new CIFTextBox(this),
                        _ => throw new ArgumentOutOfRangeException()
                    };
                    sroControl.DefaultSetup();
                    AddControl(sroControl);
                    //Setting up the default setup for Control

                    //    Globals.CIFControlList.Add(sroControl);
                };

                ContextMenu.Items.Add(mItem);
            }
        }
    }

    public int ControlsCount => _controlsList.Count;
    public List<CIFControl> ControlsList => _controlsList.Values.ToList();

    protected override void OnInitialized(EventArgs e)
    {
        base.OnInitialized(e);
        //  AdornerLayer.GetAdornerLayer(this)?.Add(new CResizeAdorner(this));
    }

    public void AddControl(CIFControl ctrl)
    {
        if (_controlsList.ContainsValue(ctrl)) return;

        _controlsList.Add(_controlsList.Count > 0 ? _controlsList.Keys.Max() + 1 : 1, ctrl);
        Children.Add(ctrl);
        //_visualCollection.Add(ctrl);

        ctrl.RenderTransform = new TranslateTransform(ctrl.CIFRect.X, ctrl.CIFRect.Y);
    }

    public void RemoveControl(CIFControl ctrl)
    {
        if (!_controlsList.ContainsValue(ctrl)) return;

        _controlsList.Remove(_controlsList.FirstOrDefault(p => p.Value == ctrl).Key);
        this.Children.Remove(ctrl);
    }

    protected override Size ArrangeOverride(Size finalSize)
    {
        foreach (var ctrl in _controlsList.Values)
        {
            ctrl.Arrange(CIFRect);
        }

        return base.ArrangeOverride(finalSize);
    }

    public void DefaultSetup()
    {
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
            new Rect(leftUpTexture.Width, 0, Width - leftUpTexture.Width - rightUpTexture.Width, midUpTexture.Height));

        drawingContext.DrawImage(rightUpTexture,
            new Rect(midUpPos.Width + leftUpTexture.Width, 0, rightUpTexture.Width, rightUpTexture.Height));


        var leftSidePos = ImageHelper.FillPattern(drawingContext, leftSideTexture,
            new Rect(0, leftUpTexture.Height, leftSideTexture.Width,
                Height - leftUpTexture.Height - leftDownTexture.Height));
        var rightSidePos = ImageHelper.FillPattern(drawingContext, rightSideTexture,
            new Rect(midUpPos.Width + leftUpTexture.Width, rightUpTexture.Height, rightSideTexture.Width,
                Height - rightUpTexture.Height - rightDownTexture.Height));

        drawingContext.DrawImage(leftDownTexture,
            new Rect(0, leftSidePos.Height + leftUpTexture.Height, leftDownTexture.Width, leftDownTexture.Height));
        var midDownPos = ImageHelper.FillPattern(drawingContext, midDownTexture,
            new Rect(rightDownTexture.Width, leftSidePos.Height + leftUpTexture.Height,
                Width - rightDownTexture.Width - leftDownTexture.Width, midDownTexture.Height));
        drawingContext.DrawImage(rightDownTexture,
            new Rect(midDownPos.Width + leftDownTexture.Width, rightSidePos.Height + rightUpTexture.Height,
                rightDownTexture.Width, rightDownTexture.Height));
    }
}