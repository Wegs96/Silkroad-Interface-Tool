using System.Windows;
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
        this.Loaded += OnLoaded;
    }

    private void OnLoaded(object sender, RoutedEventArgs e)
    {
        var mainframe = new CIFMainFrame();
        mainframe.DefaultSetup();
        designArea.designCanvas.Children.Add(mainframe);
    }
}