using System.Windows;
using System.Windows.Documents;
using SilkroadInterfaceTool.SROControls;
using SilkroadInterfaceTool.SROControls.Helpers;

namespace SilkroadInterfaceTool;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        this.Loaded += OnLoaded;
    }

    private void OnLoaded(object sender, RoutedEventArgs e)
    {
        var mainframe = new CIFMainFrame();
        mainframe.DefaultSetup();
        designArea.designCanvas.Children.Add(mainframe);
        //MainFrame Resizable !
        AdornerLayer.GetAdornerLayer(designArea.designCanvas)?.Add(new CResizeAdorner(mainframe));
    }
}