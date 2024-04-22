using System.Windows;
using SilkroadInterfaceTool.Base;

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
        var dArea = new DesignArea(this);
        MainDockPanel.Children.Add(dArea);
    }
}