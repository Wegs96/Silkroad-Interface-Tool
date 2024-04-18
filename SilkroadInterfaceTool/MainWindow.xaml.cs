using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using SilkroadInterfaceTool.SROControls;

namespace SilkroadInterfaceTool;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        DefaultStyleKeyProperty.OverrideMetadata(typeof(CIFButton), new FrameworkPropertyMetadata(typeof(CIFButton)));
        DefaultStyleKeyProperty.OverrideMetadata(typeof(CIFFrame), new FrameworkPropertyMetadata(typeof(CIFFrame)));
        DefaultStyleKeyProperty.OverrideMetadata(typeof(CIFMainFrame),
            new FrameworkPropertyMetadata(typeof(CIFMainFrame)));
        DefaultStyleKeyProperty.OverrideMetadata(typeof(CIFNormalTile),
            new FrameworkPropertyMetadata(typeof(CIFNormalTile)));
        DefaultStyleKeyProperty.OverrideMetadata(typeof(CIFStatic), new FrameworkPropertyMetadata(typeof(CIFStatic)));
    }

    // TODO: To be removed and replaced with Right Click Context menu
    /// <summary>
    /// On Control Drop Event Handler
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    /// <exception cref="ArgumentOutOfRangeException"></exception>
    private void DesignArea_OnDrop(object sender, DragEventArgs e)
    {
        if (e.Data.GetData(DataFormats.Serializable) is Border s)
        {
            //Check if Control is CIFMainFrame If Exists just return to avoid multiple CIFMainFrames 
            if (s?.Tag.ToString() == "CIFMainFrame" &&
                Globals.CIFControlList.Any(p => p.CIFType == CIFType.CIFMainFrame))
            {
                MessageBox.Show("Adding multiple CIFMainFrame is not supported !", "Error");
                return;
            }
            //Check if CIFMainFrame Exists before adding other controls
            
            if (s?.Tag.ToString() != "CIFMainFrame" && Globals.CIFControlList.Count <= 0)
            {
                MessageBox.Show("You must add CIFMainFrame first !", "Error");
                return;
            }

            //Initializing a new control depends on Added control's type
            CIFControlBase sroControl = s?.Tag.ToString() switch
            {
                "CIFMainFrame" => new CIFMainFrame(designArea),
                "CIFFrame" => new CIFFrame(designArea),
                "CIFSubFrame" => new CIFFrame(designArea),
                "CIFNormalTile" => new CIFNormalTile(designArea),
                "CIFButton" => new CIFButton(designArea),
                "CIFStatic" => new CIFStatic(designArea),
                "CIFGauge" => new CIFGauge(designArea),

                _ => throw new ArgumentOutOfRangeException()
            };

            //Setting up the default setup for Control
            sroControl.DefaultSetup();
            Globals.CIFControlList.Add(sroControl);

            //Getting the control's drop position relative to design area
            var dropPos = e.GetPosition(designArea.designCanvas);
            //Adding the dropped control into design area canvas as child element
            designArea.designCanvas.Children.Add(sroControl);

            //Setting up the control's position to Drop Position
            sroControl.RenderTransform = new TranslateTransform(dropPos.X, dropPos.Y);

        }
    }
}