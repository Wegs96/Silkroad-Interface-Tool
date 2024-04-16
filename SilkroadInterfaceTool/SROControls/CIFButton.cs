using System.Drawing;
using System.Windows;
using Point = System.Windows.Point;

namespace SilkroadInterfaceTool.SROControls;

public class CIFButton : CIFControlBase
{
    public CIFButton(UIElement parent) : base(parent)
    {
        CIFType = CIFType.CIFButton;

        Height = 24;
        Width = 152;
    }
    
    public override void DefaultSetup()
    {
        base.DefaultSetup();
        
        CIFClientRect = new Rect(0, 0, 0, 0);
        CIFColor = Color.FromArgb(255,73,102,178);
        CIFDDJ = "interface\\\\system\\\\sys_button.ddj";
        CIFFontColor = Color.FromArgb(255,254,251,216);
        CIFFontIndex = 0;
        CIFHAlign = 1;
        CIFRect = new Rect(0,0,152,24);
        CIFStyle = 0;
        CIFSubSection = string.Empty;
        CIFText = string.Empty;
        CIFUV_LB = new Point(0, 1);
        CIFUV_LT = new Point(0, 0);
        CIFUV_RB = new Point(1, 1);
        CIFUV_RT = new Point(1, 0);
        CIFVAlign = 0;
        
        //-------\\
        Width = CIFRect.Width;
        Height = CIFRect.Height;
        Margin = new Thickness(CIFRect.X,CIFRect.Y,0,0);
    }
    
    /// <summary>
    /// Initializing a new CIFButton Control
    /// </summary>
    /// <param name="bName">base name aka classname</param>
    /// <param name="cName">Control Name</param>
    /// <param name="id"></param>
    // public CIFButton(int id ,string bName ,string cName) :this()
    // {
    //     CIFID = id;
    //     Name = $"GDR_{bName}_{cName}{id}";
    // }

    /// <summary>
    /// Initializing a new CIFButton Control with given rect (X,Y,Width,Height)
    /// </summary>
    /// <param name="id"></param>
    /// <param name="bName"></param>
    /// <param name="cName"></param>
    /// <param name="rect"></param>
    // public CIFButton(int id, string bName, string cName, Rect rect) : this(id, bName, cName)
    //     => CIFRect = rect;

}