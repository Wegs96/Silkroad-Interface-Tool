using System.Windows.Media.Imaging;

namespace SilkroadInterfaceTool.Helpers;

public static class ResourceHelper
{
    public static BitmapImage GetBitmapImageFromRes(string path)
        =>
            new BitmapImage(new Uri("pack://application:,,,/SilkroadInterfaceTool;component/" + path,
                UriKind.Absolute));
}