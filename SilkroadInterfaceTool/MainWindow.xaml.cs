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

    private void DesignArea_OnDrop(object sender, DragEventArgs e)
    {
        if (e.Data.GetData(DataFormats.Serializable) is Border s)
        {

            if (s?.Tag.ToString() == "CIFMainFrame" &&
                Globals.CIFControlList.Any(p => p.CIFType == CIFType.CIFMainFrame))
            {
                MessageBox.Show("Adding multiple CIFMainFrame is not supported !", "Error");
                return;
            }

            if (s?.Tag.ToString() != "CIFMainFrame" && Globals.CIFControlList.Count <= 0)
            {
                MessageBox.Show("You must add CIFMainFrame first !", "Error");
                return;
            }

            CIFControlBase sroControl = s?.Tag.ToString() switch
            {
                "CIFMainFrame" => new CIFMainFrame(designArea),
                "CIFFrame" => new CIFFrame(designArea),
                "CIFSubFrame" => new CIFFrame(designArea),
                "CIFNormalTile" => new CIFNormalTile(designArea),
                "CIFButton" => new CIFButton(designArea),
                "CIFStatic" => new CIFStatic(designArea),
                _ => throw new ArgumentOutOfRangeException()
            };

            sroControl.DefaultSetup();
            Globals.CIFControlList.Add(sroControl);

            var dropPos = e.GetPosition(designArea.designCanvas);
           var ss = designArea.designCanvas.Children.Add(sroControl);
            
           sroControl.RenderTransform = new TranslateTransform(dropPos.X, dropPos.Y);

           // Canvas.SetLeft(designArea.designCanvas.Children[ss], dropPos.X);
         //   Canvas.SetTop(designArea.designCanvas.Children[ss], dropPos.Y);
        }

        
    }

}