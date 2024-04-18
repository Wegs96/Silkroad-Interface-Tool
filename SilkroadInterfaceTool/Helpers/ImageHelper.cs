using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace SilkroadInterfaceTool.Helpers;

public class ImageHelper
{
    public static Size FillPattern(DrawingContext d, BitmapImage image, Rect rect)
    {
        Rect imageRect;
        var returnPos = new Size(0,0);
        for (var x = (int)rect.X; x < rect.Right; x += (int)image.Width)
        {
            for (var y = (int)rect.Y; y < rect.Bottom; y += (int)image.Height)
            {
                var drawRect = new Rect(x, y, Math.Min(image.Width, rect.Right - x),
                    Math.Min(image.Height, rect.Bottom - y));
                
                d.DrawImage(image, drawRect);
                
                returnPos.Height += drawRect.Height / 2;
                returnPos.Width += drawRect.Width / 2;
            }
        }
        
        return returnPos ;
    }
}