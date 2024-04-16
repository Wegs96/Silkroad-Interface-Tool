using System.Drawing;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using SilkroadInterfaceTool.SROControls;
using Rectangle = System.Windows.Shapes.Rectangle;

namespace SilkroadInterfaceTool;

public partial class LeftSidePanel : UserControl
{
    public LeftSidePanel()
    {
        InitializeComponent();
    }

    private void CIFControls_OnMouseMove(object sender, MouseEventArgs e)
    {
        if (sender is not Border ctrl) return;

        if (e.LeftButton == MouseButtonState.Pressed)
            DragDrop.DoDragDrop(ctrl,new DataObject(DataFormats.Serializable, ctrl), DragDropEffects.Copy);
    }
}