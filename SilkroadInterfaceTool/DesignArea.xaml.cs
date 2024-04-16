using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using SilkroadInterfaceTool.SROControls;

namespace SilkroadInterfaceTool;

public partial class DesignArea : UserControl
{

    public DesignArea()
    {
        InitializeComponent();
        this.ContextMenu = new ContextMenu();
        var mi = new MenuItem();
        mi.Header = "Add CIFMainFrame";
        var mi2 = new MenuItem();
        mi2.Header = "Add CIFFrame";
        var mi3 = new MenuItem();
        mi3.Header = "Add CIFNormalTile";
        var mi4 = new MenuItem();
        mi4.Header = "Add CIFButton";
        var mi5 = new MenuItem();
        mi5.Header = "Add CIFStatic";
        ContextMenu.Items.Add(mi);
        ContextMenu.Items.Add(mi2);
        ContextMenu.Items.Add(mi3);
        ContextMenu.Items.Add(mi4);
        ContextMenu.Items.Add(mi5);

       // this.designCanvas.ContextMenu = new ContextMenu();
      //  this.designCanvas.ContextMenu.Items.Add(mi);
    }
    //
    // public void AddControl(CIFControlBase control)
    // {
    //     var cIndex =this.designCanvas.Children.Add(control);
    //     Canvas.SetTop(control,control.CIFRect.Y);
    //     Canvas.SetLeft(control,control.CIFRect.X);
    //    
    // }
}